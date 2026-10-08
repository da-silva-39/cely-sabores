using System;
using CelySabores.Business.Exceptions;
using CelySabores.Business.Security;
using CelySabores.Data.Repositories;
using CelySabores.Models.Dtos;
using CelySabores.Models.Enums;

namespace CelySabores.Business.Services
{
    /// <summary>
    /// Monta os recibos dos pedidos finalizados (requisito 9).
    /// O recibo mostra os valores registados no pagamento e nunca a forma como
    /// o cliente pagou, porque o sistema nao guarda esse dado.
    /// </summary>
    public class ReciboService
    {
        private readonly PedidoRepository _pedidoRepository;

        public ReciboService(PedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        /// <summary>Recibo de um pedido que acabou de ser fechado.</summary>
        public Recibo Obter(int pedidoId)
        {
            return Montar(pedidoId, false);
        }

        /// <summary>
        /// Reimpressao de um recibo antigo. So o gerente pode reimprimir
        /// (requisito 9).
        /// </summary>
        public Recibo ObterParaReimpressao(int pedidoId)
        {
            ContextoPermissao.ExigirGerente();
            return Montar(pedidoId, true);
        }

        public bool PodeReimprimir
        {
            get { return ContextoPermissao.EhGerente(); }
        }

        private Recibo Montar(int pedidoId, bool reimpressao)
        {
            var pedido = _pedidoRepository.ObterPorId(pedidoId);
            if (pedido == null)
            {
                throw new RegraNegocioException("Pedido não encontrado.");
            }

            if (pedido.Estado == EstadoPedido.Cancelado)
            {
                throw new RegraNegocioException(
                    "O pedido " + pedidoId + " foi cancelado e não tem recibo.");
            }

            if (pedido.Estado != EstadoPedido.Fechado)
            {
                throw new RegraNegocioException(
                    "O pedido " + pedidoId + " ainda está aberto. Registe o pagamento primeiro.");
            }

            var pagamento = _pedidoRepository.ObterPagamento(pedidoId);
            if (pagamento == null)
            {
                throw new RegraNegocioException(
                    "O pedido " + pedidoId + " não tem pagamento registado.");
            }

            var recibo = new Recibo
            {
                NumeroPedido = pedido.Id,
                NumeroMesa = pedido.MesaNumero,
                NomeCliente = pedido.ClienteNome,
                DataHora = pagamento.DataPagamento,
                FuncionarioNome = pagamento.FuncionarioNome,
                Total = pedido.ValorTotal,
                ValorRecebido = pagamento.ValorRecebido,
                Troco = pagamento.Troco
            };

            if (reimpressao)
            {
                recibo.ReimpressoEm = DateTime.Now;
            }

            foreach (var item in _pedidoRepository.ListarItens(pedidoId))
            {
                recibo.Itens.Add(new ReciboItem
                {
                    Prato = item.PratoNome,
                    Quantidade = item.Quantidade,
                    PrecoUnitario = item.PrecoUnitario,
                    Subtotal = item.Subtotal,
                    Observacao = item.Observacao
                });
            }

            return recibo;
        }
    }
}
