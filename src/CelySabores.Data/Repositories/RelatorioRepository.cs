using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CelySabores.Data.Database;
using CelySabores.Models.Dtos;
using CelySabores.Models.Entities;
using CelySabores.Models.Enums;

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

        // ---------------------------------------------------------------
        // Reservas
        // ---------------------------------------------------------------

        public void ObterTotaisReservas(DateTime de, DateTime ate, RelatorioReservas destino)
        {
            // A reserva e contada pela sua propria data/hora (DataHora), tal como
            // as vendas sao contadas pela data de encerramento e nao pela do
            // pedido. Estado: 0 Pendente, 1 Confirmada, 2 EmAtendimento,
            // 3 Concluida, 4 Cancelada.
            const string sql =
                @"SELECT
                    (SELECT COUNT(*) FROM Reservas
                      WHERE DataHora >= @De AND DataHora < @Fim) AS Total,
                    (SELECT COUNT(*) FROM Reservas
                      WHERE Estado = 1 AND DataHora >= @De AND DataHora < @Fim) AS Confirmadas,
                    (SELECT COUNT(*) FROM Reservas
                      WHERE Estado IN (2, 3) AND DataHora >= @De AND DataHora < @Fim) AS Compareceram,
                    (SELECT COUNT(*) FROM Reservas
                      WHERE Estado = 4 AND DataHora >= @De AND DataHora < @Fim) AS Canceladas,
                    (SELECT ISNULL(SUM(NumeroPessoas), 0) FROM Reservas
                      WHERE Estado <> 4 AND DataHora >= @De AND DataHora < @Fim) AS PessoasPrevistas,
                    (SELECT ISNULL(SUM(NumeroPessoas), 0) FROM Reservas
                      WHERE Estado = 4 AND DataHora >= @De AND DataHora < @Fim) AS PessoasPerdidas";

            var tabela = Db.ExecuteDataTable(sql,
                new SqlParameter("@De", de),
                new SqlParameter("@Fim", AteMaisUmDia(ate)));

            var linha = tabela.Rows[0];
            destino.Total = Leitor.Int(linha, "Total");
            destino.Confirmadas = Leitor.Int(linha, "Confirmadas");
            destino.Compareceram = Leitor.Int(linha, "Compareceram");
            destino.Canceladas = Leitor.Int(linha, "Canceladas");
            destino.PessoasPrevistas = Leitor.Int(linha, "PessoasPrevistas");
            destino.PessoasPerdidas = Leitor.Int(linha, "PessoasPerdidas");
        }

        public IList<ReservaPorDia> ReservasPorDia(DateTime de, DateTime ate)
        {
            const string sql =
                @"SELECT CAST(DataHora AS DATE) AS Dia,
                    COUNT(*) AS Reservas,
                    ISNULL(SUM(NumeroPessoas), 0) AS Pessoas,
                    SUM(CASE WHEN Estado = 1 THEN 1 ELSE 0 END) AS Confirmadas,
                    SUM(CASE WHEN Estado IN (2, 3) THEN 1 ELSE 0 END) AS Compareceram,
                    SUM(CASE WHEN Estado = 4 THEN 1 ELSE 0 END) AS Canceladas
                  FROM Reservas
                  WHERE DataHora >= @De AND DataHora < @Fim
                  GROUP BY CAST(DataHora AS DATE)
                  ORDER BY Dia";

            var tabela = Db.ExecuteDataTable(sql,
                new SqlParameter("@De", de),
                new SqlParameter("@Fim", AteMaisUmDia(ate)));

            var lista = new List<ReservaPorDia>();

            foreach (System.Data.DataRow linha in tabela.Rows)
            {
                lista.Add(new ReservaPorDia
                {
                    Dia = Leitor.DateTime(linha, "Dia"),
                    Reservas = Leitor.Int(linha, "Reservas"),
                    Pessoas = Leitor.Int(linha, "Pessoas"),
                    Confirmadas = Leitor.Int(linha, "Confirmadas"),
                    Compareceram = Leitor.Int(linha, "Compareceram"),
                    Canceladas = Leitor.Int(linha, "Canceladas")
                });
            }

            return lista;
        }

        public IList<ReservaPorEstado> ReservasPorEstado(DateTime de, DateTime ate)
        {
            const string sql =
                @"SELECT Estado,
                    COUNT(*) AS Reservas,
                    ISNULL(SUM(NumeroPessoas), 0) AS Pessoas
                  FROM Reservas
                  WHERE DataHora >= @De AND DataHora < @Fim
                  GROUP BY Estado";

            var tabela = Db.ExecuteDataTable(sql,
                new SqlParameter("@De", de),
                new SqlParameter("@Fim", AteMaisUmDia(ate)));

            var lista = new List<ReservaPorEstado>();

            foreach (System.Data.DataRow linha in tabela.Rows)
            {
                var estado = (EstadoReserva)Leitor.Int(linha, "Estado");

                lista.Add(new ReservaPorEstado
                {
                    Estado = estado.ToString(),
                    Reservas = Leitor.Int(linha, "Reservas"),
                    Pessoas = Leitor.Int(linha, "Pessoas")
                });
            }

            // ordem logica do processo, nao a ordem alfabetica do SQL
            lista.Sort(delegate (ReservaPorEstado a, ReservaPorEstado b)
            {
                return OrdemEstado(a.Estado).CompareTo(OrdemEstado(b.Estado));
            });

            return lista;
        }

        private static int OrdemEstado(string nome)
        {
            EstadoReserva estado;
            return Enum.TryParse(nome, out estado) ? (int)estado : int.MaxValue;
        }

        // ---------------------------------------------------------------
        // Mesas
        // ---------------------------------------------------------------

        public void ObterTotaisMesas(DateTime de, DateTime ate, RelatorioMesas destino)
        {
            // MesasAtivas / MesasOcupadasAgora sao fotografia do momento;
            // as restantes metricas respeitam o intervalo escolhido.
            const string sql =
                @"SELECT
                    (SELECT COUNT(*) FROM Mesas WHERE Ativo = 1) AS MesasAtivas,
                    (SELECT COUNT(*) FROM Mesas WHERE Ativo = 1 AND Estado <> 0) AS MesasOcupadasAgora,
                    (SELECT COUNT(DISTINCT p.MesaId) FROM Pedidos p
                      WHERE p.Estado = 2 AND p.DataFechamento >= @De AND p.DataFechamento < @Fim) AS MesasUtilizadas,
                    (SELECT COUNT(*) FROM Pedidos
                      WHERE Estado = 2 AND DataFechamento >= @De AND DataFechamento < @Fim) AS Pedidos,
                    (SELECT ISNULL(SUM(ValorTotal), 0) FROM Pedidos
                      WHERE Estado = 2 AND DataFechamento >= @De AND DataFechamento < @Fim) AS Faturamento";

            var tabela = Db.ExecuteDataTable(sql,
                new SqlParameter("@De", de),
                new SqlParameter("@Fim", AteMaisUmDia(ate)));

            var linha = tabela.Rows[0];
            destino.MesasAtivas = Leitor.Int(linha, "MesasAtivas");
            destino.MesasOcupadasAgora = Leitor.Int(linha, "MesasOcupadasAgora");
            destino.MesasUtilizadas = Leitor.Int(linha, "MesasUtilizadas");

            var pedidos = Leitor.Int(linha, "Pedidos");
            destino.Faturamento = Leitor.Decimal(linha, "Faturamento");

            if (pedidos > 0)
            {
                destino.TicketMedio = Math.Round(destino.Faturamento / pedidos, 2);
            }
        }

        public IList<MesaUtilizada> MesasUtilizadas(DateTime de, DateTime ate)
        {
            const string sql =
                @"SELECT m.Id AS IdMesa,
                    m.Numero AS Numero,
                    m.Capacidade AS Capacidade,
                    COUNT(*) AS Pedidos,
                    ISNULL(SUM(p.ValorTotal), 0) AS Faturamento
                  FROM Pedidos p
                  INNER JOIN Mesas m ON m.Id = p.MesaId
                  WHERE p.Estado = 2 AND p.DataFechamento >= @De AND p.DataFechamento < @Fim
                  GROUP BY m.Id, m.Numero, m.Capacidade
                  ORDER BY Faturamento DESC, m.Numero";

            var tabela = Db.ExecuteDataTable(sql,
                new SqlParameter("@De", de),
                new SqlParameter("@Fim", AteMaisUmDia(ate)));

            var lista = new List<MesaUtilizada>();

            foreach (System.Data.DataRow linha in tabela.Rows)
            {
                var pedidos = Leitor.Int(linha, "Pedidos");
                var faturamento = Leitor.Decimal(linha, "Faturamento");

                lista.Add(new MesaUtilizada
                {
                    IdMesa = Leitor.Int(linha, "IdMesa"),
                    Numero = Leitor.Int(linha, "Numero"),
                    Capacidade = Leitor.Int(linha, "Capacidade"),
                    Pedidos = pedidos,
                    Faturamento = faturamento,
                    TicketMedio = pedidos > 0 ? Math.Round(faturamento / pedidos, 2) : 0m
                });
            }

            return lista;
        }

        // ---------------------------------------------------------------
        // Estoque
        // ---------------------------------------------------------------

        public IList<Ingrediente> ListarEstoqueBaixo()
        {
            // o mesmo criterio do painel de estoque: so conta quem tem minimo
            // definido, para nao marcar como "baixo" o que apenas esta a zero
            const string sql =
                @"SELECT Id, Nome, Unidade, QuantidadeDisponivel, QuantidadeMinima, PrecoCusto, Ativo
                  FROM Ingredientes
                  WHERE Ativo = 1 AND QuantidadeMinima > 0 AND QuantidadeDisponivel <= QuantidadeMinima
                  ORDER BY (QuantidadeDisponivel - QuantidadeMinima), Nome";

            var tabela = Db.ExecuteDataTable(sql);
            var lista = new List<Ingrediente>();

            foreach (System.Data.DataRow linha in tabela.Rows)
            {
                lista.Add(new Ingrediente
                {
                    Id = Leitor.Int(linha, "Id"),
                    Nome = Leitor.String(linha, "Nome"),
                    Unidade = Leitor.String(linha, "Unidade"),
                    QuantidadeDisponivel = Leitor.Decimal(linha, "QuantidadeDisponivel"),
                    QuantidadeMinima = Leitor.Decimal(linha, "QuantidadeMinima"),
                    PrecoCusto = Leitor.Decimal(linha, "PrecoCusto"),
                    Ativo = Leitor.Bool(linha, "Ativo")
                });
            }

            return lista;
        }

        public int ContarIngredientesActivos()
        {
            const string sql = "SELECT COUNT(*) AS Total FROM Ingredientes WHERE Ativo = 1";
            return Leitor.Int(Db.ExecuteDataTable(sql).Rows[0], "Total");
        }
    }
}
