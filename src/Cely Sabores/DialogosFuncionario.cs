using System;
using System.Drawing;
using System.Windows.Forms;
using CelySabores.Models.Entities;

namespace Cely_Sabores
{
    public sealed class DialogoFuncionario : Form
    {
        private readonly TextBox _nome;
        private readonly TextBox _telefone;
        private readonly TextBox _email;
        private readonly TextBox _endereco;
        private readonly TextBox _cargo;
        private readonly TextBox _observacoes;

        public Funcionario Funcionario { get; private set; }

        public DialogoFuncionario()
        {
            Funcionario = new Funcionario();

            Text = "Novo funcionário";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            ClientSize = new Size(440, 380);
            BackColor = Color.White;
            Font = new Font("Segoe UI", 10F);

            _nome = Campo(22, "Nome completo");
            _cargo = Campo(68, "Cargo");
            _telefone = Campo(114, "Telefone");
            _email = Campo(160, "E-mail");
            _endereco = Campo(206, "Endereço");

            var lblObs = new Label
            {
                Text = "Observações",
                Location = new Point(20, 252),
                AutoSize = true,
                ForeColor = Tema.Texto
            };
            _observacoes = new TextBox
            {
                Location = new Point(150, 248),
                Width = 260,
                Multiline = true,
                Height = 56,
                ScrollBars = ScrollBars.Vertical
            };

            var btnGuardar = new Button
            {
                Text = "Guardar",
                DialogResult = DialogResult.None,
                Size = new Size(100, 34),
                Location = new Point(190, 325),
                FlatStyle = FlatStyle.Flat,
                BackColor = Tema.Laranja,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Click += Guardar;

            var btnCancelar = new Button
            {
                Text = "Cancelar",
                DialogResult = DialogResult.Cancel,
                Size = new Size(100, 34),
                Location = new Point(300, 325),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Tema.Texto,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnCancelar.FlatAppearance.BorderColor = Tema.Borda;

            AcceptButton = btnGuardar;
            CancelButton = btnCancelar;

            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Controls.Add(lblObs);
            Controls.Add(_observacoes);
        }

        public DialogoFuncionario(Funcionario funcionario) : this()
        {
            Text = "Editar " + funcionario.NomeCompleto;
            _nome.Text = funcionario.NomeCompleto ?? "";
            _cargo.Text = funcionario.Cargo ?? "";
            _telefone.Text = funcionario.Telefone ?? "";
            _email.Text = funcionario.Email ?? "";
            _endereco.Text = funcionario.Endereco ?? "";
            _observacoes.Text = funcionario.Observacoes ?? "";

            Funcionario.Id = funcionario.Id;
            Funcionario.Ativo = funcionario.Ativo;
            Funcionario.DataCadastro = funcionario.DataCadastro;
        }

        private void Guardar(object sender, EventArgs ev)
        {
            Funcionario.NomeCompleto = _nome.Text;
            Funcionario.Cargo = _cargo.Text;
            Funcionario.Telefone = _telefone.Text;
            Funcionario.Email = _email.Text;
            Funcionario.Endereco = _endereco.Text;
            Funcionario.Observacoes = _observacoes.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private TextBox Campo(int y, string rotulo)
        {
            Controls.Add(new Label
            {
                Text = rotulo,
                Location = new Point(20, y + 4),
                AutoSize = true,
                ForeColor = Tema.Texto
            });

            var campo = new TextBox
            {
                Location = new Point(150, y),
                Width = 260,
                Font = new Font("Segoe UI", 10F)
            };
            Controls.Add(campo);
            return campo;
        }
    }
}
