using System;
using System.Collections.Generic;
using CelySabores.Data.Database;
using CelySabores.Models.Dtos;
using CelySabores.Models.Enums;

namespace CelySabores.Data.Repositories
{
    public class DashboardRepository : RepositorioBase
    {
        public DashboardRepository(CommandHelper commandHelper) : base(commandHelper)
        {
        }

        public int ContarPedidosAbertos()
        {
            var sql = "SELECT COUNT(*) FROM dbo.Pedidos WHERE Estado = 1";
            return Convert.ToInt32(Db.ExecuteScalar(sql));
        }

        public int ContarPedidosFechadosHoje()
        {
            var sql =
                @"SELECT COUNT(*) FROM dbo.Pedidos
                  WHERE Estado = 2 AND DataFechamento >= @InicioDoDia";
            return Convert.ToInt32(Db.ExecuteScalar(sql, inicioDoDia()));
        }

        public int ContarPedidosCanceladosHoje()
        {
            var sql =
                @"SELECT COUNT(*) FROM dbo.Pedidos
                  WHERE Estado = 3 AND DataAbertura >= @InicioDoDia";
            return Convert.ToInt32(Db.ExecuteScalar(sql, inicioDoDia()));
        }

        public decimal FaturamentoHoje()
        {
            var sql =
                @"SELECT ISNULL(SUM(ValorTotal), 0) FROM dbo.Pedidos
                  WHERE Estado = 2 AND DataFechamento >= @InicioDoDia";
            return Convert.ToDecimal(Db.ExecuteScalar(sql, inicioDoDia()));
        }

        public decimal ValorEmAberto()
        {
            var sql = "SELECT ISNULL(SUM(ValorTotal), 0) FROM dbo.Pedidos WHERE Estado = 1";
            return Convert.ToDecimal(Db.ExecuteScalar(sql));
        }

        /// <summary>
        /// Total efetivamente recebido hoje e o troco devolvido.
        /// Vem de Pagamentos, e nao de Pedidos: o sistema nao guarda forma de
        /// pagamento, apenas o valor entregue e o troco (requisito 8).
        /// </summary>
        public void ObterRecebidoHoje(out decimal recebido, out decimal troco)
        {
            var sql =
                @"SELECT ISNULL(SUM(ValorRecebido), 0) AS Recebido,
                         ISNULL(SUM(Troco), 0) AS Troco
                  FROM dbo.Pagamentos
                  WHERE DataPagamento >= @InicioDoDia";

            var tabela = Db.ExecuteDataTable(sql, inicioDoDia());
            recebido = 0m;
            troco = 0m;

            if (tabela.Rows.Count == 0)
            {
                return;
            }

            var linha = tabela.Rows[0];
            recebido = Convert.ToDecimal(linha["Recebido"]);
            troco = Convert.ToDecimal(linha["Troco"]);
        }

        public int ContarReservasHoje()
        {
            var sql =
                @"SELECT COUNT(*) FROM dbo.Reservas
                  WHERE DataHora >= @InicioDoDia AND DataHora < @FimDoDia
                    AND Estado NOT IN (3, 4)";
            return Convert.ToInt32(Db.ExecuteScalar(sql,
                inicioDoDia(), fimDoDia()));
        }

        public int ContarPedidosAbertosDoFuncionario(int funcionarioId)
        {
            var sql =
                @"SELECT COUNT(*) FROM dbo.Pedidos
                  WHERE Estado = 1 AND FuncionarioAberturaId = @FuncionarioId";
            return Convert.ToInt32(Db.ExecuteScalar(sql,
                new System.Data.SqlClient.SqlParameter("@FuncionarioId", funcionarioId)));
        }

        public int ContarFuncionariosAtivos()
        {
            var sql = "SELECT COUNT(*) FROM dbo.Funcionarios WHERE Ativo = 1";
            return Convert.ToInt32(Db.ExecuteScalar(sql));
        }

        public int ContarEstoqueBaixo()
        {
            var sql =
                @"SELECT COUNT(*) FROM dbo.Ingredientes
                  WHERE Ativo = 1 AND QuantidadeDisponivel <= QuantidadeMinima";
            return Convert.ToInt32(Db.ExecuteScalar(sql));
        }

