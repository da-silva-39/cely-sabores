using System;
using System.ComponentModel;
using System.Windows.Forms;
using CelySabores.Business.Exceptions;
using CelySabores.Business.Services;
using CelySabores.Models.Entities;
using CelySabores.Models.Enums;

namespace Cely_Sabores
{
    // O layout esta em PainelPedidoDetalhe.Designer.cs, para se poder ajustar
    // tudo no designer do Visual Studio. Aqui fica apenas a logica.
    public sealed partial class PainelPedidoDetalhe : Form
    {
        private readonly PedidoService _pedidoService;
        private readonly ReciboService _reciboService;
        private readonly int _pedidoId;

        // Construtor usado pelo designer: nao toca na base de dados.
        public PainelPedidoDetalhe()
        {
            InitializeComponent();
        }

        public PainelPedidoDetalhe(PedidoService pedidoService, ReciboService reciboService, Pedido pedido)
            : this()
        {
            _pedidoService = pedidoService;
            _reciboService = reciboService;
            _pedidoId = pedido == null ? 0 : pedido.Id;

            Inicializar();

            Text = "Pedido " + _pedidoId + " - Mesa " + pedido.MesaNumero;

            // no designer nao se toca na base de dados
            if (_pedidoService != null && LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                Recarregar();
            }
        }

        private void Inicializar()
        {
            dgvCardapio.CellDoubleClick += (s, ev) => Executar(AdicionarPratoSelecionado);

            btnAdicionar.Click += (s, ev) => Executar(AdicionarPratoSelecionado);
            btnRemover.Click += (s, ev) => Executar(RemoverItem);
            btnQuantidade.Click += (s, ev) => Executar(AlterarQuantidade);
            btnCancelar.Click += (s, ev) => Executar(Cancelar);
            btnPagar.Click += (s, ev) => Executar(Pagar);
            btnRecibo.Click += (s, ev) => Executar(MostrarRecibo);
            btnFechar.Click += (s, ev) => Fechar();
        }

        // mesmo tratamento de erros que os paineis usam nas accoes
        private void Executar(Action acao)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                acao();
            }
            catch (RegraNegocioException ex)
            {
                MessageBox.Show(ex.Message, "Cely Sabores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message, "Cely Sabores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        public void Recarregar()
        {
            var pedido = _pedidoService.ObterPorId(_pedidoId);
            var itens = _pedidoService.ListarItens(_pedidoId);

            cabecalho.Text = "Pedido " + pedido.Id + "   |   Mesa " + pedido.MesaNumero
                + "   |   " + DescreverEstado(pedido.Estado)
                + "   |   " + (string.IsNullOrEmpty(pedido.ClienteNome) ? "Cliente: balcão" : "Cliente: " + pedido.ClienteNome)
                + "   |   Aberto por " + pedido.FuncionarioNome
                + "   |   " + Tema.DataHora(pedido.DataAbertura);

            dgvItens.Rows.Clear();
            foreach (var item in itens)
            {
                dgvItens.Rows.Add(
                    item.PratoNome + (string.IsNullOrEmpty(item.Observacao) ? "" : "  (" + item.Observacao + ")"),
                    item.Quantidade,
                    Tema.Moeda(item.PrecoUnitario),
                    Tema.Moeda(item.Subtotal));
            }

            lblTotal.Text = "Total: " + Tema.Moeda(pedido.ValorTotal);

            // o botao de recibo existe apenas durante o atendimento: e a
            // emissao do recibo que o funcionario acabou de fazer. Reabrir um
            // pedido antigo nao volta a dar recibo a ninguem — para isso o
            // gerente usa "Reimprimir recibo" no historico.
            // Depois do pagamento o recibo continua a poder ser emitido: e o
            // proprio Pagar() que o mostra, porque a partir dai o botao some.
            btnRecibo.Visible = pedido.Estado == EstadoPedido.Aberto;

            dgvCardapio.Rows.Clear();
            foreach (var prato in _pedidoService.ListarPratosDisponiveis())
            {
                var indice = dgvCardapio.Rows.Add(prato.Nome, Tema.Moeda(prato.Preco));
                dgvCardapio.Rows[indice].Tag = prato;
            }
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

        private void Fechar()
        {
            Close();
        }

        private void AdicionarPratoSelecionado()
        {
            if (dgvCardapio.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione um prato do cardápio.", "Cely Sabores",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var prato = dgvCardapio.SelectedRows[0].Tag as Prato;
            using (var dialogo = new DialogoQuantidade(prato))
            {
                if (dialogo.ShowDialog(FindForm()) != DialogResult.OK)
                {
                    return;
                }

                _pedidoService.AdicionarItem(_pedidoId, prato.Id, dialogo.Quantidade, dialogo.Observacao);
            }

            Recarregar();
        }

        private void AlterarQuantidade()
        {
            var item = ItemSeleccionado();
            if (item == null)
            {
                return;
            }

            using (var dialogo = new DialogoQuantidade(null, item.Quantidade))
            {
                if (dialogo.ShowDialog(FindForm()) != DialogResult.OK)
                {
                    return;
                }

                if (dialogo.Quantidade <= 0)
                {
                    _pedidoService.RemoverItem(item.Id);
                }
                else
                {
                    _pedidoService.AlterarQuantidade(item.Id, dialogo.Quantidade);
                }
            }

            Recarregar();
        }

        private void RemoverItem()
        {
            var item = ItemSeleccionado();
            if (item == null)
            {
                return;
            }

            if (MessageBox.Show("Remover '" + item.PratoNome + "' do pedido?", "Cely Sabores",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            _pedidoService.RemoverItem(item.Id);
            Recarregar();
        }

        private ItemPedido ItemSeleccionado()
        {
            if (dgvItens.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione um item do pedido.", "Cely Sabores",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            var linha = dgvItens.SelectedRows[0].Index;
            var itens = _pedidoService.ListarItens(_pedidoId);
            return linha >= 0 && linha < itens.Count ? itens[linha] : null;
        }

        private void MostrarRecibo()
        {
            if (_reciboService == null)
            {
                return;
            }

            // o funcionario emite o recibo do atendimento que acabou de fazer.
            // A reimpressao de um recibo antigo e um pedido a parte, no historico
            // de pedidos, e so o gerente a pode fazer.
            using (var formulario = new FormularioRecibo(_reciboService.Obter(_pedidoId)))
            {
                formulario.ShowDialog(FindForm());
            }
        }

        private void Pagar()
        {
            var pedido = _pedidoService.ObterPorId(_pedidoId);

            decimal valorRecebido;
            using (var dialogo = new DialogoPagamento(pedido))
            {
                if (dialogo.ShowDialog(FindForm()) != DialogResult.OK)
                {
                    return;
                }

                valorRecebido = dialogo.ValorRecebido;
            }

            var pagamento = _pedidoService.RegistarPagamento(_pedidoId, valorRecebido);
            Recarregar();

            var resposta = MessageBox.Show(
                "Pagamento registado. Troco: " + Tema.Moeda(pagamento.Troco)
                + Environment.NewLine + "Deseja imprimir o recibo?",
                "Cely Sabores", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (resposta == DialogResult.Yes)
            {
                MostrarRecibo();
            }
        }

        private void Cancelar()
        {
            if (MessageBox.Show("Cancelar este pedido? A mesa será libertada.",
                    "Cely Sabores", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            _pedidoService.Cancelar(_pedidoId);
            Recarregar();
        }
    }
}
