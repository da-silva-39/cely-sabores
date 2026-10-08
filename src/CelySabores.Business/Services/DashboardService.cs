using System;
using CelySabores.Business.Exceptions;
using CelySabores.Business.Security;
using CelySabores.Data.Repositories;
using CelySabores.Models.Dtos;
using CelySabores.Models.Enums;

namespace CelySabores.Business.Services
{
    public class DashboardService
    {
        private const int QuantidadeTopPratos = 5;
        private const int QuantidadeEstoqueBaixo = 5;
        private const int QuantidadeAtendimentos = 8;
        private const int QuantidadeReservasProximas = 8;
        private const int JanelaReservasHoras = 4;

        private readonly DashboardRepository _dashboardRepository;

        public DashboardService(DashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        /// <summary>
        /// Dashboard administrativo. Exclusivo do gerente: mesmo que um funcionario
        /// chegue aqui por qualquer via, a regra de negocio bloqueia (requisito 21).
        /// </summary>
        public ResumoDashboard ObterResumo()
        {
            ContextoPermissao.ExigirGerente();

            var resumo = new ResumoDashboard
            {
                GeradoEm = DateTime.Now
            };

            resumo.PedidosAbertos = _dashboardRepository.ContarPedidosAbertos();
            resumo.PedidosFechadosHoje = _dashboardRepository.ContarPedidosFechadosHoje();
            resumo.PedidosCanceladosHoje = _dashboardRepository.ContarPedidosCanceladosHoje();
            resumo.FaturamentoHoje = _dashboardRepository.FaturamentoHoje();
            resumo.ValorEmAberto = _dashboardRepository.ValorEmAberto();

            decimal recebido;
            decimal troco;
            _dashboardRepository.ObterRecebidoHoje(out recebido, out troco);
            resumo.TotalRecebidoHoje = recebido;
            resumo.TrocoHoje = troco;

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

            resumo.ReservasHoje = _dashboardRepository.ContarReservasHoje();
            resumo.FuncionariosAtivos = _dashboardRepository.ContarFuncionariosAtivos();
            resumo.IngredientesEstoqueBaixo = _dashboardRepository.ContarEstoqueBaixo();

            if (resumo.PedidosFechadosHoje > 0)
            {
                resumo.TicketMedioHoje =
                    Math.Round(resumo.FaturamentoHoje / resumo.PedidosFechadosHoje, 2);
            }

            foreach (var item in _dashboardRepository.ObterTopPratos(QuantidadeTopPratos))
            {
                resumo.TopPratos.Add(item);
            }

            foreach (var item in _dashboardRepository.ObterEstoqueBaixo(QuantidadeEstoqueBaixo))
            {
                resumo.EstoqueBaixo.Add(item);
            }

            return resumo;
        }

        /// <summary>
        /// Dashboard operacional do atendente. Exige sessao, mas nao exige gerente:
        /// nao devolve nenhum dado administrativo (requisito 15).
        /// </summary>
        public ResumoOperacional ObterResumoOperacional()
        {
            var sessao = ContextoPermissao.UsuarioAtual;
            if (sessao == null)
            {
                throw new RegraNegocioException("A sessão expirou. Efetue o login novamente.");
            }

            var resumo = new ResumoOperacional
            {
                GeradoEm = DateTime.Now
            };

            var mesas = _dashboardRepository.ContarMesasPorEstado();
            resumo.TotalMesas = _dashboardRepository.ContarTotalMesas();
            resumo.MesasLivres = mesas[(int)EstadoMesa.Livre];
            resumo.MesasEmAtendimento = mesas[(int)EstadoMesa.EmAtendimento];
            resumo.MesasAguardandoPagamento = mesas[(int)EstadoMesa.AguardandoPagamento];
            resumo.MesasReservadas = mesas[(int)EstadoMesa.Reservada];

            resumo.PedidosAbertos = _dashboardRepository.ContarPedidosAbertos();
            resumo.MeusPedidosAbertos =
                _dashboardRepository.ContarPedidosAbertosDoFuncionario(sessao.IdFuncionario);

            var agora = DateTime.Now;
            var proximas = _dashboardRepository.ObterReservasProximas(
                agora, agora.AddHours(JanelaReservasHoras), QuantidadeReservasProximas);

            foreach (var reserva in proximas)
            {
                resumo.ReservasProximas.Add(reserva);
            }

            resumo.ReservasProximasTotal = proximas.Count;
            if (proximas.Count > 0)
            {
                var minutos = (int)Math.Ceiling((proximas[0].DataHora - agora).TotalMinutes);
                resumo.MinutosParaProximaReserva = minutos < 0 ? 0 : minutos;
            }

            foreach (var atendimento in
                _dashboardRepository.ObterAtendimentosAbertos(sessao.IdFuncionario, QuantidadeAtendimentos))
            {
                resumo.Atendimentos.Add(atendimento);
            }

            return resumo;
        }
    }
}
