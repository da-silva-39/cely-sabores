using System;
using CelySabores.Data.Repositories;
using CelySabores.Models.Dtos;
using CelySabores.Models.Enums;

namespace CelySabores.Business.Services
{
    public class DashboardService
    {
        private const int QuantidadeTopPratos = 5;

        private readonly DashboardRepository _dashboardRepository;

        public DashboardService(DashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public ResumoDashboard ObterResumo()
        {
            var resumo = new ResumoDashboard
            {
                GeradoEm = DateTime.Now
            };

            resumo.PedidosAbertos = _dashboardRepository.ContarPedidosAbertos();
            resumo.PedidosFechadosHoje = _dashboardRepository.ContarPedidosFechadosHoje();
            resumo.PedidosCanceladosHoje = _dashboardRepository.ContarPedidosCanceladosHoje();
            resumo.FaturamentoHoje = _dashboardRepository.FaturamentoHoje();
            resumo.ValorEmAberto = _dashboardRepository.ValorEmAberto();

            var mesas = _dashboardRepository.ContarMesasPorEstado();
            resumo.TotalMesas = _dashboardRepository.ContarTotalMesas();
            resumo.MesasLivres = mesas[(int)EstadoMesa.Livre];
            resumo.MesasOcupadas =
                mesas[(int)EstadoMesa.Ocupada]
                + mesas[(int)EstadoMesa.EmAtendimento]
                + mesas[(int)EstadoMesa.AguardandoPagamento];
            resumo.MesasReservadas = mesas[(int)EstadoMesa.Reservada];

            resumo.PratosDisponiveis = _dashboardRepository.ContarPratos(true);
            resumo.PratosIndisponiveis = _dashboardRepository.ContarPratos(false);

            if (resumo.PedidosFechadosHoje > 0)
            {
                resumo.TicketMedioHoje =
                    Math.Round(resumo.FaturamentoHoje / resumo.PedidosFechadosHoje, 2);
            }

            foreach (var item in _dashboardRepository.ObterTopPratos(QuantidadeTopPratos))
            {
                resumo.TopPratos.Add(item);
            }

            return resumo;
        }
    }
}
