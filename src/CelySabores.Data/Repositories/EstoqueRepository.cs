using System.Collections.Generic;
using System.Data.SqlClient;
using CelySabores.Data.Database;
using CelySabores.Models.Entities;
using CelySabores.Models.Enums;

namespace CelySabores.Data.Repositories
{
    /// <summary>
    /// Acesso aos ingredientes, aos movimentos de estoque e as receitas dos
    /// pratos. Todas as alteracoes de quantidade passam por
    /// <see cref="RegistrarMovimento"/>, que actualiza o ingrediente e regista
    /// o movimento na mesma transaccao, para o historico nunca divergir do
    /// saldo actual.
    /// </summary>
    public class EstoqueRepository : RepositorioBase
    {
        private const string ColunasIngrediente =
            "Id, Nome, Unidade, QuantidadeDisponivel, QuantidadeMinima, PrecoCusto, Ativo";

        public EstoqueRepository(CommandHelper commandHelper) : base(commandHelper)
        {
        }

        // ---------------------------------------------------------------- ingredientes

        public IList<Ingrediente> ListarIngredientes(bool incluirInativos)
        {
            var sql = "SELECT " + ColunasIngrediente + " FROM Ingredientes";
            if (!incluirInativos)
            {
                sql += " WHERE Ativo = 1";
            }

            sql += " ORDER BY Nome";

            return LerIngredientes(Db.ExecuteDataTable(sql));
        }

        public IList<Ingrediente> ListarEstoqueBaixo()
        {
            // QuantidadeMinima > 0 evita falsos positivos: um ingrediente sem
            // minimo configurado tem 0 <= 0 e apareceria sempre como "baixo"
            var sql =
        "SELECT " + ColunasIngrediente + " FROM Ingredientes"
        + " WHERE Ativo = 1 AND QuantidadeMinima > 0 AND QuantidadeDisponivel <= QuantidadeMinima"
        + " ORDER BY (QuantidadeDisponivel - QuantidadeMinima), Nome";

            return LerIngredientes(Db.ExecuteDataTable(sql));
        }

        public Ingrediente ObterIngrediente(int id)
        {
            var sql = "SELECT " + ColunasIngrediente + " FROM Ingredientes WHERE Id = @Id";
            var tabela = Db.ExecuteDataTable(sql, new SqlParameter("@Id", id));
            return tabela.Rows.Count == 0 ? null : MapearIngrediente(tabela.Rows[0]);
        }

        public int InserirIngrediente(Ingrediente ingrediente)
        {
            const string sql =
                @"INSERT INTO Ingredientes (Nome, Unidade, QuantidadeDisponivel, QuantidadeMinima, PrecoCusto, Ativo)
                  VALUES (@Nome, @Unidade, @QuantidadeDisponivel, @QuantidadeMinima, @PrecoCusto, @Ativo);
                  SELECT SCOPE_IDENTITY();";

            var id = Db.ExecuteScalar(sql,
                new SqlParameter("@Nome", ingrediente.Nome),
                new SqlParameter("@Unidade", ingrediente.Unidade),
                new SqlParameter("@QuantidadeDisponivel", ingrediente.QuantidadeDisponivel),
                new SqlParameter("@QuantidadeMinima", ingrediente.QuantidadeMinima),
                new SqlParameter("@PrecoCusto", ingrediente.PrecoCusto),
                new SqlParameter("@Ativo", ingrediente.Ativo ? 1 : 0));

            return System.Convert.ToInt32(id);
        }

        /// <summary>
        /// Actualiza o cadastro do ingrediente sem mexer na quantidade. A
        /// quantidade so muda por movimento, para o historico continuar a
        /// explicar o saldo.
        /// </summary>
        public void AtualizarIngrediente(Ingrediente ingrediente)
        {
            const string sql =
                @"UPDATE Ingredientes
                  SET Nome = @Nome,
                      Unidade = @Unidade,
                      QuantidadeMinima = @QuantidadeMinima,
                      PrecoCusto = @PrecoCusto,
                      Ativo = @Ativo
                  WHERE Id = @Id";

            Db.ExecuteNonQuery(sql,
                new SqlParameter("@Nome", ingrediente.Nome),
                new SqlParameter("@Unidade", ingrediente.Unidade),
                new SqlParameter("@QuantidadeMinima", ingrediente.QuantidadeMinima),
                new SqlParameter("@PrecoCusto", ingrediente.PrecoCusto),
                new SqlParameter("@Ativo", ingrediente.Ativo ? 1 : 0),
                new SqlParameter("@Id", ingrediente.Id));
        }

        /// <summary>
        /// Quantos pratos usam o ingrediente na receita. Impede apagar um
        /// ingrediente que ainda aparece em receitas.
        /// </summary>
        public int ContarReceitasDoIngrediente(int ingredienteId)
        {
            const string sql = "SELECT COUNT(*) FROM ReceitaPrato WHERE IngredienteId = @Id";
            return System.Convert.ToInt32(
                Db.ExecuteScalar(sql, new SqlParameter("@Id", ingredienteId)));
        }

