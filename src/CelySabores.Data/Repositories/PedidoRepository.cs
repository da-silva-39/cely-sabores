using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CelySabores.Data.Database;
using CelySabores.Models.Entities;
using CelySabores.Models.Enums;

namespace CelySabores.Data.Repositories
{
    public class PedidoRepository : RepositorioBase
    {
        private const string Colunas =
            @"p.Id, p.MesaId, p.ClienteId, p.FuncionarioAberturaId, p.DataAbertura,
              p.Estado, p.ValorTotal, p.Observacao, p.DataFechamento,
              p.FuncionarioFechamentoId, m.Numero AS MesaNumero,
              ISNULL(c.NomeCompleto, '') AS ClienteNome,
              fa.NomeCompleto AS FuncionarioNome";

        private const string From =
            @"FROM Pedidos p
              INNER JOIN Mesas m ON m.Id = p.MesaId
              INNER JOIN Funcionarios fa ON fa.Id = p.FuncionarioAberturaId
              LEFT JOIN Clientes c ON c.Id = p.ClienteId";

        public PedidoRepository(CommandHelper commandHelper) : base(commandHelper)
        {
        }

        public IList<Pedido> Listar(EstadoPedido? estado, DateTime? de, DateTime? ate)
        {
            var sql = "SELECT " + Colunas + " " + From + " WHERE 1 = 1";
            var parametros = new List<SqlParameter>();

            if (estado.HasValue)
            {
                sql += " AND p.Estado = @Estado";
                parametros.Add(new SqlParameter("@Estado", (int)estado.Value));
            }
            if (de.HasValue)
            {
                sql += " AND p.DataAbertura >= @De";
                parametros.Add(new SqlParameter("@De", de.Value));
            }
            if (ate.HasValue)
            {
                sql += " AND p.DataAbertura <= @Ate";
                parametros.Add(new SqlParameter("@Ate", ate.Value));
            }
            sql += " ORDER BY p.DataAbertura DESC";

            var tabela = Db.ExecuteDataTable(sql, parametros.ToArray());
            var pedidos = new List<Pedido>();

            foreach (System.Data.DataRow linha in tabela.Rows)
            {
                pedidos.Add(Mapear(linha));
            }

            return pedidos;
        }

        public Pedido ObterPorId(int id)
        {
            var sql = "SELECT " + Colunas + " " + From + " WHERE p.Id = @Id";
            var tabela = Db.ExecuteDataTable(sql, new SqlParameter("@Id", id));

            return tabela.Rows.Count == 0 ? null : Mapear(tabela.Rows[0]);
        }

        public Pedido ObterAbertoPorMesa(int mesaId)
        {
            var sql = "SELECT " + Colunas + " " + From
                + " WHERE p.MesaId = @MesaId AND p.Estado = 1";
            var tabela = Db.ExecuteDataTable(sql, new SqlParameter("@MesaId", mesaId));

            return tabela.Rows.Count == 0 ? null : Mapear(tabela.Rows[0]);
        }

        public IList<ItemPedido> ListarItens(int pedidoId)
        {
            var sql =
                @"SELECT i.Id, i.PedidoId, i.PratoId, i.Quantidade, i.PrecoUnitario,
                         i.Subtotal, i.Observacao, p.Nome AS PratoNome
                  FROM ItensPedido i
                  INNER JOIN Pratos p ON p.Id = i.PratoId
                  WHERE i.PedidoId = @PedidoId
                  ORDER BY i.Id";

            var tabela = Db.ExecuteDataTable(sql, new SqlParameter("@PedidoId", pedidoId));
            var itens = new List<ItemPedido>();

            foreach (System.Data.DataRow linha in tabela.Rows)
            {
                itens.Add(new ItemPedido
                {
                    Id = Leitor.Int(linha, "Id"),
                    PedidoId = Leitor.Int(linha, "PedidoId"),
                    PratoId = Leitor.Int(linha, "PratoId"),
                    Quantidade = Leitor.Int(linha, "Quantidade"),
                    PrecoUnitario = Leitor.Decimal(linha, "PrecoUnitario"),
                    Subtotal = Leitor.Decimal(linha, "Subtotal"),
                    Observacao = Leitor.String(linha, "Observacao"),
                    PratoNome = Leitor.String(linha, "PratoNome")
                });
            }

            return itens;
        }

        public ItemPedido ObterItemPorId(int itemId)
        {
            var sql =
                @"SELECT i.Id, i.PedidoId, i.PratoId, i.Quantidade, i.PrecoUnitario,
                         i.Subtotal, i.Observacao, p.Nome AS PratoNome
                  FROM ItensPedido i
                  INNER JOIN Pratos p ON p.Id = i.PratoId
                  WHERE i.Id = @Id";

            var tabela = Db.ExecuteDataTable(sql, new SqlParameter("@Id", itemId));
            if (tabela.Rows.Count == 0)
            {
                return null;
            }

            var linha = tabela.Rows[0];

            return new ItemPedido
            {
                Id = Leitor.Int(linha, "Id"),
                PedidoId = Leitor.Int(linha, "PedidoId"),
                PratoId = Leitor.Int(linha, "PratoId"),
                Quantidade = Leitor.Int(linha, "Quantidade"),
                PrecoUnitario = Leitor.Decimal(linha, "PrecoUnitario"),
                Subtotal = Leitor.Decimal(linha, "Subtotal"),
                Observacao = Leitor.String(linha, "Observacao"),
                PratoNome = Leitor.String(linha, "PratoNome")
            };
        }

