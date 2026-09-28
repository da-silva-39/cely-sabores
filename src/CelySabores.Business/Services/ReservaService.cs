using System;
using System.Collections.Generic;
using CelySabores.Business.Exceptions;
using CelySabores.Business.Security;
using CelySabores.Business.Validators;
using CelySabores.Data.Repositories;
using CelySabores.Models.Entities;
using CelySabores.Models.Enums;

namespace CelySabores.Business.Services
{
    public class ReservaService
    {
        private readonly ReservaRepository _reservaRepository;
        private readonly MesaRepository _mesaRepository;
        private readonly ClienteRepository _clienteRepository;

        public ReservaService(ReservaRepository reservaRepository, MesaRepository mesaRepository,
            ClienteRepository clienteRepository)
        {
            _reservaRepository = reservaRepository;
            _mesaRepository = mesaRepository;
            _clienteRepository = clienteRepository;
        }

        public IList<Reserva> Listar(DateTime? de, DateTime? ate, EstadoReserva? estado)
        {
            return _reservaRepository.Listar(de, ate, estado);
        }

        public IList<Reserva> ListarDoDia(DateTime dia)
        {
            return _reservaRepository.Listar(dia.Date, dia.Date.AddDays(1).AddSeconds(-1), null);
        }

        public Reserva ObterPorId(int id)
        {
            var reserva = _reservaRepository.ObterPorId(id);
            if (reserva == null)
            {
                throw new RegraNegocioException("Reserva não encontrada.");
            }

            return reserva;
        }

        public IList<Mesa> ListarMesasLivresPara(DateTime dataHora, int numeroPessoas)
        {
            var mesas = _mesaRepository.Listar(true);
            var resultado = new List<Mesa>();

            foreach (var mesa in mesas)
            {
                if (numeroPessoas > 0 && mesa.Capacidade < numeroPessoas)
                {
                    continue;
                }

                if (!_reservaRepository.MesaOcupadaNoHorario(mesa.Id, dataHora))
                {
                    resultado.Add(mesa);
                }
            }

            return resultado;
        }

        public Reserva Criar(int clienteId, int? mesaId, DateTime dataHora, int numeroPessoas, string observacao)
        {
            ExigirSessao();

            numeroPessoas = Validacoes.Positivo(numeroPessoas, "número de pessoas");
            ValidarDataHora(dataHora, permitirPassado: false);

            if (_clienteRepository.ObterPorId(clienteId) == null)
            {
                throw new RegraNegocioException("Cliente não encontrado.");
            }

            ValidarMesa(mesaId, dataHora, numeroPessoas, ignorarId: null);

            var reserva = new Reserva
            {
                ClienteId = clienteId,
                MesaId = mesaId,
                DataHora = dataHora,
                NumeroPessoas = numeroPessoas,
                Estado = EstadoReserva.Pendente,
                Observacoes = Validacoes.Opcional(observacao)
            };

            reserva.Id = _reservaRepository.Inserir(reserva);
            return ObterPorId(reserva.Id);
        }

        public void Atualizar(int id, int? mesaId, DateTime dataHora, int numeroPessoas, string observacao)
        {
            ExigirSessao();

            var reserva = ObterPorId(id);
            ExigirEstado(reserva, EstadoReserva.Pendente, EstadoReserva.Confirmada,
                "Só se podem alterar reservas pendentes ou confirmadas.");

            numeroPessoas = Validacoes.Positivo(numeroPessoas, "número de pessoas");
            ValidarDataHora(dataHora, permitirPassado: false);

            if (_clienteRepository.ObterPorId(reserva.ClienteId) == null)
            {
                throw new RegraNegocioException("Cliente não encontrado.");
            }

            ValidarMesa(mesaId, dataHora, numeroPessoas, ignorarId: id);

            reserva.MesaId = mesaId;
            reserva.DataHora = dataHora;
            reserva.NumeroPessoas = numeroPessoas;
            reserva.Observacoes = Validacoes.Opcional(observacao);

            _reservaRepository.Atualizar(reserva);
        }

        public void Confirmar(int id)
        {
            ExigirSessao();

            var reserva = ObterPorId(id);
            if (reserva.Estado != EstadoReserva.Pendente)
            {
                throw new RegraNegocioException("Só se podem confirmar reservas pendentes.");
            }

            ValidarDataHora(reserva.DataHora, permitirPassado: false);
            _reservaRepository.AlterarEstado(id, EstadoReserva.Confirmada);
        }

