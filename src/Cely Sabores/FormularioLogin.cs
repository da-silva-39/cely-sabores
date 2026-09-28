using System;
using System.Drawing;
using System.Windows.Forms;
using CelySabores.Business.Exceptions;
using CelySabores.Business.Services;
using CelySabores.Data.Connections;
using CelySabores.Data.Database;
using CelySabores.Data.Repositories;
using CelySabores.Models.Dtos;

namespace Cely_Sabores
{
    public sealed class FormularioLogin : Form
    {
        public static readonly Color CorLaranja = Color.FromArgb(255, 152, 0);
        public static readonly Color CorLaranjaEscura = Color.FromArgb(230, 119, 0);
        public static readonly Color CorFundo = Color.FromArgb(247, 244, 240);

        private readonly AutenticacaoService _autenticacaoService;
        private readonly TextBox _txtUsuario;
        private readonly TextBox _txtSenha;
        private readonly Button _btnEntrar;
        private readonly Label _lblStatus;

        public event Action<SessaoUsuario> SessaoIniciada;

        public FormularioLogin()
        {
            _autenticacaoService = new AutenticacaoService(
                new UsuarioRepository(new CommandHelper(new SqlConnectionFactory())));

            Text = "Cely Sabores - Acesso";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(420, 360);
            BackColor = CorFundo;
            Font = new Font("Segoe UI", 10F);

            var painel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(40)
            };

            var lblTitulo = new Label
            {
                Text = "Cely Sabores",
                AutoSize = false,
                Size = new Size(340, 40),
                ForeColor = CorLaranjaEscura,
                Font = new Font("Segoe UI", 20F, FontStyle.Bold)
            };

            var lblSubtitulo = new Label
            {
                Text = "Entre com suas credenciais",
                AutoSize = true,
                ForeColor = Color.FromArgb(120, 110, 100),
                Font = new Font("Segoe UI", 10F)
            };

            _txtUsuario = new TextBox { Font = new Font("Segoe UI", 11F) };
            _txtSenha = new TextBox { Font = new Font("Segoe UI", 11F), UseSystemPasswordChar = true };
            _btnEntrar = new Button
            {
                Text = "Entrar",
                FlatStyle = FlatStyle.Flat,
                BackColor = CorLaranja,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Height = 40
            };
            _btnEntrar.FlatAppearance.BorderSize = 0;
            _btnEntrar.Click += BtnEntrar_Click;

            _lblStatus = new Label
            {
                AutoSize = true,
                ForeColor = Color.FromArgb(200, 60, 40),
                Font = new Font("Segoe UI", 9F)
            };

            var tabela = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 7,
                Padding = new Padding(0)
            };
            tabela.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            tabela.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tabela.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tabela.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tabela.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tabela.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            tabela.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tabela.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            tabela.Controls.Add(lblTitulo, 0, 0);
            tabela.Controls.Add(lblSubtitulo, 0, 1);
            tabela.Controls.Add(new Label { Text = "Usuário:", AutoSize = true }, 0, 2);
            tabela.Controls.Add(_txtUsuario, 0, 3);
            tabela.Controls.Add(new Label { Text = "Senha:", AutoSize = true }, 0, 4);
            tabela.Controls.Add(_txtSenha, 0, 5);
            tabela.Controls.Add(_lblStatus, 0, 6);

            painel.Controls.Add(tabela);
            Controls.Add(painel);

            AcceptButton = _btnEntrar;
            _txtUsuario.Focus();
        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _btnEntrar.Enabled = false;

            try
            {
                var sessao = _autenticacaoService.Autenticar(_txtUsuario.Text, _txtSenha.Text);
                var iniciar = SessaoIniciada;
                if (iniciar != null)
                {
                    iniciar(sessao);
                }
                else
                {
                    var shell = new FormularioShell(sessao);
                    Hide();
                    shell.FormClosed += (s, a) => Close();
                    shell.Show();
                }
            }
            catch (RegraNegocioException ex)
            {
                _lblStatus.Text = ex.Message;
                _txtSenha.Clear();
                _txtSenha.Focus();
            }
            finally
            {
                Cursor = Cursors.Default;
                _btnEntrar.Enabled = true;
            }
        }
    }
}