        // ---------------------------------------------------------------- movimentos

        /// <summary>
        /// Regista um movimento e aplica-o ao saldo do ingrediente em atomicidade.
        /// Entrada soma, Saida subtrai e Ajuste substitui o saldo pelo valor
        /// contado. Lanca <see cref="System.InvalidOperationException"/> se uma
        /// saida deixar a quantidade negativa.
        /// </summary>
        public MovimentoEstoque RegistrarMovimento(int ingredienteId, TipoMovimentoEstoque tipo,
            decimal quantidade, string observacao, int? pedidoId, int? funcionarioId)
        {
            return Db.ExecutarEmTransacao<MovimentoEstoque>((connection, command) =>
            {
                // UPDLOCK serializa movimentos concorrentes do mesmo ingrediente,
                // para dois registos ao mesmo tempo nao perderem uma soma
                command.CommandText =
                    "SELECT Nome, Unidade, QuantidadeDisponivel FROM Ingredientes WITH (UPDLOCK) WHERE Id = @Id";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Id", ingredienteId));

                decimal disponivel;
                string nome;
                string unidade;
                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        throw new System.InvalidOperationException("Ingrediente não encontrado.");
                    }

                    nome = reader.GetString(0);
                    unidade = reader.GetString(1);
                    disponivel = reader.GetDecimal(2);
                    reader.Close();
                }

                decimal novoValor;
                if (tipo == TipoMovimentoEstoque.Entrada)
                {
                    novoValor = disponivel + quantidade;
                }
                else if (tipo == TipoMovimentoEstoque.Saida)
                {
                    novoValor = disponivel - quantidade;
                    if (novoValor < 0)
                    {
                        throw new System.InvalidOperationException(
                            "Não há stock suficiente de '" + nome + "'."
                            + " Disponível: " + disponivel.ToString("0.###") + " " + unidade + ".");
                    }
                }
                else
                {
                    // ajuste: o valor informado e a quantidade contada
                    novoValor = quantidade;
                }

                command.CommandText = "UPDATE Ingredientes SET QuantidadeDisponivel = @Valor WHERE Id = @Id";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Valor", novoValor));
                command.Parameters.Add(new SqlParameter("@Id", ingredienteId));
                command.ExecuteNonQuery();

                command.CommandText =
                    @"INSERT INTO MovimentosEstoque
                        (IngredienteId, Tipo, Quantidade, Observacao, PedidoId, FuncionarioId)
                      VALUES (@IngredienteId, @Tipo, @Quantidade, @Observacao, @PedidoId, @FuncionarioId);
                      SELECT CAST(SCOPE_IDENTITY() AS INT);";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@IngredienteId", ingredienteId));
                command.Parameters.Add(new SqlParameter("@Tipo", (int)tipo));
                command.Parameters.Add(new SqlParameter("@Quantidade", quantidade));
                command.Parameters.Add(new SqlParameter("@Observacao",
                    (object)observacao ?? System.DBNull.Value));
                command.Parameters.Add(new SqlParameter("@PedidoId",
                    (object)pedidoId ?? System.DBNull.Value));
                command.Parameters.Add(new SqlParameter("@FuncionarioId",
                    (object)funcionarioId ?? System.DBNull.Value));

                var movimentoId = System.Convert.ToInt32(command.ExecuteScalar());

