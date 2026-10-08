using System;
using System.Windows.Forms;
using CelySabores.Models.Entities;

namespace Cely_Sabores
{
    // O layout esta em DialogoFuncionario.Designer.cs, para se poder ajustar
    // tudo no designer do Visual Studio. Aqui fica apenas a logica.
    public sealed partial class DialogoFuncionario : Form
    {
        public Funcionario Funcionario { get; private set; }

        // Construtor usado pelo designer (e tambem o de "novo funcionario").
        public DialogoFuncionario()
        {
            InitializeComponent();
            Funcionario = new Funcionario();

            btnGuardar.Click += Guardar;
        }

        public DialogoFuncionario(Funcionario funcionario)
            : this()
        {
            Text = "Editar " + funcionario.NomeCompleto;
            txtNome.Text = funcionario.NomeCompleto ?? "";
            txtCargo.Text = funcionario.Cargo ?? "";
            txtTelefone.Text = funcionario.Telefone ?? "";
            txtEmail.Text = funcionario.Email ?? "";
            txtEndereco.Text = funcionario.Endereco ?? "";
            txtObservacoes.Text = funcionario.Observacoes ?? "";

            Funcionario.Id = funcionario.Id;
            Funcionario.Ativo = funcionario.Ativo;
            Funcionario.DataCadastro = funcionario.DataCadastro;
        }

        private void Guardar(object sender, EventArgs ev)
        {
            Funcionario.NomeCompleto = txtNome.Text;
            Funcionario.Cargo = txtCargo.Text;
            Funcionario.Telefone = txtTelefone.Text;
            Funcionario.Email = txtEmail.Text;
            Funcionario.Endereco = txtEndereco.Text;
            Funcionario.Observacoes = txtObservacoes.Text;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
