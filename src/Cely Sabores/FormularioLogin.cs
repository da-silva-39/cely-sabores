using System;
using System.ComponentModel;
using System.Windows.Forms;
using CelySabores.Business.Exceptions;
using CelySabores.Business.Services;
using CelySabores.Data.Connections;
using CelySabores.Data.Database;
using CelySabores.Data.Repositories;
using CelySabores.Models.Dtos;

namespace Cely_Sabores
{
    // O layout esta em FormularioLogin.Designer.cs, para se poder ajustar tudo
    // no designer do Visual Studio. Aqui fica apenas a logica.
    public sealed partial class FormularioLogin : Form
    {
        private readonly AutenticacaoService _autenticacaoService;

        public event Action<SessaoUsuario> SessaoIniciada;

        // Construtor usado pelo designer: nao abre a ligacao a base de dados.
        public FormularioLogin()
        {
            InitializeComponent();

            btnEntrar.Click += BtnEntrar_Click;

            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                _autenticacaoService = new AutenticacaoService(
                    new UsuarioRepository(new CommandHelper(new SqlConnectionFactory())));

                txtUsuario.Focus();
            }
        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            btnEntrar.Enabled = false;

            try
            {
                var sessao = _autenticacaoService.Autenticar(txtUsuario.Text, txtSenha.Text);
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
                lblStatus.Text = ex.Message;
                txtSenha.Clear();
                txtSenha.Focus();
            }
            finally
            {
                Cursor = Cursors.Default;
                btnEntrar.Enabled = true;
            }
        }
    }
}
