using System;
using System.Windows.Forms;
using CelySabores.Business.Services;
using CelySabores.Models.Entities;

namespace Cely_Sabores
{
    // O layout esta em DialogoAbrirPedido.Designer.cs, para se poder ajustar tudo
    // no designer do Visual Studio. Aqui fica apenas a logica.
    public sealed partial class DialogoAbrirPedido : Form
    {
        private PedidoService _pedidoService;

        public Pedido Pedido { get; private set; }

        // Construtor usado pelo designer: nao consulta as mesas nem os clientes.
        public DialogoAbrirPedido()
        {
            InitializeComponent();

            btnAbrir.Click += (s, ev) => Abrir();
        }

        public DialogoAbrirPedido(PedidoService pedidoService)
            : this()
        {
            _pedidoService = pedidoService;

            Carregar();
        }

        // Preenche as listas com os dados recebidos. Fica fora do construtor
        // parameterless para o designer poder abrir o formulario sem a base de
        // dados.
        private void Carregar()
        {
            foreach (var mesa in _pedidoService.ListarMesasLivres())
            {
                cmbMesa.Items.Add(mesa);
            }
            if (cmbMesa.Items.Count > 0)
            {
                cmbMesa.SelectedIndex = 0;
            }

            cmbCliente.Items.Add("(balcão - sem cliente)");
            foreach (var c in _pedidoService.ListarClientes())
            {
                cmbCliente.Items.Add(c);
            }
            cmbCliente.SelectedIndex = 0;
        }

        private void Abrir()
        {
            var mesa = cmbMesa.SelectedItem as Mesa;
            if (mesa == null)
            {
                MessageBox.Show("Não há mesas disponíveis.", "Cely Sabores",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? clienteId = null;
            var cliente = cmbCliente.SelectedItem as Cliente;
            if (cliente != null)
            {
                clienteId = cliente.Id;
            }

            Pedido = _pedidoService.Abrir(mesa.Id, clienteId, txtObservacao.Text);
            DialogResult = DialogResult.OK;
            Close();
        }
    }

    // O layout esta em DialogoQuantidade.Designer.cs.
    public sealed partial class DialogoQuantidade : Form
    {
        public int Quantidade { get; private set; }
        public string Observacao { get; private set; }

        // Construtor usado pelo designer: nao mostra o preco do prato.
        public DialogoQuantidade()
        {
            InitializeComponent();

            btnOk.Click += (s, ev) => Confirmar();
        }

        public DialogoQuantidade(Prato prato)
            : this(prato, 1)
        {
        }

        public DialogoQuantidade(Prato prato, int quantidadeInicial)
            : this()
        {
            Carregar(prato, quantidadeInicial);
        }

        private void Carregar(Prato prato, int quantidadeInicial)
        {
            if (prato != null)
            {
                Text = "Adicionar " + prato.Nome;
                lblPreco.Text = "Preço: " + Tema.Moeda(prato.Preco);
            }

            numQuantidade.Value = Math.Max(1, Math.Min(999, quantidadeInicial));
        }

        private void Confirmar()
        {
            Quantidade = (int)numQuantidade.Value;
            Observacao = txtObservacao.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }

    // O layout esta em DialogoPagamento.Designer.cs.
    public sealed partial class DialogoPagamento : Form
    {
        private decimal _total;

        public decimal ValorRecebido { get; private set; }

        // Construtor usado pelo designer: nao calcula o total do pedido.
        public DialogoPagamento()
        {
            InitializeComponent();

            numRecebido.ValueChanged += (s, ev) => ActualizarTroco();
            btnExacto.Click += (s, ev) => { numRecebido.Value = _total; };
            btnConfirmar.Click += (s, ev) => Confirmar();
        }

        public DialogoPagamento(Pedido pedido)
            : this()
        {
            _total = pedido.ValorTotal;
            ValorRecebido = pedido.ValorTotal;

            Carregar(pedido);
        }

        private void Carregar(Pedido pedido)
        {
            Text = "Pagamento do pedido " + pedido.Id;
            lblTotal.Text = "Total a pagar: " + Tema.Moeda(_total);
            numRecebido.Value = Math.Min(10000000m, _total);
            ActualizarTroco();
        }

        private void Confirmar()
        {
            ValorRecebido = numRecebido.Value;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ActualizarTroco()
        {
            var troco = numRecebido.Value - _total;
            lblTroco.Text = troco < 0
                ? "Falta: " + Tema.Moeda(-troco)
                : "Troco: " + Tema.Moeda(troco);
            lblTroco.ForeColor = troco < 0 ? Tema.Perigo : Tema.Verde;
        }
    }
}