        public void IniciarAtendimento(int id)
        {
            ExigirSessao();

            var reserva = ObterPorId(id);
            if (reserva.Estado != EstadoReserva.Confirmada)
            {
                throw new RegraNegocioException("Só se podem iniciar reservas confirmadas.");
            }

            _reservaRepository.AlterarEstado(id, EstadoReserva.EmAtendimento);

            if (reserva.MesaId.HasValue)
            {
                var mesa = _mesaRepository.ObterPorId(reserva.MesaId.Value);
                if (mesa != null && mesa.Ativo && mesa.Estado == EstadoMesa.Livre)
                {
                    _mesaRepository.AlterarEstado(mesa.Id, EstadoMesa.EmAtendimento);
                }
            }
        }

        public void Concluir(int id)
        {
            ExigirSessao();

            var reserva = ObterPorId(id);
            if (reserva.Estado != EstadoReserva.EmAtendimento)
            {
                throw new RegraNegocioException("Só se podem concluir reservas em atendimento.");
            }

            _reservaRepository.AlterarEstado(id, EstadoReserva.Concluida);
            LibertarMesa(reserva);
        }

        public void Cancelar(int id)
        {
            ExigirSessao();

            var reserva = ObterPorId(id);
            ExigirEstado(reserva, EstadoReserva.Pendente, EstadoReserva.Confirmada, EstadoReserva.EmAtendimento,
                "Esta reserva já está concluída ou cancelada.");

            _reservaRepository.AlterarEstado(id, EstadoReserva.Cancelada);
            LibertarMesa(reserva);
        }

        private void LibertarMesa(Reserva reserva)
        {
            if (!reserva.MesaId.HasValue)
            {
                return;
            }

            var mesa = _mesaRepository.ObterPorId(reserva.MesaId.Value);
            if (mesa != null && mesa.Estado == EstadoMesa.EmAtendimento)
            {
                _mesaRepository.AlterarEstado(mesa.Id, EstadoMesa.Livre);
            }
        }

        private void ValidarMesa(int? mesaId, DateTime dataHora, int numeroPessoas, int? ignorarId)
        {
            if (!mesaId.HasValue)
            {
                return;
            }

            var mesa = _mesaRepository.ObterPorId(mesaId.Value);
            if (mesa == null)
            {
                throw new RegraNegocioException("Mesa não encontrada.");
            }

            if (!mesa.Ativo)
            {
                throw new RegraNegocioException("A mesa " + mesa.Numero + " está inactiva.");
            }

            if (mesa.Capacidade < numeroPessoas)
            {
                throw new RegraNegocioException(
                    "A mesa " + mesa.Numero + " só tem " + mesa.Capacidade + " lugares.");
            }

            if (_reservaRepository.MesaOcupadaNoHorario(mesaId.Value, dataHora))
            {
                var conflito = _reservaRepository.Listar(
                    dataHora.AddHours(-2), dataHora.AddHours(2), null);

                foreach (var outra in conflito)
                {
                    if (outra.MesaId == mesaId && outra.Estado != EstadoReserva.Cancelada
                        && outra.Estado != EstadoReserva.Concluida
                        && (ignorarId == null || outra.Id != ignorarId.Value))
                    {
                        throw new RegraNegocioException(
                            "A mesa " + mesa.Numero + " já está reservada para as "
                            + outra.DataHora.ToString("dd/MM HH:mm") + ".");
                    }
                }
            }
        }

        private static void ValidarDataHora(DateTime dataHora, bool permitirPassado)
        {
            if (dataHora == default(DateTime))
            {
                throw new RegraNegocioException("Escolha a data e hora da reserva.");
            }

            if (!permitirPassado && dataHora < DateTime.Now.AddHours(-1))
            {
                throw new RegraNegocioException("A data da reserva já passou.");
            }
        }

        private static void ExigirEstado(Reserva reserva, EstadoReserva esperado, string mensagem)
        {
            if (reserva.Estado != esperado)
            {
                throw new RegraNegocioException(mensagem);
            }
        }

        private static void ExigirEstado(Reserva reserva, EstadoReserva p1, EstadoReserva p2, string mensagem)
        {
            if (reserva.Estado != p1 && reserva.Estado != p2)
            {
                throw new RegraNegocioException(mensagem);
            }
        }

        private static void ExigirEstado(Reserva reserva, EstadoReserva p1, EstadoReserva p2,
            EstadoReserva p3, string mensagem)
        {
            if (reserva.Estado != p1 && reserva.Estado != p2 && reserva.Estado != p3)
            {
                throw new RegraNegocioException(mensagem);
            }
        }

        private static void ExigirSessao()
        {
            if (ContextoPermissao.UsuarioAtual == null)
            {
                throw new RegraNegocioException("A sessão expirou. Efetue o login novamente.");
            }
        }
    }
}
