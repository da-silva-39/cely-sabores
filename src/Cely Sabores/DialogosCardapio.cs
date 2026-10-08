using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CelySabores.Business.Services;
using CelySabores.Models.Entities;

namespace Cely_Sabores
{
    // O layout esta em DialogoPrato.Designer.cs, para se poder ajustar tudo
    // no designer do Visual Studio. Aqui fica apenas a logica.
    public sealed partial class DialogoPrato : Form
    {
        private readonly CardapioService _cardapioService;
        private readonly Prato _prato;

        public Prato Prato { get; private set; }

        // Construtor usado pelo designer: nao consulta as categorias.
        public DialogoPrato()
        {
            InitializeComponent();

            btnGuardar.Click += (s, ev) => Guardar();
        }

        public DialogoPrato(CardapioService cardapioService, Prato prato)
            : this()
        {
            _cardapioService = cardapioService;
            _prato = prato;
            Prato = prato == null ? new Prato() : prato;
            Text = prato == null ? "Novo prato" : "Editar prato";

            Carregar();
        }

        private void Carregar()
        {
            foreach (var categoria in _cardapioService.ListarCategorias(false))
            {
                cmbCategoria.Items.Add(categoria);
            }

            if (_prato != null)
            {
                txtNome.Text = _prato.Nome;
                txtDescricao.Text = _prato.Descricao ?? "";
                numPreco.Value = Math.Max(0, Math.Min(1000000m, _prato.Preco));
                chkDisponivel.Checked = _prato.Disponivel;
                cmbCategoria.SelectedItem = cmbCategoria.Items.OfType<Categoria>()
                    .FirstOrDefault(c => c.Id == _prato.CategoriaId);
            }
            else
            {
                chkDisponivel.Checked = true;
                if (cmbCategoria.Items.Count > 0)
                {
                    cmbCategoria.SelectedIndex = 0;
                }
            }
        }

        private void Guardar()
        {
            var categoria = cmbCategoria.SelectedItem as Categoria;
            if (categoria == null)
            {
                MessageBox.Show("Escolha a categoria do prato.", "Cely Sabores",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Prato.CategoriaId = categoria.Id;
            Prato.Nome = txtNome.Text;
            Prato.Descricao = txtDescricao.Text;
            Prato.Preco = numPreco.Value;
            Prato.Disponivel = chkDisponivel.Checked;
            DialogResult = DialogResult.OK;
            Close();
        }
    }

    // O layout esta em DialogoCliente.Designer.cs.
    public sealed partial class DialogoCliente : Form
    {
        public Cliente Cliente { get; private set; }

        // Construtor usado pelo designer: nao preenche os campos.
        public DialogoCliente()
        {
            InitializeComponent();

            btnGuardar.Click += (s, ev) =>
            {
                Cliente.NomeCompleto = txtNome.Text;
                Cliente.Telefone = txtTelefone.Text;
                Cliente.Email = txtEmail.Text;
                Cliente.Endereco = txtEndereco.Text;
                Cliente.Observacoes = txtObservacoes.Text;
                DialogResult = DialogResult.OK;
                Close();
            };
        }

        public DialogoCliente(Cliente cliente)
            : this()
        {
            Cliente = cliente == null ? new Cliente() : cliente;
            Text = cliente == null ? "Novo cliente" : "Editar cliente";

            if (cliente != null)
            {
                txtNome.Text = cliente.NomeCompleto ?? "";
                txtTelefone.Text = cliente.Telefone ?? "";
                txtEmail.Text = cliente.Email ?? "";
                txtEndereco.Text = cliente.Endereco ?? "";
                txtObservacoes.Text = cliente.Observacoes ?? "";
            }
        }
    }
}
