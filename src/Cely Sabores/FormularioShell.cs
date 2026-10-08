using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CelySabores.Business.Exceptions;
using CelySabores.Business.Services;
using CelySabores.Models.Dtos;

namespace Cely_Sabores
{
    // O layout esta em FormularioShell.Designer.cs, para se poder ajustar tudo
    // no designer do Visual Studio. Aqui fica apenas a logica: os botoes do
    // menu dependem da sessao e das permissoes, por isso continuam a ser
    // criados em runtime.
    public sealed partial class FormularioShell : Form
    {
        private readonly SessaoUsuario _sessao;
        private readonly Dictionary<string, Button> _botoesMenu = new Dictionary<string, Button>();
        private string _telaAtual;

        // Construtor usado pelo designer: nao mostra nenhum painel.
        public FormularioShell()
        {
            InitializeComponent();
        }

        public FormularioShell(SessaoUsuario sessao)
            : this()
        {
            _sessao = sessao;

            MontarMenu();
            IrPara("Painel");
        }

        private void MontarMenu()
        {
            lblUsuario.Text = _sessao.FuncionarioNome + "\n" + _perfil;

            btnSair.Click += (s, ev) => Close();

            AdicionarItem("Painel", false);
            AdicionarItem("Mesas", false);
            AdicionarItem("Cardápio", false);
            AdicionarItem("Clientes", false);
            AdicionarItem("Pedidos", false);
            AdicionarItem("Reservas", false);
            AdicionarItem("Estoque", true);
            AdicionarItem("Relatórios", true);
            AdicionarItem("Funcionários", true);
        }

        private string _perfil
        {
            get { return _sessao.EhGerente ? "Gerente" : "Atendente"; }
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
            menuItens.Controls.Add(botao);
        }

        public void IrPara(string nome)
        {
            if (EhRestritoAoGerente(nome))
            {
                MessageBox.Show(
                    "O módulo '" + nome + "' é restrito à gerência.",
                    "Cely Sabores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PainelBase painel;
            try
            {
                painel = CriarPainel(nome);
            }
            catch (RegraNegocioException ex)
            {
                // rede de seguranca: mesmo forcando a rota, a regra de negocio
                // recusa e o utilizador ve a mensagem em vez de a aplicacao cair
                MessageBox.Show(ex.Message, "Cely Sabores",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
            pnlConteudo.Controls.Clear();
            painel.Dock = DockStyle.Fill;
            pnlConteudo.Controls.Add(painel);
        }

        private PainelBase CriarPainel(string nome)
        {
            switch (nome)
            {
                // cada role entra no seu proprio dashboard (requisito 5 e 15)
                case "Painel":
                    return _sessao.EhGerente
                        ? (PainelBase)new PainelDashboardGerente(_sessao, Servicos.Dashboard())
                        : new PainelDashboardFuncionario(_sessao, Servicos.Dashboard());

                case "Mesas": return new PainelMesas(Servicos.Mesas());
                case "Cardápio": return new PainelCardapio(Servicos.Cardapio());
                case "Clientes": return new PainelClientes(Servicos.Clientes());
                case "Pedidos": return new PainelPedidos(Servicos.Pedidos(), Servicos.Recibo());
                case "Reservas": return new PainelReservas(Servicos.Reservas(), Servicos.Clientes());
                case "Relatórios": return new PainelRelatorios(Servicos.Relatorios());
                case "Funcionários": return new PainelFuncionarios(Servicos.Funcionarios());
                case "Estoque": return new PainelEstoque(Servicos.Estoque());
                default: return null;
            }
        }

        private static readonly string[] ModulosGerente = { "Estoque", "Relatórios", "Funcionários" };

        private bool EhRestritoAoGerente(string nome)
        {
            if (_sessao.EhGerente)
            {
                return false;
            }

            foreach (var modulo in ModulosGerente)
            {
                if (modulo == nome)
                {
                    return true;
                }
            }

            return false;
        }

        public string TelaAtual
        {
            get { return _telaAtual; }
        }

        public void AbrirPainel(Control painel)
        {
            pnlConteudo.Controls.Clear();
            painel.Dock = DockStyle.Fill;
            pnlConteudo.Controls.Add(painel);
        }
    }
}
