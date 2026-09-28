using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CelySabores.Business.Services;
using CelySabores.Models.Dtos;

namespace Cely_Sabores
{
    public sealed class FormularioShell : Form
    {
        private readonly SessaoUsuario _sessao;
        private readonly Panel _painelMenu;
        private readonly Panel _painelConteudo;
        private readonly FlowLayoutPanel _menuItens;
        private readonly Dictionary<string, Button> _botoesMenu = new Dictionary<string, Button>();
        private string _telaAtual;

        public FormularioShell(SessaoUsuario sessao)
        {
            _sessao = sessao;

            Text = "Cely Sabores";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(1180, 720);
            MinimumSize = new Size(1024, 640);
            BackColor = Tema.Fundo;
            Font = new Font("Segoe UI", 10F);

            _painelMenu = new Panel
            {
                Dock = DockStyle.Left,
                Width = 224,
                BackColor = Tema.Menu
            };

            _menuItens = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BackColor = Tema.Menu,
                Padding = new Padding(10, 0, 10, 0)
            };

            _painelConteudo = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(22),
                BackColor = Tema.Fundo
            };

            Controls.Add(_painelConteudo);
            Controls.Add(_painelMenu);

            MontarMenu();
            IrPara("Painel");
        }

        private void MontarMenu()
        {
            var lblTitulo = new Label
            {
                Text = "Cely Sabores",
                Dock = DockStyle.Top,
                Height = 54,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(18, 0, 0, 0)
            };
            _painelMenu.Controls.Add(lblTitulo);

            var lblUsuario = new Label
            {
                Text = _sessao.FuncionarioNome + "\n" + _sessao.Cargo,
                Dock = DockStyle.Top,
                Height = 48,
                ForeColor = Color.FromArgb(255, 201, 130),
                Font = new Font("Segoe UI", 9F),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(18, 0, 0, 0)
            };
            _painelMenu.Controls.Add(lblUsuario);

            var btnSair = new Button
            {
                Text = "Sair",
                Dock = DockStyle.Bottom,
                Height = 46,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(176, 58, 42),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnSair.FlatAppearance.BorderSize = 0;
            btnSair.Click += (s, ev) => Close();
            _painelMenu.Controls.Add(btnSair);

            _painelMenu.Controls.Add(_menuItens);

            AdicionarItem("Painel", false);
            AdicionarItem("Mesas", false);
            AdicionarItem("Cardápio", false);
            AdicionarItem("Clientes", false);
            AdicionarItem("Pedidos", false);
            AdicionarItem("Reservas", false);
            AdicionarItem("Relatórios", false);
            AdicionarItem("Funcionários", true);
        }

        private void AdicionarItem(string nome, bool apenasGerente)
        {
            if (apenasGerente && !_sessao.EhGerente)
            {
                return;
            }

            var botao = new Button
            {
                Text = nome,
                Dock = DockStyle.Top,
                Height = 38,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.FromArgb(235, 228, 220),
                BackColor = Tema.Menu,
                Font = new Font("Segoe UI", 10.5F),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(14, 0, 0, 0),
                Cursor = Cursors.Hand,
                Margin = new Padding(0, 0, 0, 2)
            };
            botao.FlatAppearance.BorderSize = 0;
            botao.FlatAppearance.MouseOverBackColor = Color.FromArgb(72, 60, 46);
            botao.Click += (s, ev) => IrPara(nome);

            _botoesMenu[nome] = botao;
            _menuItens.Controls.Add(botao);
        }

        public void IrPara(string nome)
        {
            PainelBase painel = CriarPainel(nome);
            if (painel == null)
            {
                MessageBox.Show("O módulo '" + nome + "' ainda não está disponível.",
                    "Cely Sabores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var par in _botoesMenu)
            {
                par.Value.ForeColor = par.Key == nome
                    ? Color.White
                    : Color.FromArgb(235, 228, 220);
                par.Value.Font = par.Key == nome
                    ? new Font("Segoe UI", 10.5F, FontStyle.Bold)
                    : new Font("Segoe UI", 10.5F);
            }

            _telaAtual = nome;
            _painelConteudo.Controls.Clear();
            painel.Dock = DockStyle.Fill;
            _painelConteudo.Controls.Add(painel);
        }

        private PainelBase CriarPainel(string nome)
        {
            switch (nome)
            {
                case "Painel": return new PainelDashboard(_sessao, Servicos.Dashboard());
                case "Mesas": return new PainelMesas(Servicos.Mesas());
                case "Cardápio": return new PainelCardapio(Servicos.Cardapio());
                case "Clientes": return new PainelClientes(Servicos.Clientes());
                case "Pedidos": return new PainelPedidos(Servicos.Pedidos());
                case "Reservas": return new PainelReservas(Servicos.Reservas(), Servicos.Clientes());
                case "Relatórios": return new PainelRelatorios(Servicos.Relatorios());
                case "Funcionários": return new PainelFuncionarios(Servicos.Funcionarios());
                default: return null;
            }
        }

        public string TelaAtual
        {
            get { return _telaAtual; }
        }

        public void AbrirPainel(Control painel)
        {
            _painelConteudo.Controls.Clear();
            painel.Dock = DockStyle.Fill;
            _painelConteudo.Controls.Add(painel);
        }
    }
}
