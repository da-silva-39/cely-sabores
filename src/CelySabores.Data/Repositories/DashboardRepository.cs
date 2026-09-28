using System;
using System.Collections.Generic;
using CelySabores.Data.Database;
using CelySabores.Models.Dtos;

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
    }
}
