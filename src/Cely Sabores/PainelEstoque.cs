using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using CelySabores.Business.Services;
using CelySabores.Models.Entities;
using CelySabores.Models.Enums;

namespace Cely_Sabores
{
    // O layout está em PainelEstoque.Designer.cs, para se poder ajustar tudo
    // no designer do Visual Studio. Aqui fica apenas a lógica.
    /// <summary>
    /// Estoque do restaurante: saldo dos ingredientes, movimentos de entrada,
    /// saída e ajuste, e as receitas dos pratos. Módulo do gerente.
    /// </summary>
    public sealed partial class PainelEstoque : PainelBase
    {
        private readonly EstoqueService _estoqueService;
        private readonly Timer _esperaPesquisa;

        private IList<Ingrediente> _ingredientes = new List<Ingrediente>();

        // Construtor usado pelo designer: não toca na base de dados.
        public PainelEstoque()
            : base("Estoque", "Carregando...")
        {
            InitializeComponent();
        }

        public PainelEstoque(EstoqueService estoqueService)
            : this()
        {
            _estoqueService = estoqueService;

            _esperaPesquisa = new Timer { Interval = 350 };
            _esperaPesquisa.Tick += (s, ev) =>
            {
                _esperaPesquisa.Stop();
                Executar(Recarregar);
            };

            txtPesquisa.TextChanged += (s, ev) =>
            {
                _esperaPesquisa.Stop();
                _esperaPesquisa.Start();
            };

            chkInativos.CheckedChanged += (s, ev) => Executar(Recarregar);
            dgvIngredientes.CellDoubleClick += (s, ev) => Executar(EditarSelecionado);

            AdicionarAcao("Actualizar", false, Recarregar);
            AdicionarAcao("Novo ingrediente", true, Novo);
            AdicionarAcao("Editar ingrediente", false, EditarSelecionado);
            AdicionarAcao("Registar entrada", false, delegate { Movimentar(TipoMovimentoEstoque.Entrada); });
            AdicionarAcao("Registar saída", false, delegate { Movimentar(TipoMovimentoEstoque.Saida); });
            AdicionarAcao("Ajuste de contagem", false, delegate { Movimentar(TipoMovimentoEstoque.Ajuste); });
            AdicionarAcao("Movimentos do ingrediente", false, HistoricoSelecionado);
            AdicionarAcao("Receitas dos pratos", false, AbrirReceitas);
            AdicionarAcao("Todos os movimentos", false, HistoricoCompleto);

            // no designer não se toca na base de dados
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                Recarregar();
            }
        }

        public override void Recarregar()
        {
            _ingredientes = _estoqueService.ListarIngredientes(chkInativos.Checked);
            var termo = (txtPesquisa.Text ?? "").Trim();
            dgvIngredientes.Rows.Clear();

            var baixo = 0;

            foreach (var ingrediente in _ingredientes)
            {
                if (termo.Length > 0
                    && ingrediente.Nome.IndexOf(termo, StringComparison.CurrentCultureIgnoreCase) < 0)
                {
                    continue;
                }

                var semStock = ingrediente.QuantidadeDisponivel <= ingrediente.QuantidadeMinima;
                if (semStock)
                {
                    baixo++;
                }

                var indice = dgvIngredientes.Rows.Add(
                    ingrediente.Nome,
                    ingrediente.Unidade,
                    ingrediente.QuantidadeDisponivel.ToString("0.###"),
                    ingrediente.QuantidadeMinima.ToString("0.###"),
                    Tema.Moeda(ingrediente.PrecoCusto),
                    ingrediente.Ativo ? (semStock ? "Baixo" : "Ok") : "Inactivo");

                dgvIngredientes.Rows[indice].Tag = ingrediente;

                if (!ingrediente.Ativo)
                {
                    dgvIngredientes.Rows[indice].DefaultCellStyle.ForeColor = Tema.TextoSuave;
                }
                else if (semStock)
                {
                    dgvIngredientes.Rows[indice].DefaultCellStyle.ForeColor = Tema.Perigo;
                }
            }

            var valorTotal = 0m;
            foreach (var ingrediente in _ingredientes)
            {
                if (ingrediente.Ativo)
                {
                    valorTotal += ingrediente.QuantidadeDisponivel * ingrediente.PrecoCusto;
                }
            }

            DefinirStatus(_ingredientes.Count + " ingrediente(s)"
                + (baixo > 0 ? " | " + baixo + " abaixo do mínimo" : "")
                + " | valor em estoque: " + Tema.Moeda(valorTotal));
        }

