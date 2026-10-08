using System;
using System.Windows.Forms;
using CelySabores.Models.Entities;
using CelySabores.Models.Enums;

namespace Cely_Sabores
{
    // O layout esta em DialogoIngrediente.Designer.cs, para se poder ajustar tudo
    // no designer do Visual Studio. Aqui fica apenas a logica.
    /// <summary>
    /// Cadastro de ingrediente. A quantidade disponivel nao e editada aqui de
    /// proposito: so muda por movimento de estoque, para o historico explicar
    /// sempre o saldo.
    /// </summary>
    public sealed partial class DialogoIngrediente : Form
    {
        public Ingrediente Ingrediente { get; private set; }

        // Construtor usado pelo designer: nao preenche os campos.
        public DialogoIngrediente()
        {
            InitializeComponent();

            Ingrediente = new Ingrediente { Ativo = true };

            btnGuardar.Click += Guardar;
        }

        public DialogoIngrediente(Ingrediente ingrediente)
            : this()
        {
            Carregar(ingrediente);
        }

        // Preenche os campos com o ingrediente recebido. Fica fora do construtor
        // parameterless para o designer poder abrir o formulario: e aqui que a
        // caixa "Ingrediente activo" aparece, so a editar.
        private void Carregar(Ingrediente ingrediente)
        {
            Text = "Editar " + ingrediente.Nome;
            txtNome.Text = ingrediente.Nome;
            cmbUnidade.SelectedItem = ingrediente.Unidade;
            if (cmbUnidade.SelectedIndex < 0)
            {
                cmbUnidade.Text = ingrediente.Unidade;
            }

            numMinima.Value = Math.Min(numMinima.Maximum, ingrediente.QuantidadeMinima);
            numPreco.Value = Math.Min(numPreco.Maximum, ingrediente.PrecoCusto);
            chkAtivo.Checked = ingrediente.Ativo;
            chkAtivo.Visible = true;

            Ingrediente.Id = ingrediente.Id;
            Ingrediente.QuantidadeDisponivel = ingrediente.QuantidadeDisponivel;

            MostrarSaldo(ingrediente.QuantidadeDisponivel, ingrediente.Unidade);
        }

        private void MostrarSaldo(decimal quantidade, string unidade)
        {
            lblSaldo.Text = "Quantidade disponível: " + quantidade.ToString("0.###") + " " + unidade
                + Environment.NewLine
                + "Altere a quantidade pelo botão «Registar entrada» deste ingrediente.";
        }

        private void Guardar(object sender, EventArgs ev)
        {
            Ingrediente.Nome = txtNome.Text;
            Ingrediente.Unidade = cmbUnidade.SelectedIndex >= 0
                ? Convert.ToString(cmbUnidade.SelectedItem)
                : cmbUnidade.Text;
            Ingrediente.QuantidadeMinima = numMinima.Value;
            Ingrediente.PrecoCusto = numPreco.Value;
            Ingrediente.Ativo = chkAtivo.Checked;
            DialogResult = DialogResult.OK;
            Close();
        }
    }

    // O layout esta em DialogoMovimentoEstoque.Designer.cs, para se poder ajustar
    // tudo no designer do Visual Studio. Aqui fica apenas a logica.
    /// <summary>
    /// Registo de um movimento de estoque. O tipo define como a quantidade
    /// informada e usada: entrada soma, saida subtrai e ajuste substitui o
    /// saldo pela quantidade contada.
    /// </summary>
    public sealed partial class DialogoMovimentoEstoque : Form
    {
        private readonly Ingrediente _ingrediente;

        public TipoMovimentoEstoque Tipo { get; private set; }
        public decimal Quantidade { get; private set; }
        public string Observacao { get; private set; }

        // Construtor usado pelo designer: nao mostra o saldo do ingrediente.
        public DialogoMovimentoEstoque()
        {
            InitializeComponent();

            numQuantidade.ValueChanged += (s, ev) => ActualizarAjuda();
            btnGuardar.Click += Guardar;
        }

        public DialogoMovimentoEstoque(Ingrediente ingrediente, TipoMovimentoEstoque tipo)
            : this()
        {
            _ingrediente = ingrediente;
            Tipo = tipo;

            Carregar(ingrediente, tipo);
        }

        private void Carregar(Ingrediente ingrediente, TipoMovimentoEstoque tipo)
        {
            Text = Descrever(tipo) + " — " + ingrediente.Nome;
            lblSaldo.Text = "Disponível: " + ingrediente.QuantidadeDisponivel.ToString("0.###")
                + " " + ingrediente.Unidade;

            ActualizarAjuda();
        }

        private void ActualizarAjuda()
        {
            // no designer nao ha ingrediente, logo nao ha saldo para mostrar
            if (_ingrediente == null)
            {
                return;
            }

            decimal novo;
            if (Tipo == TipoMovimentoEstoque.Entrada)
            {
                novo = _ingrediente.QuantidadeDisponivel + numQuantidade.Value;
                lblAjuda.Text = "Depois desta entrada o saldo fica em "
                    + novo.ToString("0.###") + " " + _ingrediente.Unidade + ".";
            }
            else if (Tipo == TipoMovimentoEstoque.Saida)
            {
                novo = _ingrediente.QuantidadeDisponivel - numQuantidade.Value;
                lblAjuda.Text = novo < 0
                    ? "Quantidade acima do que existe em stock."
                    : "Depois desta saída o saldo fica em " + novo.ToString("0.###")
                      + " " + _ingrediente.Unidade + ".";
                lblAjuda.ForeColor = novo < 0 ? Tema.Perigo : Tema.TextoSuave;
            }
            else
            {
                lblAjuda.Text = "O saldo passa a ser exactamente " + numQuantidade.Value.ToString("0.###")
                    + " " + _ingrediente.Unidade + " (o que foi contado).";
            }
        }

        private void Guardar(object sender, EventArgs ev)
        {
            Quantidade = numQuantidade.Value;
            Observacao = txtObservacao.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        public static string Descrever(TipoMovimentoEstoque tipo)
        {
            switch (tipo)
            {
                case TipoMovimentoEstoque.Entrada: return "Entrada";
                case TipoMovimentoEstoque.Saida: return "Saída";
                case TipoMovimentoEstoque.Ajuste: return "Ajuste";
                default: return tipo.ToString();
            }
        }
    }
}
