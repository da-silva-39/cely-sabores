using System;
using System.ComponentModel;
using System.Windows.Forms;
using CelySabores.Business.Services;
using CelySabores.Models.Entities;
using CelySabores.Models.Enums;

namespace Cely_Sabores
{
    // O layout esta em PainelPedidos.Designer.cs, para se poder ajustar tudo
    // no designer do Visual Studio. Aqui fica apenas a logica.
    public sealed partial class PainelPedidos : PainelBase
    {
        private readonly PedidoService _pedidoService;
        private readonly ReciboService _reciboService;

        // Construtor usado pelo designer: nao toca na base de dados.
        public PainelPedidos()
            : base("Pedidos", "Carregando...")
        {
            InitializeComponent();
        }

        public PainelPedidos(PedidoService pedidoService, ReciboService reciboService)
            : this()
        {
            _pedidoService = pedidoService;
            _reciboService = reciboService;

            cmbEstado.SelectedIndexChanged += (s, ev) => Executar(Recarregar);
            dgvPedidos.CellDoubleClick += (s, ev) => Executar(AbrirSelecionado);

            AdicionarAcao("Actualizar", false, Recarregar);
            AdicionarAcao("Abrir pedido", true, AbrirPedido);
            AdicionarAcao("Ver / gerir", false, AbrirSelecionado);

            // Nao existe "imprimir recibo" aqui de proposito: o funcionario
            // emite o recibo no fim do atendimento, logo apos o pagamento.
            // Qualquer impressao a partir do historico e uma reimpressao de um
            // recibo antigo, que e uma tarefa exclusiva do gerente (requisito 9):
            // o botao fica escondido para o funcionario, e o servico volta a
            // recusar o pedido mesmo que a accao seja disparada.
            var btnReimprimir = AdicionarAcao("Reimprimir recibo", false, ReimprimirReciboSelecionado);
            btnReimprimir.Visible = EhGerente;

            AdicionarAcao("Cancelar pedido", false, CancelarSelecionado);

            // no designer nao se toca na base de dados
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                Recarregar();
            }
        }

        public override void Recarregar()
        {
            EstadoPedido? estado = null;
            switch (cmbEstado.SelectedIndex)
            {
                case 1: estado = EstadoPedido.Aberto; break;
                case 2: estado = EstadoPedido.Fechado; break;
                case 3: estado = EstadoPedido.Cancelado; break;
            }

            var pedidos = _pedidoService.Listar(estado, null, null);
            dgvPedidos.Rows.Clear();

            foreach (var pedido in pedidos)
            {
                var indice = dgvPedidos.Rows.Add(
                    pedido.Id,
                    pedido.MesaNumero,
                    string.IsNullOrEmpty(pedido.ClienteNome) ? "(balcão)" : pedido.ClienteNome,
                    Tema.DataHora(pedido.DataAbertura),
                    DescreverEstado(pedido.Estado),
                    Tema.Moeda(pedido.ValorTotal));

                dgvPedidos.Rows[indice].Tag = pedido;
            }

            DefinirStatus(pedidos.Count + " pedido(s)");
        }

        private static string DescreverEstado(EstadoPedido estado)
        {
            switch (estado)
            {
                case EstadoPedido.Aberto: return "Aberto";
                case EstadoPedido.Fechado: return "Fechado";
                case EstadoPedido.Cancelado: return "Cancelado";
                default: return estado.ToString();
            }
        }

        private Pedido Selecionado()
        {
            if (dgvPedidos.SelectedRows.Count == 0)
            {
                Aviso("Seleccione um pedido.", MessageBoxIcon.Information);
                return null;
            }

            return dgvPedidos.SelectedRows[0].Tag as Pedido;
        }

        private void AbrirPedido()
        {
            using (var dialogo = new DialogoAbrirPedido(_pedidoService))
            {
                if (dialogo.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                var pedido = dialogo.Pedido;
                Recarregar();
                AbrirDetalhe(pedido);
            }
        }

        private void AbrirSelecionado()
        {
            var pedido = Selecionado();
            if (pedido == null)
            {
                return;
            }

            AbrirDetalhe(pedido);
        }

        private void AbrirDetalhe(Pedido pedido)
        {
            using (var detalhe = new PainelPedidoDetalhe(_pedidoService, _reciboService, pedido))
            {
                detalhe.ShowDialog(this);
            }

            Recarregar();
        }

        private void ReimprimirReciboSelecionado()
        {
            if (_reciboService == null)
            {
                return;
            }

            var pedido = Selecionado();
            if (pedido == null)
            {
                return;
            }

            if (pedido.Estado != EstadoPedido.Fechado)
            {
                Aviso("Só é possível reimprimir o recibo de um pedido fechado.",
                    MessageBoxIcon.Information);
                return;
            }

            // ObterParaReimpressao exige gerente e regista a reimpressao
            using (var formulario = new FormularioRecibo(
                _reciboService.ObterParaReimpressao(pedido.Id)))
            {
                formulario.ShowDialog(this);
            }
        }

        private void CancelarSelecionado()
        {
            var pedido = Selecionado();
            if (pedido == null)
            {
                return;
            }

            if (Confirmar("Cancelar o pedido " + pedido.Id + " da mesa " + pedido.MesaNumero + "?") != DialogResult.Yes)
            {
                return;
            }

            _pedidoService.Cancelar(pedido.Id);
            Recarregar();
        }
    }
}
