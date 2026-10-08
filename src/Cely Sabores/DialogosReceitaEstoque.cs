using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CelySabores.Business.Services;
using CelySabores.Models.Entities;
using CelySabores.Models.Enums;

namespace Cely_Sabores
{
    // O layout esta em DialogoHistoricoEstoque.Designer.cs, para se poder ajustar
    // tudo no designer do Visual Studio. Aqui fica apenas a logica.
    /// <summary>
    /// Lista os movimentos de um ingrediente, ou de todos, num intervalo de
    /// datas. E so de leitura: para mudar o saldo usa-se o painel de estoque.
    /// </summary>
    public sealed partial class DialogoHistoricoEstoque : Form
    {
        private readonly EstoqueService _estoqueService;
        private readonly IList<Ingrediente> _ingredientes;
        private readonly int? _ingredienteId;

        // Construtor usado pelo designer: nao consulta os movimentos.
        public DialogoHistoricoEstoque()
        {
            InitializeComponent();

            btnFiltrar.Click += (s, ev) => Executar(Pintar);
            btnFechar.Click += (s, ev) => Close();
        }

        public DialogoHistoricoEstoque(EstoqueService estoqueService,
            IList<Ingrediente> ingredientes, int? ingredienteId)
            : this()
        {
            _estoqueService = estoqueService;
            _ingredientes = ingredientes;
            _ingredienteId = ingredienteId;

            Text = ingredienteId.HasValue ? "Movimentos do ingrediente" : "Movimentos de estoque";

            Carregar();
        }

        // Preenche os filtros com os dados recebidos. Fica fora do construtor
        // parameterless para o designer poder abrir o formulario sem a base de
        // dados.
        private void Carregar()
        {
            dtDe.Value = DateTime.Today.AddDays(-30);
            dtAte.Value = DateTime.Today;

            cmbIngrediente.Items.Add("Todos os ingredientes");
            foreach (var item in _ingredientes)
            {
                cmbIngrediente.Items.Add(item);
            }

            if (_ingredienteId.HasValue)
            {
                foreach (var item in _ingredientes)
                {
                    if (item.Id == _ingredienteId.Value)
                    {
                        cmbIngrediente.SelectedItem = item;
                        break;
                    }
                }

                cmbIngrediente.Enabled = false;
            }
            else
            {
                cmbIngrediente.SelectedIndex = 0;
            }

            Pintar();
        }

