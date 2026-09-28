using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CelySabores.Data.Database;
using CelySabores.Models.Dtos;

namespace CelySabores.Data.Repositories
{
    public class RelatorioRepository : RepositorioBase
    {
        public RelatorioRepository(CommandHelper commandHelper) : base(commandHelper)
        {
        }

        public void ObterTotais(DateTime de, DateTime ate, RelatorioVendas destino)
        {
            // O intervalo e semiaberto: [de, ate + 1 dia)
            const string sql =
                @"SELECT
                    (SELECT COUNT(*) FROM Pedidos
                      WHERE Estado = 2 AND DataFechamento >= @De AND DataFechamento < @Fim) AS PedidosFechados,
                    (SELECT COUNT(*) FROM Pedidos
                      WHERE Estado = 3 AND DataFechamento >= @De AND DataFechamento < @Fim) AS PedidosCancelados,
                    (SELECT ISNULL(SUM(ValorTotal), 0) FROM Pedidos
                      WHERE Estado = 2 AND DataFechamento >= @De AND DataFechamento < @Fim) AS Faturamento,
                    (SELECT ISNULL(SUM(i.Quantidade), 0) FROM ItensPedido i
                      INNER JOIN Pedidos p ON p.Id = i.PedidoId
                      WHERE p.Estado = 2 AND p.DataFechamento >= @De AND p.DataFechamento < @Fim) AS ItensVendidos,
                    (SELECT ISNULL(SUM(pg.ValorRecebido), 0) FROM Pagamentos pg
                      INNER JOIN Pedidos p ON p.Id = pg.PedidoId
                      WHERE p.DataFechamento >= @De AND p.DataFechamento < @Fim) AS TotalRecebido,
                    (SELECT ISNULL(SUM(pg.Troco), 0) FROM Pagamentos pg
                      INNER JOIN Pedidos p ON p.Id = pg.PedidoId
                      WHERE p.DataFechamento >= @De AND p.DataFechamento < @Fim) AS TotalTroco";

            var tabela = Db.ExecuteDataTable(sql,
                new SqlParameter("@De", de),
                new SqlParameter("@Fim", AteMaisUmDia(ate)));

            var linha = tabela.Rows[0];
            destino.PedidosFechados = Leitor.Int(linha, "PedidosFechados");
            destino.PedidosCancelados = Leitor.Int(linha, "PedidosCancelados");
            destino.Faturamento = Leitor.Decimal(linha, "Faturamento");
            destino.ItensVendidos = Leitor.Int(linha, "ItensVendidos");
            destino.TotalRecebido = Leitor.Decimal(linha, "TotalRecebido");
            destino.TotalTroco = Leitor.Decimal(linha, "TotalTroco");
        }

        public IList<VendaPorDia> PorDia(DateTime de, DateTime ate)
        {
            const string sql =
                @"SELECT CAST(p.DataFechamento AS DATE) AS Dia,
                    COUNT(*) AS PedidosFechados,
                    ISNULL(SUM(p.ValorTotal), 0) AS Faturamento
                  FROM Pedidos p
                  WHERE p.Estado = 2 AND p.DataFechamento >= @De AND p.DataFechamento < @Fim
                  GROUP BY CAST(p.DataFechamento AS DATE)
                  ORDER BY Dia";

            var tabela = Db.ExecuteDataTable(sql,
                new SqlParameter("@De", de),
                new SqlParameter("@Fim", AteMaisUmDia(ate)));

            var lista = new List<VendaPorDia>();

            foreach (System.Data.DataRow linha in tabela.Rows)
            {
                var pedidos = Leitor.Int(linha, "PedidosFechados");
                var faturamento = Leitor.Decimal(linha, "Faturamento");

                lista.Add(new VendaPorDia
                {
                    Dia = Leitor.DateTime(linha, "Dia"),
                    PedidosFechados = pedidos,
                    Faturamento = faturamento,
                    TicketMedio = pedidos > 0 ? Math.Round(faturamento / pedidos, 2) : 0m
                });
            }

            return lista;
        }