        public IList<ItemEstoqueBaixo> ObterEstoqueBaixo(int quantidade)
        {
            var sql =
                @"SELECT TOP (@Quantidade) Nome, Unidade, QuantidadeDisponivel, QuantidadeMinima
                  FROM dbo.Ingredientes
                  WHERE Ativo = 1 AND QuantidadeDisponivel <= QuantidadeMinima
                  ORDER BY (QuantidadeDisponivel - QuantidadeMinima) ASC, Nome ASC";

            var tabela = Db.ExecuteDataTable(sql,
                new System.Data.SqlClient.SqlParameter("@Quantidade", quantidade));

            var lista = new List<ItemEstoqueBaixo>();
            foreach (System.Data.DataRow linha in tabela.Rows)
            {
                lista.Add(new ItemEstoqueBaixo
                {
                    Nome = Convert.ToString(linha["Nome"]),
                    Unidade = Convert.ToString(linha["Unidade"]),
                    QuantidadeDisponivel = Convert.ToDecimal(linha["QuantidadeDisponivel"]),
                    QuantidadeMinima = Convert.ToDecimal(linha["QuantidadeMinima"])
                });
            }

            return lista;
        }

        public IList<ItemReservaProxima> ObterReservasProximas(DateTime de, DateTime ate, int quantidade)
        {
            var sql =
                @"SELECT TOP (@Quantidade) r.Id, r.DataHora, r.NumeroPessoas, r.MesaId, r.Estado,
                                c.NomeCompleto, c.Telefone, m.Numero AS MesaNumero
                  FROM dbo.Reservas r
                  INNER JOIN dbo.Clientes c ON c.Id = r.ClienteId
                  LEFT  JOIN dbo.Mesas m ON m.Id = r.MesaId
                  WHERE r.DataHora >= @De AND r.DataHora < @Ate
                    AND r.Estado NOT IN (3, 4)
                  ORDER BY r.DataHora ASC";

            var tabela = Db.ExecuteDataTable(sql,
                new System.Data.SqlClient.SqlParameter("@Quantidade", quantidade),
                new System.Data.SqlClient.SqlParameter("@De", de),
                new System.Data.SqlClient.SqlParameter("@Ate", ate));

            var lista = new List<ItemReservaProxima>();
            foreach (System.Data.DataRow linha in tabela.Rows)
            {
                lista.Add(new ItemReservaProxima
                {
                    ReservaId = Convert.ToInt32(linha["Id"]),
                    ClienteNome = Convert.ToString(linha["NomeCompleto"]),
                    ClienteTelefone = Convert.ToString(linha["Telefone"]),
                    DataHora = Convert.ToDateTime(linha["DataHora"]),
                    NumeroPessoas = Convert.ToInt32(linha["NumeroPessoas"]),
                    MesaNumero = linha["MesaNumero"] == DBNull.Value
                        ? (int?)null
                        : Convert.ToInt32(linha["MesaNumero"]),
                    Estado = (EstadoReserva)Convert.ToInt32(linha["Estado"])
                });
            }

            return lista;
        }