        private void Executar(Action acao)
        {
            try
            {
                acao();
            }
            catch (CelySabores.Business.Exceptions.RegraNegocioException ex)
            {
                MessageBox.Show(ex.Message, "Cely Sabores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message, "Cely Sabores",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Pintar()
        {
            int? ingredienteId = null;
            var escolhido = cmbIngrediente.SelectedItem as Ingrediente;
            if (escolhido != null)
            {
                ingredienteId = escolhido.Id;
            }

            var movimentos = _estoqueService.ListarMovimentos(ingredienteId, dtDe.Value, dtAte.Value);
            dgvMovimentos.Rows.Clear();

            foreach (var movimento in movimentos)
            {
                var indice = dgvMovimentos.Rows.Add(
                    Tema.DataHora(movimento.Data),
                    movimento.IngredienteNome,
                    DialogoMovimentoEstoque.Descrever(movimento.Tipo),
                    movimento.Quantidade.ToString("0.###"),
                    movimento.Observacao ?? "");

                dgvMovimentos.Rows[indice].DefaultCellStyle.ForeColor = CorDoMovimento(movimento.Tipo);
            }

            Text = (ingredienteId.HasValue ? "Movimentos do ingrediente" : "Movimentos de estoque")
                + " — " + movimentos.Count + " registo(s)";
        }

        private static Color CorDoMovimento(TipoMovimentoEstoque tipo)
        {
            switch (tipo)
            {
                case TipoMovimentoEstoque.Entrada: return Tema.Verde;
                case TipoMovimentoEstoque.Saida: return Tema.Perigo;
                default: return Tema.Texto;
            }
        }
    }

    // O layout esta em DialogoReceitaPrato.Designer.cs, para se poder ajustar
    // tudo no designer do Visual Studio. Aqui fica apenas a logica.
    /// <summary>
    /// Receita de um prato: que ingredientes consome e em que quantidade.
    /// </summary>
    public sealed partial class DialogoReceitaPrato : Form
    {
        private readonly EstoqueService _estoqueService;
        private readonly IList<Ingrediente> _ingredientes;
        private readonly List<ReceitaPrato> _linhas = new List<ReceitaPrato>();

        private int _pratoAtual;

        // Construtor usado pelo designer: nao consulta as receitas.
        public DialogoReceitaPrato()
        {
            InitializeComponent();

            dgvReceita.CellDoubleClick += (s, ev) => Executar(AlterarQuantidade);

            btnAdicionar.Click += (s, ev) => Executar(AdicionarLinha);
            btnQuantidade.Click += (s, ev) => Executar(AlterarQuantidade);
            btnRemover.Click += (s, ev) => Executar(RemoverLinha);
            btnGuardar.Click += (s, ev) => Executar(Guardar);
            btnFechar.Click += (s, ev) => Close();
        }

        public DialogoReceitaPrato(EstoqueService estoqueService,
            IList<Prato> pratos, IList<Ingrediente> ingredientes, int pratoId)
            : this()
        {
            _estoqueService = estoqueService;
            _ingredientes = ingredientes;

            Carregar(pratos, pratoId);
        }

        // Preenche a lista de pratos com os dados recebidos. Fica fora do
        // construtor parameterless para o designer poder abrir o formulario sem
        // a base de dados.
        private void Carregar(IList<Prato> pratos, int pratoId)
        {
            foreach (var item in pratos)
            {
                cmbPrato.Items.Add(item);
            }

            var indicePrato = 0;
            for (int i = 0; i < pratos.Count; i++)
            {
                if (pratos[i].Id == pratoId)
                {
                    indicePrato = i;
                }
            }

            cmbPrato.SelectedIndex = indicePrato;

            // so depois de a lista estar montada e que a troca de prato pode pintar
            cmbPrato.SelectedIndexChanged += (s, ev) => TrocarPrato();
            TrocarPrato();
        }

        private void Executar(Action acao)
        {
            try
            {
                acao();
            }
            catch (CelySabores.Business.Exceptions.RegraNegocioException ex)
            {
                MessageBox.Show(ex.Message, "Cely Sabores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message, "Cely Sabores",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TrocarPrato()
        {
            var prato = cmbPrato.SelectedItem as Prato;
            if (prato == null)
            {
                return;
            }

            _pratoAtual = prato.Id;
            _linhas.Clear();

            foreach (var linha in _estoqueService.ListarReceita(prato.Id))
            {
                _linhas.Add(linha);
            }

            Pintar();
        }

        private void Pintar()
        {
            dgvReceita.Rows.Clear();
            foreach (var linha in _linhas)
            {
                var indice = dgvReceita.Rows.Add(
                    linha.IngredienteNome,
                    linha.Quantidade.ToString("0.###"),
                    linha.IngredienteUnidade ?? "");

                dgvReceita.Rows[indice].Tag = linha;
            }
        }

        private void AdicionarLinha()
        {
            var jaUsados = new List<int>();
            foreach (var linha in _linhas)
            {
                jaUsados.Add(linha.IngredienteId);
            }

            using (var dialogo = new DialogoEscolherIngrediente(_ingredientes, jaUsados))
            {
                if (dialogo.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                var ingrediente = dialogo.Ingrediente;
                if (ingrediente == null)
                {
                    return;
                }

                _linhas.Add(new ReceitaPrato
                {
                    IngredienteId = ingrediente.Id,
                    Quantidade = 1,
                    IngredienteNome = ingrediente.Nome,
                    IngredienteUnidade = ingrediente.Unidade
                });

                Pintar();
            }
        }

        private void RemoverLinha()
        {
            if (dgvReceita.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione uma linha da receita.", "Cely Sabores",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var linha = dgvReceita.SelectedRows[0].Tag as ReceitaPrato;
            if (linha != null)
            {
                _linhas.Remove(linha);
                Pintar();
            }
        }

        private void AlterarQuantidade()
        {
            if (dgvReceita.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione uma linha da receita.", "Cely Sabores",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var linha = dgvReceita.SelectedRows[0].Tag as ReceitaPrato;
            if (linha == null)
            {
                return;
            }

            using (var dialogo = new DialogoQuantidadeReceita(linha))
            {
                if (dialogo.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                linha.Quantidade = dialogo.Quantidade;
                Pintar();
            }
        }

        private void Guardar()
        {
            _estoqueService.GuardarReceita(_pratoAtual, _linhas);
            MessageBox.Show("Receita guardada.", "Cely Sabores",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    // O layout esta em DialogoEscolherIngrediente.Designer.cs.
    /// <summary>Escolha de um ingrediente, excluindo os que ja estao na receita.</summary>
    internal sealed partial class DialogoEscolherIngrediente : Form
    {
        public Ingrediente Ingrediente { get; private set; }

        // Construtor usado pelo designer: nao recebe a lista de ingredientes.
        public DialogoEscolherIngrediente()
        {
            InitializeComponent();

            btnOk.Click += (s, ev) => Confirmar();
        }

        public DialogoEscolherIngrediente(IList<Ingrediente> ingredientes, IList<int> excluir)
            : this()
        {
            Carregar(ingredientes, excluir);
        }

        // Preenche a lista com os ingredientes recebidos. Fica fora do
        // construtor parameterless para o designer poder abrir o formulario sem
        // a base de dados.
        private void Carregar(IList<Ingrediente> ingredientes, IList<int> excluir)
        {
            var disponiveis = new List<Ingrediente>();
            foreach (var item in ingredientes)
            {
                if (!excluir.Contains(item.Id))
                {
                    disponiveis.Add(item);
                }
            }

            if (disponiveis.Count == 0)
            {
                MessageBox.Show("Todos os ingredientes disponíveis já estão nesta receita.", "Cely Sabores",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            foreach (var item in disponiveis)
            {
                cmbIngrediente.Items.Add(item);
            }

            cmbIngrediente.SelectedIndex = 0;
            Ingrediente = disponiveis[0];
        }

        private void Confirmar()
        {
            Ingrediente = cmbIngrediente.SelectedItem as Ingrediente;
            DialogResult = DialogResult.OK;
            Close();
        }
    }

    // O layout esta em DialogoQuantidadeReceita.Designer.cs.
    internal sealed partial class DialogoQuantidadeReceita : Form
    {
        public decimal Quantidade { get; private set; }

        // Construtor usado pelo designer: nao recebe a linha da receita.
        public DialogoQuantidadeReceita()
        {
            InitializeComponent();

            btnOk.Click += (s, ev) => Confirmar();
        }

        public DialogoQuantidadeReceita(ReceitaPrato linha)
            : this()
        {
            Carregar(linha);
        }

        // Preenche os campos com a linha recebida. Fica fora do construtor
        // parameterless para o designer poder abrir o formulario.
        private void Carregar(ReceitaPrato linha)
        {
            Text = "Quantidade de " + linha.IngredienteNome;
            lblUnidade.Text = linha.IngredienteUnidade ?? "";
            numQuantidade.Value = Math.Min(999999m, Math.Max(0.001m, linha.Quantidade));
        }

        private void Confirmar()
        {
            Quantidade = numQuantidade.Value;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
