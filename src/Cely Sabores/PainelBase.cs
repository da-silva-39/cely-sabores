using System;
using System.Drawing;
using System.Windows.Forms;
using CelySabores.Business.Exceptions;
using CelySabores.Business.Security;
using CelySabores.Models.Dtos;

namespace Cely_Sabores
{
    // UserControl (e nao Panel) para o Visual Studio abrir este painel no
    // designer visual: o designer so edita Forms e UserControls.
    // Todo o layout vive em PainelBase.Designer.cs.
    // Nao e abstract: o designer do Visual Studio recusa abrir classes
    // abstractas. Recarregar() e virtual para os paineis filhos fazerem override.
    public partial class PainelBase : UserControl
    {
        // usado pelo designer quando instancia o painel
        public PainelBase()
        {
            InitializeComponent();
        }

        protected PainelBase(string titulo, string subtitulo)
            : this()
        {
            _titulo.Text = titulo;
            _status.Text = subtitulo;

            // o painel so recebe a largura final quando o shell o encaixa
            SizeChanged += (s, ev) => AjustarCabecalho();
            AjustarCabecalho();
        }

        protected SessaoUsuario Sessao
        {
            get { return ContextoPermissao.UsuarioAtual; }
        }

        protected bool EhGerente
        {
            get { return ContextoPermissao.EhGerente(); }
        }

        protected void DefinirStatus(string texto)
        {
            _status.Text = texto;
        }

        protected void DefinirTitulo(string texto)
        {
            _titulo.Text = texto;
        }

        private void AjustarCabecalho()
        {
            if (ClientSize.Width <= 0)
            {
                return;
            }

            // a barra nunca invade o titulo, mas tampouco encolhe tanto que
            // obrigue os botoes a mais linhas do que o necessario
            var largura = Math.Max(360, Math.Min(880, ClientSize.Width * 62 / 100));
            _acoes.Width = largura;

            var paraOTitulo = Math.Max(120, ClientSize.Width - largura - 12);
            _titulo.MaximumSize = new Size(paraOTitulo, 0);
            _status.MaximumSize = new Size(paraOTitulo, 0);

            // o cabecalho cresce para accomodar as linhas extra de botoes
            var altura = _acoes.GetPreferredSize(new Size(largura - 2, 0)).Height;
            _cabecalho.Height = Math.Max(78, altura + 10);
        }

        protected Button AdicionarAcao(string texto, bool primario, Action acao)
        {
            var botao = Tema.Botao(texto, primario);
            botao.Click += (s, ev) => Executar(acao);
            _acoes.Controls.Add(botao);
            AjustarCabecalho();
            return botao;
        }

        protected void Executar(Action acao)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                acao();
            }
            catch (RegraNegocioException ex)
            {
                Aviso(ex.Message, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                Aviso("Ocorreu um erro: " + ex.Message, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        protected static void Aviso(string mensagem, MessageBoxIcon icone)
        {
            MessageBox.Show(mensagem, "Cely Sabores", MessageBoxButtons.OK, icone);
        }

        protected static DialogResult Confirmar(string mensagem)
        {
            return MessageBox.Show(mensagem, "Cely Sabores", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public virtual void Recarregar()
        {
        }
    }
}
