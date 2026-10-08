using System;
using CelySabores.Business.Exceptions;
using CelySabores.Business.Security;
using CelySabores.Data.Repositories;
using CelySabores.Models.Dtos;

namespace CelySabores.Business.Services
{
    public class RelatorioService
    {
        private readonly RelatorioRepository _relatorioRepository;

        public RelatorioService(RelatorioRepository relatorioRepository)
        {
            _relatorioRepository = relatorioRepository;
        }

        public RelatorioCompleto Gerar(DateTime de, DateTime ate)
        {
            // relatorios sao exclusiva do gerente (requisitos 16 e 21)
            ContextoPermissao.ExigirGerente();

            if (de == default(DateTime) || ate == default(DateTime))
            {
                throw new RegraNegocioException("Escolha o intervalo de datas.");
            }

            if (ate.Date < de.Date)
            {
                throw new RegraNegocioException("A data final é anterior à data inicial.");
            }

            // intervalo semiaberto: apanha tudo desde as 00:00 do primeiro dia
            // ate ao fim do ultimo dia escolhido
            var inicio = de.Date;
            var relatorio = new RelatorioCompleto
            {
                De = inicio,
                Ate = ate.Date,
                GeradoEm = DateTime.Now,
                Vendas = new RelatorioVendas
                {
                    De = inicio,
                    Ate = ate.Date,
                    GeradoEm = DateTime.Now
                },
                Reservas = new RelatorioReservas(),
                Mesas = new RelatorioMesas(),
                Estoque = new RelatorioEstoque()
            };

            PreencherVendas(relatorio.Vendas, inicio, ate.Date);
            PreencherReservas(relatorio.Reservas, inicio, ate.Date);
            PreencherMesas(relatorio.Mesas, inicio, ate.Date);
            PreencherEstoque(relatorio.Estoque);

            return relatorio;
        }

        private void PreencherVendas(RelatorioVendas vendas, DateTime de, DateTime ate)
        {
            _relatorioRepository.ObterTotais(de, ate, vendas);
            vendas.PorDia = _relatorioRepository.PorDia(de, ate);
            vendas.PorFuncionario = _relatorioRepository.PorFuncionario(de, ate);
            vendas.PorPrato = _relatorioRepository.PorPrato(de, ate);

            if (vendas.PedidosFechados > 0)
            {
                vendas.TicketMedio = Math.Round(vendas.Faturamento / vendas.PedidosFechados, 2);
            }

            if (vendas.ItensVendidos > 0)
            {
                vendas.ValorMedioPrato = Math.Round(vendas.Faturamento / vendas.ItensVendidos, 2);
            }
        }

        private void PreencherReservas(RelatorioReservas reservas, DateTime de, DateTime ate)
        {
            _relatorioRepository.ObterTotaisReservas(de, ate, reservas);
            reservas.PorDia = _relatorioRepository.ReservasPorDia(de, ate);
            reservas.PorEstado = _relatorioRepository.ReservasPorEstado(de, ate);
        }

        private void PreencherMesas(RelatorioMesas mesas, DateTime de, DateTime ate)
        {
            _relatorioRepository.ObterTotaisMesas(de, ate, mesas);
            mesas.PorMesa = _relatorioRepository.MesasUtilizadas(de, ate);

            if (mesas.MesasAtivas > 0)
            {
                mesas.PercentagemOcupacao = Math.Round(
                    mesas.MesasUtilizadas * 100m / mesas.MesasAtivas, 1);
            }
        }

        private void PreencherEstoque(RelatorioEstoque estoque)
        {
            // o estoque e uma fotografia do momento, nao respeita o intervalo
            estoque.IngredientesActivos = _relatorioRepository.ContarIngredientesActivos();
            estoque.Baixo = _relatorioRepository.ListarEstoqueBaixo();
            estoque.IngredientesBaixo = estoque.Baixo.Count;

            decimal reposicao = 0m;

            foreach (var ingrediente in estoque.Baixo)
            {
                var falta = ingrediente.QuantidadeMinima - ingrediente.QuantidadeDisponivel;
                reposicao += Math.Round(falta * ingrediente.PrecoCusto, 2);
            }

            estoque.ValorReposicao = reposicao;
        }
    }
}
