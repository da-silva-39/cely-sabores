using System.Collections.Generic;
using CelySabores.Business.Exceptions;
using CelySabores.Business.Security;
using CelySabores.Business.Validators;
using CelySabores.Data.Repositories;
using CelySabores.Models.Entities;
using CelySabores.Models.Enums;

namespace CelySabores.Business.Services
{
    public class MesaService
    {
        private readonly MesaRepository _mesaRepository;

        public MesaService(MesaRepository mesaRepository)
        {
            _mesaRepository = mesaRepository;
        }

        public IList<Mesa> Listar(bool apenasAtivas)
        {
            return _mesaRepository.Listar(apenasAtivas);
        }

        public Mesa ObterPorId(int id)
        {
            return _mesaRepository.ObterPorId(id);
        }

        public Mesa Inserir(Mesa mesa)
        {
            ContextoPermissao.ExigirGerente();
            Validar(mesa);

            mesa.Observacoes = Validacoes.Opcional(mesa.Observacoes);
            mesa.Estado = EstadoMesa.Livre;
            mesa.Ativo = true;

            mesa.Id = _mesaRepository.Inserir(mesa);
            return mesa;
        }

        public void Atualizar(Mesa mesa)
        {
            ContextoPermissao.ExigirGerente();
            Validar(mesa);

            mesa.Observacoes = Validacoes.Opcional(mesa.Observacoes);
            _mesaRepository.Atualizar(mesa);
        }

        public void AlterarEstado(int id, EstadoMesa estado)
        {
            var mesa = _mesaRepository.ObterPorId(id);
            if (mesa == null)
            {
                throw new RegraNegocioException("Mesa não encontrada.");
            }

            if (!mesa.Ativo)
            {
                throw new RegraNegocioException("A mesa " + mesa.Numero + " está inativa.");
            }

            _mesaRepository.AlterarEstado(id, estado);
        }

        public void AlterarAtivo(int id, bool ativo)
        {
            ContextoPermissao.ExigirGerente();

            var mesa = _mesaRepository.ObterPorId(id);
            if (mesa == null)
            {
                throw new RegraNegocioException("Mesa não encontrada.");
            }

            if (!ativo && _mesaRepository.TemPedidoAberto(id))
            {
                throw new RegraNegocioException(
                    "A mesa " + mesa.Numero + " tem pedido em aberto. Feche o pedido antes de desativar.");
            }

            _mesaRepository.AlterarAtivo(id, ativo);
        }

        private void Validar(Mesa mesa)
        {
            if (mesa == null)
            {
                throw new RegraNegocioException("Mesa não informada.");
            }

            mesa.Numero = Validacoes.Positivo(mesa.Numero, "número da mesa");
            mesa.Capacidade = Validacoes.Positivo(mesa.Capacidade, "capacidade");

            if (_mesaRepository.NumeroJaExiste(mesa.Numero, mesa.Id))
            {
                throw new RegraNegocioException("Já existe uma mesa com o número " + mesa.Numero + ".");
            }
        }
    }
}
