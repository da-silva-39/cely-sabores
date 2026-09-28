using System;
using System.Drawing;
using System.Windows.Forms;
using CelySabores.Business.Exceptions;
using CelySabores.Business.Security;
using CelySabores.Models.Dtos;

namespace Cely_Sabores
{
    public abstract class PainelBase : Panel
    {
        private readonly Panel _cabecalho;
        private readonly FlowLayoutPanel _acoes;
        private readonly Label _titulo;
        private readonly Panel _conteudo;
        private readonly Label _status;

        protected PainelBase(string titulo, string subtitulo)
        {
            BackColor = Tema.Fundo;
            Padding = new Padding(0);

            _cabecalho = new Panel
            {
                Dock = DockStyle.Top,
                Height = 78,
                BackColor = Tema.Fundo
            };

            _titulo = new Label
            {
                Text = titulo,
                AutoSize = true,
                ForeColor = Tema.Texto,
                Font = new Font("Segoe UI", 17F, FontStyle.Bold),
                Location = new Point(0, 0)
            };
            _cabecalho.Controls.Add(_titulo);

            _status = new Label
            {
                Text = subtitulo,
                AutoSize = true,
                ForeColor = Tema.TextoSuave,
                Font = new Font("Segoe UI", 9F),
                Location = new Point(0, 30)
            };
            _cabecalho.Controls.Add(_status);

            _acoes = new FlowLayoutPanel
            {
                Dock = DockStyle.Right,
                Width = 560,
                FlowDirection = FlowDirection.RightToLeft,
                WrapContents = false,
                Padding = new Padding(0, 4, 0, 0),
                BackColor = Tema.Fundo
            };
            _cabecalho.Controls.Add(_acoes);

            _conteudo = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Tema.Fundo,
                Padding = new Padding(0, 8, 0, 0)
            };

            Controls.Add(_conteudo);
            Controls.Add(_cabecalho);
        }

        protected Panel Conteudo
        {
            get { return _conteudo; }
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

        protected Button AdicionarAcao(string texto, bool primario, Action acao)
        {
            var botao = Tema.Botao(texto, primario);
            botao.Click += (s, ev) => Executar(acao);
            _acoes.Controls.Add(botao);
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

        public abstract void Recarregar();
    }
}
