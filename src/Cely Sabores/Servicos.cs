using CelySabores.Business.Services;
using CelySabores.Data.Connections;
using CelySabores.Data.Database;
using CelySabores.Data.Repositories;

namespace Cely_Sabores
{
    public static class Servicos
    {
        private static readonly SqlConnectionFactory Fabrica = new SqlConnectionFactory();

        private static CommandHelper NovoDb()
        {
            return new CommandHelper(Fabrica);
        }

        public static DashboardService Dashboard()
        {
            return new DashboardService(new DashboardRepository(NovoDb()));
        }

        public static MesaService Mesas()
        {
            return new MesaService(new MesaRepository(NovoDb()));
        }

        public static FuncionarioService Funcionarios()
        {
            return new FuncionarioService(new FuncionarioRepository(NovoDb()));
        }

        public static CardapioService Cardapio()
        {
            return new CardapioService(new CardapioRepository(NovoDb()));
        }

        public static ClienteService Clientes()
        {
            return new ClienteService(new ClienteRepository(NovoDb()));
        }

        public static PedidoService Pedidos()
        {
            return new PedidoService(
                new PedidoRepository(NovoDb()),
                new MesaRepository(NovoDb()),
                new CardapioRepository(NovoDb()),
                new ClienteRepository(NovoDb()));
        }

        public static ReservaService Reservas()
        {
            return new ReservaService(
                new ReservaRepository(NovoDb()),
                new MesaRepository(NovoDb()),
                new ClienteRepository(NovoDb()));
        }

        public static ReciboService Recibo()
        {
            return new ReciboService(new PedidoRepository(NovoDb()));
        }

        public static EstoqueService Estoque()
        {
            return new EstoqueService(new EstoqueRepository(NovoDb()), new CardapioRepository(NovoDb()));
        }

        public static RelatorioService Relatorios()
        {
            return new RelatorioService(new RelatorioRepository(NovoDb()));
        }
    }
}