        private Ingrediente Selecionado()
        {
            if (dgvIngredientes.SelectedRows.Count == 0)
            {
                Aviso("Seleccione um ingrediente.", MessageBoxIcon.Information);
                return null;
            }

            return dgvIngredientes.SelectedRows[0].Tag as Ingrediente;
        }

        private void Novo()
        {
            using (var dialogo = new DialogoIngrediente())
            {
                if (dialogo.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                _estoqueService.InserirIngrediente(dialogo.Ingrediente);
                Recarregar();
            }
        }

        private void EditarSelecionado()
        {
            var ingrediente = Selecionado();
            if (ingrediente == null)
            {
                return;
            }

            using (var dialogo = new DialogoIngrediente(ingrediente))
            {
                if (dialogo.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                _estoqueService.AtualizarIngrediente(dialogo.Ingrediente);
                Recarregar();
            }
        }

        private void Movimentar(TipoMovimentoEstoque tipo)
        {
            var ingrediente = Selecionado();
            if (ingrediente == null)
            {
                return;
            }

            if (!ingrediente.Ativo)
            {
                Aviso("O ingrediente '" + ingrediente.Nome + "' está inactivo.", MessageBoxIcon.Warning);
                return;
            }

            using (var dialogo = new DialogoMovimentoEstoque(ingrediente, tipo))
            {
                if (dialogo.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                var movimento = _estoqueService.RegistrarMovimento(
                    ingrediente, tipo, dialogo.Quantidade, dialogo.Observacao);

                Recarregar();

                var novo = _estoqueService.ObterIngrediente(ingrediente.Id);
                if (novo != null && novo.QuantidadeDisponivel <= novo.QuantidadeMinima)
                {
                    Aviso("'" + novo.Nome + "' ficou com " + novo.QuantidadeDisponivel.ToString("0.###")
                        + " " + novo.Unidade + ", abaixo do mínimo de "
                        + novo.QuantidadeMinima.ToString("0.###") + " " + novo.Unidade + ".",
                        MessageBoxIcon.Warning);
                }
                else if (movimento != null)
                {
                    DefinirStatus(DialogoMovimentoEstoque.Descrever(tipo) + " registada em '"
                        + ingrediente.Nome + "'.");
                }
            }
        }

        private void HistoricoSelecionado()
        {
            var ingrediente = Selecionado();
            if (ingrediente == null)
            {
                return;
            }

            using (var dialogo = new DialogoHistoricoEstoque(_estoqueService, _ingredientes, ingrediente.Id))
            {
                dialogo.ShowDialog(this);
            }
        }

        private void HistoricoCompleto()
        {
            using (var dialogo = new DialogoHistoricoEstoque(_estoqueService, _ingredientes, null))
            {
                dialogo.ShowDialog(this);
            }
        }

        private void AbrirReceitas()
        {
            var pratos = _estoqueService.ListarPratos();
            if (pratos.Count == 0)
            {
                Aviso("Não há pratos no cardápio.", MessageBoxIcon.Information);
                return;
            }

            using (var dialogo = new DialogoReceitaPrato(
                _estoqueService, pratos, _ingredientes, pratos[0].Id))
            {
                dialogo.ShowDialog(this);
            }
        }
    }
}
