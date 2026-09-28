using System;
using CelySabores.Business.Exceptions;
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

        public RelatorioVendas Gerar(DateTime de, DateTime ate)
        {
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
            var relatorio = new RelatorioVendas
            {
                De = inicio,
                Ate = ate.Date,
                GeradoEm = DateTime.Now
            };

            _relatorioRepository.ObterTotais(inicio, ate.Date, relatorio);
            relatorio.PorDia = _relatorioRepository.PorDia(inicio, ate.Date);
            relatorio.PorFuncionario = _relatorioRepository.PorFuncionario(inicio, ate.Date);
            relatorio.PorPrato = _relatorioRepository.PorPrato(inicio, ate.Date);

            if (relatorio.PedidosFechados > 0)
            {
                relatorio.TicketMedio = Math.Round(
                    relatorio.Faturamento / relatorio.PedidosFechados, 2);
            }

            if (relatorio.ItensVendidos > 0)
            {
                relatorio.ValorMedioPrato = Math.Round(
                    relatorio.Faturamento / relatorio.ItensVendidos, 2);
            }

            return relatorio;
        }
    }
}
