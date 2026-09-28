using System.Collections.Generic;
using CelySabores.Business.Exceptions;
using CelySabores.Business.Security;
using CelySabores.Business.Validators;
using CelySabores.Data.Repositories;
using CelySabores.Models.Entities;
using CelySabores.Models.Enums;

namespace CelySabores.Business.Services
{
    public class PedidoService
    {
        private readonly PedidoRepository _pedidoRepository;
        private readonly MesaRepository _mesaRepository;
        private readonly CardapioRepository _cardapioRepository;
        private readonly ClienteRepository _clienteRepository;

        public PedidoService(PedidoRepository pedidoRepository, MesaRepository mesaRepository,
            CardapioRepository cardapioRepository, ClienteRepository clienteRepository)
        {
            _pedidoRepository = pedidoRepository;
            _mesaRepository = mesaRepository;
            _cardapioRepository = cardapioRepository;
            _clienteRepository = clienteRepository;
        }

        public IList<Pedido> Listar(EstadoPedido? estado, System.DateTime? de, System.DateTime? ate)
        {
            return _pedidoRepository.Listar(estado, de, ate);
        }

        public IList<ItemPedido> ListarItens(int pedidoId)
        {
            return _pedidoRepository.ListarItens(pedidoId);
        }

        public IList<Prato> ListarPratosDisponiveis()
        {
            return _cardapioRepository.ListarPratos(null, true, true);
        }

        public IList<Mesa> ListarMesasLivres()
        {
            return _mesaRepository.ListarPorEstado(EstadoMesa.Livre, true);
        }

        public IList<Cliente> ListarClientes()
        {
            return _clienteRepository.Listar(null);
        }

        public Pedido ObterPorId(int id)
        {
            var pedido = _pedidoRepository.ObterPorId(id);
            if (pedido == null)
            {
                throw new RegraNegocioException("Pedido não encontrado.");
            }

            return pedido;
        }

        public Pedido ObterAbertoPorMesa(int mesaId)
        {
            return _pedidoRepository.ObterAbertoPorMesa(mesaId);
        }

        public Pedido Abrir(int mesaId, int? clienteId, string observacao)
        {
            ExigirSessao();

            var mesa = _mesaRepository.ObterPorId(mesaId);
            if (mesa == null)
            {
                throw new RegraNegocioException("Mesa não encontrada.");
            }

            if (!mesa.Ativo)
            {
                throw new RegraNegocioException("A mesa " + mesa.Numero + " está inactiva.");
            }

            if (_pedidoRepository.ObterAbertoPorMesa(mesaId) != null)
            {
                throw new RegraNegocioException(
                    "A mesa " + mesa.Numero + " já tem um pedido em aberto.");
            }

            if (clienteId.HasValue && _clienteRepository.ObterPorId(clienteId.Value) == null)
            {
                throw new RegraNegocioException("Cliente não encontrado.");
            }

            observacao = Validacoes.Opcional(observacao);
            var id = _pedidoRepository.Abrir(mesaId, clienteId,
                ContextoPermissao.UsuarioAtual.IdFuncionario, observacao);

            return ObterPorId(id);
        }

        public ItemPedido AdicionarItem(int pedidoId, int pratoId, int quantidade, string observacao)
        {
            ExigirSessao();
            ExigirPedidoAberto(pedidoId);

            quantidade = Validacoes.Positivo(quantidade, "quantidade");

            var prato = _cardapioRepository.ObterPrato(pratoId);
            if (prato == null)
            {
                throw new RegraNegocioException("Prato não encontrado.");
            }

            if (!prato.Ativo || !prato.Disponivel)
            {
                throw new RegraNegocioException("O prato '" + prato.Nome + "' não está disponível.");
            }

            var item = _pedidoRepository.AdicionarItem(pedidoId, pratoId, quantidade,
                Validacoes.Opcional(observacao));

            _pedidoRepository.RecalcularTotal(pedidoId);
            return item;
        }

        public void AlterarQuantidade(int itemId, int quantidade)
        {
            ExigirSessao();
            quantidade = Validacoes.Positivo(quantidade, "quantidade");
            ExigirItemEmPedidoAberto(itemId);

            _pedidoRepository.ActualizarQuantidadeItem(itemId, quantidade);
        }

        public void RemoverItem(int itemId)
        {
            ExigirSessao();
            ExigirItemEmPedidoAberto(itemId);

            _pedidoRepository.RemoverItem(itemId);
        }

        public Pagamento RegistarPagamento(int pedidoId, decimal valorRecebido)
        {
            ExigirSessao();

            var pedido = ExigirPedidoAberto(pedidoId);
            if (_pedidoRepository.ListarItens(pedidoId).Count == 0)
            {
                throw new RegraNegocioException("O pedido não tem itens.");
            }

            if (valorRecebido < pedido.ValorTotal)
            {
                throw new RegraNegocioException(
                    "O valor recebido é menor que o total do pedido (" + pedido.ValorTotal.ToString("N2") + " MZN).");
            }

            return _pedidoRepository.RegistarPagamentoEfechar(pedidoId, valorRecebido,
                ContextoPermissao.UsuarioAtual.IdFuncionario);
        }

        public void Cancelar(int pedidoId)
        {
            ExigirSessao();
            ExigirPedidoAberto(pedidoId);
            _pedidoRepository.Cancelar(pedidoId, ContextoPermissao.UsuarioAtual.IdFuncionario);
        }

        private ItemPedido ExigirItemEmPedidoAberto(int itemId)
        {
            var item = _pedidoRepository.ObterItemPorId(itemId);
            if (item == null)
            {
                throw new RegraNegocioException("O item do pedido não existe.");
            }

            ExigirPedidoAberto(item.PedidoId);
            return item;
        }

        private Pedido ExigirPedidoAberto(int pedidoId)
        {
            var pedido = ObterPorId(pedidoId);
            if (pedido.Estado != EstadoPedido.Aberto)
            {
                throw new RegraNegocioException("O pedido não está aberto.");
            }

            return pedido;
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