        public IList<ItemAtendimento> ObterAtendimentosAbertos(int funcionarioId, int quantidade)
        {
            var sql =
                @"SELECT TOP (@Quantidade) pe.Id, pe.ValorTotal, pe.DataAbertura,
                                pe.FuncionarioAberturaId, m.Numero AS MesaNumero, c.NomeCompleto
                  FROM dbo.Pedidos pe
                  INNER JOIN dbo.Mesas m ON m.Id = pe.MesaId
                  LEFT  JOIN dbo.Clientes c ON c.Id = pe.ClienteId
                  WHERE pe.Estado = 1
                  ORDER BY CASE WHEN pe.FuncionarioAberturaId = @FuncionarioId THEN 0 ELSE 1 END,
                           pe.DataAbertura ASC";

            var tabela = Db.ExecuteDataTable(sql,
                new System.Data.SqlClient.SqlParameter("@Quantidade", quantidade),
                new System.Data.SqlClient.SqlParameter("@FuncionarioId", funcionarioId));

            var agora = DateTime.Now;
            var lista = new List<ItemAtendimento>();
            foreach (System.Data.DataRow linha in tabela.Rows)
            {
                var abertura = Convert.ToDateTime(linha["DataAbertura"]);
                lista.Add(new ItemAtendimento
                {
                    PedidoId = Convert.ToInt32(linha["Id"]),
                    MesaNumero = Convert.ToInt32(linha["MesaNumero"]),
                    ClienteNome = linha["NomeCompleto"] == DBNull.Value
                        ? null
                        : Convert.ToString(linha["NomeCompleto"]),
                    ValorTotal = Convert.ToDecimal(linha["ValorTotal"]),
                    DataAbertura = abertura,
                    TempoDecorrido = agora - abertura,
                    MeuAtendimento = Convert.ToInt32(linha["FuncionarioAberturaId"]) == funcionarioId
                });
            }

            return lista;
        }

        public int[] ContarMesasPorEstado()
        {
            // indices: 0 Livre, 1 Ocupada, 2 Reservada, 3 EmAtendimento, 4 AguardandoPagamento
            var sql =
                @"SELECT Estado, COUNT(*) AS Total
                  FROM dbo.Mesas
                  WHERE Ativo = 1
                  GROUP BY Estado";

            var tabela = Db.ExecuteDataTable(sql);
            var contagem = new int[5];

            foreach (System.Data.DataRow linha in tabela.Rows)
            {
                var estado = Convert.ToInt32(linha["Estado"]);
                if (estado >= 0 && estado < contagem.Length)
                {
                    contagem[estado] = Convert.ToInt32(linha["Total"]);
                }
            }

            return contagem;
        }

        public int ContarTotalMesas()
        {
            var sql = "SELECT COUNT(*) FROM dbo.Mesas WHERE Ativo = 1";
            return Convert.ToInt32(Db.ExecuteScalar(sql));
        }

        public int ContarPratos(bool disponiveis)
        {
            var sql =
                @"SELECT COUNT(*) FROM dbo.Pratos
                  WHERE Ativo = 1 AND Disponivel = @Disponivel";
            return Convert.ToInt32(Db.ExecuteScalar(sql,
                new System.Data.SqlClient.SqlParameter("@Disponivel", disponiveis)));
        }

        public IList<ItemTopPrato> ObterTopPratos(int quantidade)
        {
            var sql =
                @"SELECT TOP (@Quantidade) pr.Nome,
                                SUM(i.Quantidade) AS Quantidade,
                                SUM(i.Subtotal) AS Faturamento
                  FROM dbo.ItensPedido i
                  INNER JOIN dbo.Pratos pr ON pr.Id = i.PratoId
                  INNER JOIN dbo.Pedidos pe ON pe.Id = i.PedidoId
                  WHERE pe.Estado = 2
                  GROUP BY pr.Nome
                  ORDER BY SUM(i.Quantidade) DESC, SUM(i.Subtotal) DESC";

            var tabela = Db.ExecuteDataTable(sql,
                new System.Data.SqlClient.SqlParameter("@Quantidade", quantidade));

            var lista = new List<ItemTopPrato>();
            foreach (System.Data.DataRow linha in tabela.Rows)
            {
                lista.Add(new ItemTopPrato
                {
                    Nome = Convert.ToString(linha["Nome"]),
                    Quantidade = Convert.ToInt32(linha["Quantidade"]),
                    Faturamento = Convert.ToDecimal(linha["Faturamento"])
                });
            }

            return lista;
        }

        private static System.Data.SqlClient.SqlParameter inicioDoDia()
        {
            return new System.Data.SqlClient.SqlParameter("@InicioDoDia", DateTime.Today);
        }

        private static System.Data.SqlClient.SqlParameter fimDoDia()
        {
            return new System.Data.SqlClient.SqlParameter("@FimDoDia", DateTime.Today.AddDays(1));
        }
    }
}