                return new MovimentoEstoque
                {
                    Id = movimentoId,
                    IngredienteId = ingredienteId,
                    Tipo = tipo,
                    Quantidade = quantidade,
                    Data = System.DateTime.Now,
                    Observacao = observacao,
                    PedidoId = pedidoId,
                    FuncionarioId = funcionarioId,
                    IngredienteNome = nome
                };
            });
        }

        public IList<MovimentoEstoque> ListarMovimentos(int? ingredienteId,
            System.DateTime? de, System.DateTime? ate)
        {
            var sql =
                @"SELECT m.Id, m.IngredienteId, m.Tipo, m.Quantidade, m.Data, m.Observacao,
                         m.PedidoId, m.FuncionarioId, i.Nome AS IngredienteNome
                  FROM MovimentosEstoque m
                  INNER JOIN Ingredientes i ON i.Id = m.IngredienteId
                  WHERE 1 = 1";

            var parametros = new List<SqlParameter>();

            if (ingredienteId.HasValue)
            {
                sql += " AND m.IngredienteId = @IngredienteId";
                parametros.Add(new SqlParameter("@IngredienteId", ingredienteId.Value));
            }

            if (de.HasValue)
            {
                sql += " AND m.Data >= @De";
                parametros.Add(new SqlParameter("@De", de.Value));
            }

            if (ate.HasValue)
            {
                // inclusivo no dia final, mesmo que o filtro traga so a data
                sql += " AND m.Data < DATEADD(DAY, 1, @Ate)";
                parametros.Add(new SqlParameter("@Ate", ate.Value.Date));
            }

            sql += " ORDER BY m.Data DESC, m.Id DESC";

            var tabela = Db.ExecuteDataTable(sql, parametros.ToArray());
            var movimentos = new List<MovimentoEstoque>();

            foreach (System.Data.DataRow linha in tabela.Rows)
            {
                movimentos.Add(new MovimentoEstoque
                {
                    Id = Leitor.Int(linha, "Id"),
                    IngredienteId = Leitor.Int(linha, "IngredienteId"),
                    Tipo = (TipoMovimentoEstoque)Leitor.Int(linha, "Tipo"),
                    Quantidade = Leitor.Decimal(linha, "Quantidade"),
                    Data = Leitor.DateTime(linha, "Data"),
                    Observacao = Leitor.String(linha, "Observacao"),
                    PedidoId = Leitor.IntNulo(linha, "PedidoId"),
                    FuncionarioId = Leitor.IntNulo(linha, "FuncionarioId"),
                    IngredienteNome = Leitor.String(linha, "IngredienteNome")
                });
            }

            return movimentos;
        }

        // ---------------------------------------------------------------- receitas

        public IList<ReceitaPrato> ListarReceita(int pratoId)
        {
            var sql =
                @"SELECT r.Id, r.PratoId, r.IngredienteId, r.Quantidade,
                         i.Nome AS IngredienteNome, i.Unidade AS IngredienteUnidade
                  FROM ReceitaPrato r
                  INNER JOIN Ingredientes i ON i.Id = r.IngredienteId
                  WHERE r.PratoId = @PratoId
                  ORDER BY i.Nome";

            var tabela = Db.ExecuteDataTable(sql, new SqlParameter("@PratoId", pratoId));
            var receita = new List<ReceitaPrato>();

            foreach (System.Data.DataRow linha in tabela.Rows)
            {
                receita.Add(new ReceitaPrato
                {
                    Id = Leitor.Int(linha, "Id"),
                    PratoId = Leitor.Int(linha, "PratoId"),
                    IngredienteId = Leitor.Int(linha, "IngredienteId"),
                    Quantidade = Leitor.Decimal(linha, "Quantidade"),
                    IngredienteNome = Leitor.String(linha, "IngredienteNome"),
                    IngredienteUnidade = Leitor.String(linha, "IngredienteUnidade")
                });
            }

            return receita;
        }

        /// <summary>Substitui a receita do prato pela lista informada.</summary>
        public void SubstituirReceita(int pratoId, IList<ReceitaPrato> receita)
        {
            Db.ExecutarEmTransacao((connection, command) =>
            {
                command.CommandText = "DELETE FROM ReceitaPrato WHERE PratoId = @PratoId";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@PratoId", pratoId));
                command.ExecuteNonQuery();

                foreach (var linha in receita)
                {
                    command.CommandText =
                        @"INSERT INTO ReceitaPrato (PratoId, IngredienteId, Quantidade)
                          VALUES (@PratoId, @IngredienteId, @Quantidade);";
                    command.Parameters.Clear();
                    command.Parameters.Add(new SqlParameter("@PratoId", pratoId));
                    command.Parameters.Add(new SqlParameter("@IngredienteId", linha.IngredienteId));
                    command.Parameters.Add(new SqlParameter("@Quantidade", linha.Quantidade));
                    command.ExecuteNonQuery();
                }
            });
        }

        /// <summary>
        /// Pratos sem nenhum ingrediente na receita. Ajuda o gerente a saber o
        /// que ainda nao foi configurado.
        /// </summary>
        public IList<string> ListarPratosSemReceita()
        {
            const string sql =
                @"SELECT p.Nome
                  FROM Pratos p
                  LEFT JOIN ReceitaPrato r ON r.PratoId = p.Id
                  WHERE p.Ativo = 1 AND r.Id IS NULL
                  ORDER BY p.Nome";

            var tabela = Db.ExecuteDataTable(sql);
            var pratos = new List<string>();

            foreach (System.Data.DataRow linha in tabela.Rows)
            {
                pratos.Add(Leitor.String(linha, "Nome"));
            }

            return pratos;
        }

        // ---------------------------------------------------------------- auxiliares

        private static IList<Ingrediente> LerIngredientes(System.Data.DataTable tabela)
        {
            var lista = new List<Ingrediente>();
            foreach (System.Data.DataRow linha in tabela.Rows)
            {
                lista.Add(MapearIngrediente(linha));
            }

            return lista;
        }

        private static Ingrediente MapearIngrediente(System.Data.DataRow linha)
        {
            return new Ingrediente
            {
                Id = Leitor.Int(linha, "Id"),
                Nome = Leitor.String(linha, "Nome"),
                Unidade = Leitor.String(linha, "Unidade"),
                QuantidadeDisponivel = Leitor.Decimal(linha, "QuantidadeDisponivel"),
                QuantidadeMinima = Leitor.Decimal(linha, "QuantidadeMinima"),
                PrecoCusto = Leitor.Decimal(linha, "PrecoCusto"),
                Ativo = Leitor.Bool(linha, "Ativo")
            };
        }
    }
}