        public int Abrir(int mesaId, int? clienteId, int funcionarioId, string observacao)
        {
            return Db.ExecutarEmTransacao<int>((connection, command) =>
            {
                const string sqlPedido =
                    @"INSERT INTO Pedidos (MesaId, ClienteId, FuncionarioAberturaId, Estado, ValorTotal, Observacao)
                      VALUES (@MesaId, @ClienteId, @FuncionarioId, 1, 0, @Observacao);
                      SELECT CAST(SCOPE_IDENTITY() AS INT);";

                command.CommandText = sqlPedido;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@MesaId", mesaId));
                command.Parameters.Add(Nulo("@ClienteId", clienteId));
                command.Parameters.Add(new SqlParameter("@FuncionarioId", funcionarioId));
                command.Parameters.Add(Nulo("@Observacao", observacao));

                var id = System.Convert.ToInt32(command.ExecuteScalar());

                command.CommandText = "UPDATE Mesas SET Estado = 1 WHERE Id = @MesaId";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@MesaId", mesaId));
                command.ExecuteNonQuery();

                return id;
            });
        }

        public ItemPedido AdicionarItem(int pedidoId, int pratoId, int quantidade, string observacao)
        {
            return Db.ExecutarEmTransacao<ItemPedido>((connection, command) =>
            {
                decimal preco;
                string nome;

                command.CommandText = "SELECT Preco, Nome FROM Pratos WHERE Id = @PratoId";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@PratoId", pratoId));

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        throw new InvalidOperationException("Prato não encontrado.");
                    }

                    preco = (decimal)reader["Preco"];
                    nome = System.Convert.ToString(reader["Nome"]);
                }

                return InserirItem(command, pedidoId, pratoId, quantidade, preco, observacao, nome);
            });
        }

        private ItemPedido InserirItem(SqlCommand command, int pedidoId, int pratoId, int quantidade,
            decimal preco, string observacao, string nome)
        {
            var subtotal = System.Math.Round(preco * quantidade, 2);

            command.CommandText =
                @"INSERT INTO ItensPedido (PedidoId, PratoId, Quantidade, PrecoUnitario, Subtotal, Observacao)
                  VALUES (@PedidoId, @PratoId, @Quantidade, @PrecoUnitario, @Subtotal, @Observacao);
                  SELECT CAST(SCOPE_IDENTITY() AS INT);";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter("@PedidoId", pedidoId));
            command.Parameters.Add(new SqlParameter("@PratoId", pratoId));
            command.Parameters.Add(new SqlParameter("@Quantidade", quantidade));
            command.Parameters.Add(new SqlParameter("@PrecoUnitario", preco));
            command.Parameters.Add(new SqlParameter("@Subtotal", subtotal));
            command.Parameters.Add(Nulo("@Observacao", observacao));

            var id = System.Convert.ToInt32(command.ExecuteScalar());

            return new ItemPedido
            {
                Id = id,
                PedidoId = pedidoId,
                PratoId = pratoId,
                Quantidade = quantidade,
                PrecoUnitario = preco,
                Subtotal = subtotal,
                Observacao = observacao,
                PratoNome = nome
            };
        }

        public void RemoverItem(int itemId)
        {
            Db.ExecutarEmTransacao((connection, command) =>
            {
                // captura o pedido ANTES de apagar, senao a linha ja nao existe
                command.CommandText =
                    @"DECLARE @PedidoId INT = (SELECT PedidoId FROM ItensPedido WHERE Id = @Id);
                      DELETE FROM ItensPedido WHERE Id = @Id;
                      UPDATE Pedidos SET ValorTotal = ISNULL(
                          (SELECT SUM(Subtotal) FROM ItensPedido WHERE PedidoId = @PedidoId), 0)
                      WHERE Id = @PedidoId;";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Id", itemId));
                command.ExecuteNonQuery();
            });
        }

        public void ActualizarQuantidadeItem(int itemId, int quantidade)
        {
            Db.ExecutarEmTransacao((connection, command) =>
            {
                command.CommandText =
                    @"DECLARE @PedidoId INT = (SELECT PedidoId FROM ItensPedido WHERE Id = @Id);
                      UPDATE ItensPedido
                      SET Quantidade = @Quantidade,
                          Subtotal = ROUND(PrecoUnitario * @Quantidade, 2)
                      WHERE Id = @Id;
                      UPDATE Pedidos SET ValorTotal = ISNULL(
                          (SELECT SUM(Subtotal) FROM ItensPedido WHERE PedidoId = @PedidoId), 0)
                      WHERE Id = @PedidoId;";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Id", itemId));
                command.Parameters.Add(new SqlParameter("@Quantidade", quantidade));
                command.ExecuteNonQuery();
            });
        }

        public decimal RecalcularTotal(int pedidoId)
        {
            var sql =
                @"DECLARE @Total DECIMAL(10,2) =
                    ISNULL((SELECT SUM(Subtotal) FROM ItensPedido WHERE PedidoId = @PedidoId), 0);
                  UPDATE Pedidos SET ValorTotal = @Total WHERE Id = @PedidoId;
                  SELECT @Total;";

            return System.Convert.ToDecimal(Db.ExecuteScalar(sql, new SqlParameter("@PedidoId", pedidoId)));
        }

        public Pagamento RegistarPagamentoEfechar(int pedidoId, decimal valorRecebido, int funcionarioId)
        {
            return Db.ExecutarEmTransacao<Pagamento>((connection, command) =>
            {
                command.CommandText =
                    "SELECT ValorTotal, MesaId FROM Pedidos WHERE Id = @Id AND Estado = 1";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Id", pedidoId));

                decimal total;
                int mesaId;
                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        throw new InvalidOperationException("Pedido aberto não encontrado.");
                    }
                    total = (decimal)reader["ValorTotal"];
                    mesaId = System.Convert.ToInt32(reader["MesaId"]);
                    reader.Close();
                }

                var troco = System.Math.Round(valorRecebido - total, 2);

                command.CommandText =
                    @"INSERT INTO Pagamentos (PedidoId, ValorRecebido, Troco, FuncionarioId)
                      VALUES (@PedidoId, @ValorRecebido, @Troco, @FuncionarioId);
                      SELECT CAST(SCOPE_IDENTITY() AS INT);";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@PedidoId", pedidoId));
                command.Parameters.Add(new SqlParameter("@ValorRecebido", valorRecebido));
                command.Parameters.Add(new SqlParameter("@Troco", troco));
                command.Parameters.Add(new SqlParameter("@FuncionarioId", funcionarioId));

                var pagamentoId = System.Convert.ToInt32(command.ExecuteScalar());

                command.CommandText =
                    @"UPDATE Pedidos
                      SET Estado = 2, DataFechamento = GETDATE(), FuncionarioFechamentoId = @FuncionarioId
                      WHERE Id = @Id;
                      UPDATE Mesas SET Estado = 0 WHERE Id = @MesaId;";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Id", pedidoId));
                command.Parameters.Add(new SqlParameter("@FuncionarioId", funcionarioId));
                command.Parameters.Add(new SqlParameter("@MesaId", mesaId));
                command.ExecuteNonQuery();

                return new Pagamento
                {
                    Id = pagamentoId,
                    PedidoId = pedidoId,
                    ValorRecebido = valorRecebido,
                    Troco = troco,
                    DataPagamento = DateTime.Now,
                    FuncionarioId = funcionarioId
                };
            });
        }

        public void Cancelar(int pedidoId, int funcionarioId)
        {
            Db.ExecutarEmTransacao((connection, command) =>
            {
                command.CommandText =
                    @"DECLARE @MesaId INT = (SELECT MesaId FROM Pedidos WHERE Id = @Id AND Estado = 1);
                      UPDATE Pedidos
                      SET Estado = 3, DataFechamento = GETDATE(), FuncionarioFechamentoId = @FuncionarioId
                      WHERE Id = @Id AND Estado = 1;
                      UPDATE Mesas SET Estado = 0 WHERE Id = @MesaId;";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Id", pedidoId));
                command.Parameters.Add(new SqlParameter("@FuncionarioId", funcionarioId));
                command.ExecuteNonQuery();
            });
        }

        private static Pedido Mapear(System.Data.DataRow linha)
        {
            return new Pedido
            {
                Id = Leitor.Int(linha, "Id"),
                MesaId = Leitor.Int(linha, "MesaId"),
                ClienteId = Leitor.IntNulo(linha, "ClienteId"),
                FuncionarioAberturaId = Leitor.Int(linha, "FuncionarioAberturaId"),
                DataAbertura = Leitor.DateTime(linha, "DataAbertura"),
                Estado = (EstadoPedido)Leitor.Int(linha, "Estado"),
                ValorTotal = Leitor.Decimal(linha, "ValorTotal"),
                Observacao = Leitor.String(linha, "Observacao"),
                DataFechamento = Leitor.DateTimeNulo(linha, "DataFechamento"),
                FuncionarioFechamentoId = Leitor.IntNulo(linha, "FuncionarioFechamentoId"),
                MesaNumero = Leitor.Int(linha, "MesaNumero"),
                ClienteNome = Leitor.String(linha, "ClienteNome"),
                FuncionarioNome = Leitor.String(linha, "FuncionarioNome")
            };
        }
    }
}