        public IList<VendaPorFuncionario> PorFuncionario(DateTime de, DateTime ate)
        {
            const string sql =
                @"SELECT f.Id AS IdFuncionario,
                    f.NomeCompleto AS Nome,
                    COUNT(DISTINCT p.Id) AS PedidosFechados,
                    ISNULL(SUM(p.ValorTotal), 0) AS Faturamento,
                    ISNULL((SELECT SUM(pg.ValorRecebido) FROM Pagamentos pg
                      WHERE pg.PedidoId IN (SELECT Id FROM Pedidos
                        WHERE FuncionarioFechamentoId = f.Id
                          AND DataFechamento >= @De AND DataFechamento < @Fim)), 0) AS TotalRecebido,
                    ISNULL((SELECT SUM(pg.Troco) FROM Pagamentos pg
                      WHERE pg.PedidoId IN (SELECT Id FROM Pedidos
                        WHERE FuncionarioFechamentoId = f.Id
                          AND DataFechamento >= @De AND DataFechamento < @Fim)), 0) AS TotalTroco
                  FROM Pedidos p
                  INNER JOIN Funcionarios f ON f.Id = p.FuncionarioFechamentoId
                  WHERE p.Estado = 2 AND p.DataFechamento >= @De AND p.DataFechamento < @Fim
                  GROUP BY f.Id, f.NomeCompleto
                  ORDER BY Faturamento DESC";

            var tabela = Db.ExecuteDataTable(sql,
                new SqlParameter("@De", de),
                new SqlParameter("@Fim", AteMaisUmDia(ate)));

            var lista = new List<VendaPorFuncionario>();

            foreach (System.Data.DataRow linha in tabela.Rows)
            {
                lista.Add(new VendaPorFuncionario
                {
                    IdFuncionario = Leitor.Int(linha, "IdFuncionario"),
                    Nome = Leitor.String(linha, "Nome"),
                    PedidosFechados = Leitor.Int(linha, "PedidosFechados"),
                    Faturamento = Leitor.Decimal(linha, "Faturamento"),
                    TotalRecebido = Leitor.Decimal(linha, "TotalRecebido"),
                    TotalTroco = Leitor.Decimal(linha, "TotalTroco")
                });
            }

            return lista;
        }

        public IList<VendaPorPrato> PorPrato(DateTime de, DateTime ate)
        {
            const string sql =
                @"SELECT pr.Id AS IdPrato,
                    pr.Nome AS Nome,
                    ISNULL(SUM(i.Quantidade), 0) AS Quantidade,
                    ISNULL(SUM(i.Subtotal), 0) AS Faturamento
                  FROM ItensPedido i
                  INNER JOIN Pedidos p ON p.Id = i.PedidoId
                  INNER JOIN Pratos pr ON pr.Id = i.PratoId
                  WHERE p.Estado = 2 AND p.DataFechamento >= @De AND p.DataFechamento < @Fim
                  GROUP BY pr.Id, pr.Nome
                  ORDER BY Faturamento DESC";

            var tabela = Db.ExecuteDataTable(sql,
                new SqlParameter("@De", de),
                new SqlParameter("@Fim", AteMaisUmDia(ate)));

            var lista = new List<VendaPorPrato>();

            foreach (System.Data.DataRow linha in tabela.Rows)
            {
                lista.Add(new VendaPorPrato
                {
                    IdPrato = Leitor.Int(linha, "IdPrato"),
                    Nome = Leitor.String(linha, "Nome"),
                    Quantidade = Leitor.Int(linha, "Quantidade"),
                    Faturamento = Leitor.Decimal(linha, "Faturamento")
                });
            }

            return lista;
        }

        private static DateTime AteMaisUmDia(DateTime ate)
        {
            return ate.Date.AddDays(1);
        }
    }
}
