using System;
using System.ComponentModel;
using System.Windows.Forms;
using CelySabores.Business.Services;
using CelySabores.Models.Entities;

namespace Cely_Sabores
{
    // O layout esta em PainelClientes.Designer.cs, para se poder ajustar tudo
    // no designer do Visual Studio. Aqui fica apenas a logica.
    public sealed partial class PainelClientes : PainelBase
    {
        private readonly ClienteService _clienteService;
        private readonly Timer _esperaPesquisa;

        // Construtor usado pelo designer: nao toca na base de dados.
        public PainelClientes()
        {
            InitializeComponent();
        }

        public PainelClientes(ClienteService clienteService)
            : this()
        {
            _clienteService = clienteService;
            _esperaPesquisa = new Timer { Interval = 350 };

            _esperaPesquisa.Tick += delegate
            {
                _esperaPesquisa.Stop();
                Executar(Recarregar);
            };

            txtPesquisa.TextChanged += delegate
            {
                _esperaPesquisa.Stop();
                _esperaPesquisa.Start();
            };

            dgvClientes.CellDoubleClick += (s, ev) => Executar(EditarSelecionado);

            AdicionarAcao("Actualizar", false, Recarregar);
            AdicionarAcao("Novo cliente", true, Novo);
            AdicionarAcao("Editar cliente", false, EditarSelecionado);

            // no designer nao se toca na base de dados
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                Recarregar();
            }
        }

        public override void Recarregar()
        {
            var clientes = _clienteService.Listar(txtPesquisa.Text);
            dgvClientes.Rows.Clear();

            foreach (var cliente in clientes)
            {
                var indice = dgvClientes.Rows.Add(
                    cliente.NomeCompleto,
                    cliente.Telefone ?? "",
                    cliente.Email ?? "",
                    cliente.Endereco ?? "",
                    Tema.DataHora(cliente.DataCadastro).Substring(0, 10));

                dgvClientes.Rows[indice].Tag = cliente;
            }

            DefinirStatus(clientes.Count + " cliente(s)"
                + (string.IsNullOrWhiteSpace(txtPesquisa.Text) ? "" : " para '" + txtPesquisa.Text.Trim() + "'"));
        }

        private Cliente Selecionado()
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                Aviso("Seleccione um cliente.", MessageBoxIcon.Information);
                return null;
            }

            return dgvClientes.SelectedRows[0].Tag as Cliente;
        }

        private void Novo()
        {
            using (var dialogo = new DialogoCliente(null))
            {
                if (dialogo.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                _clienteService.Inserir(dialogo.Cliente);
                Recarregar();
            }
        }

        private void EditarSelecionado()
        {
            var cliente = Selecionado();
            if (cliente == null)
            {
                return;
            }

            using (var dialogo = new DialogoCliente(cliente))
            {
                if (dialogo.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                _clienteService.Atualizar(dialogo.Cliente);
                Recarregar();
            }
        }
    }
}
