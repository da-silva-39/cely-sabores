using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CelySabores.Business.Services;
using CelySabores.Models.Entities;

namespace Cely_Sabores
{
    public sealed class PainelClientes : PainelBase
    {
        private readonly ClienteService _clienteService;
        private readonly DataGridView _tabela;
        private readonly TextBox _pesquisa;
        private readonly Timer _esperaPesquisa;

        public PainelClientes(ClienteService clienteService) : base("Clientes", "Carregando...")
        {
            _clienteService = clienteService;

            _pesquisa = new TextBox
            {
                Width = 300,
                Font = new Font("Segoe UI", 9.5F),
                BorderStyle = BorderStyle.FixedSingle
            };

            _esperaPesquisa = new Timer { Interval = 350 };
            _esperaPesquisa.Tick += (s, ev) =>
            {
                _esperaPesquisa.Stop();
                Executar(Recarregar);
            };
            _pesquisa.TextChanged += (s, ev) =>
            {
                _esperaPesquisa.Stop();
                _esperaPesquisa.Start();
            };

            var filtros = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 42,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                BackColor = Tema.Fundo
            };
            filtros.Controls.Add(_pesquisa);

            _tabela = Tema.Tabela("Nome", "Telefone", "E-mail", "Endereço", "Desde");
            _tabela.Columns[0].FillWeight = 28;
            _tabela.Columns[1].FillWeight = 18;
            _tabela.Columns[2].FillWeight = 24;
            _tabela.Columns[3].FillWeight = 20;
            _tabela.Columns[4].FillWeight = 10;
            _tabela.CellDoubleClick += (s, ev) => Executar(EditarSelecionado);

            Conteudo.Controls.Add(_tabela);
            Conteudo.Controls.Add(filtros);

            AdicionarAcao("Actualizar", false, Recarregar);
            AdicionarAcao("Novo cliente", true, Novo);
            AdicionarAcao("Editar cliente", false, EditarSelecionado);

            Recarregar();
        }

        public override void Recarregar()
        {
            var clientes = _clienteService.Listar(_pesquisa.Text);
            _tabela.Rows.Clear();

            foreach (var cliente in clientes)
            {
                var indice = _tabela.Rows.Add(
                    cliente.NomeCompleto,
                    cliente.Telefone ?? "",
                    cliente.Email ?? "",
                    cliente.Endereco ?? "",
                    Tema.DataHora(cliente.DataCadastro).Substring(0, 10));

                _tabela.Rows[indice].Tag = cliente;
            }

            DefinirStatus(clientes.Count + " cliente(s)"
                + (string.IsNullOrWhiteSpace(_pesquisa.Text) ? "" : " para '" + _pesquisa.Text.Trim() + "'"));
        }

        private Cliente Selecionado()
        {
            if (_tabela.SelectedRows.Count == 0)
            {
                Aviso("Seleccione um cliente.", MessageBoxIcon.Information);
                return null;
            }

            return _tabela.SelectedRows[0].Tag as Cliente;
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
