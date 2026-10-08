using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using CelySabores.Business.Services;
using CelySabores.Models.Entities;

namespace Cely_Sabores
{
    // O layout esta em PainelCardapio.Designer.cs, para se poder ajustar tudo
    // no designer do Visual Studio. Aqui fica apenas a logica.
    public sealed partial class PainelCardapio : PainelBase
    {
        private readonly CardapioService _cardapioService;
        private readonly List<Categoria> _categorias = new List<Categoria>();
        private bool _aAtualizarFiltros;

        // Construtor usado pelo designer: nao toca na base de dados.
        public PainelCardapio()
            : base("Cardápio", "Carregando...")
        {
            InitializeComponent();
        }

        public PainelCardapio(CardapioService cardapioService)
            : this()
        {
            _cardapioService = cardapioService;

            // as categorias so existem depois de vir da base de dados: a
            // combo fica no Designer vazia e e preenchida aqui
            cmbCategoria.SelectedIndexChanged += (s, ev) => AoMudarFiltro();
            chkDisponiveis.CheckedChanged += (s, ev) => AoMudarFiltro();
            dgvCardapio.CellDoubleClick += (s, ev) => Executar(EditarSelecionado);

            AdicionarAcao("Actualizar", false, Recarregar);
            AdicionarAcao("Novo prato", true, NovoPrato);
            AdicionarAcao("Editar prato", false, EditarSelecionado);
            AdicionarAcao("Marcar / desmarcar", false, AlternarDisponibilidade);
            AdicionarAcao("Activar / Desactivar", false, AlternarAtivo);

            // no designer nao se toca na base de dados
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                Recarregar();
            }
        }

        public override void Recarregar()
        {
            _aAtualizarFiltros = true;
            try
            {
                RecarregarConteudo();
            }
            finally
            {
                _aAtualizarFiltros = false;
            }
        }

        private void AoMudarFiltro()
        {
            if (_aAtualizarFiltros) return;
            Executar(Recarregar);
        }

        private void RecarregarConteudo()
        {
            _categorias.Clear();
            _categorias.AddRange(_cardapioService.ListarCategorias(false));

            var seleccionada = cmbCategoria.SelectedItem as Categoria;
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add("Todas as categorias");
            foreach (var categoria in _categorias)
            {
                cmbCategoria.Items.Add(categoria);
            }
            cmbCategoria.SelectedItem = seleccionada != null && cmbCategoria.Items.Contains(seleccionada)
                ? seleccionada
                : cmbCategoria.Items[0];

            var categoriaFiltro = cmbCategoria.SelectedItem as Categoria;
            var pratos = _cardapioService.ListarPratos(
                categoriaFiltro == null ? (int?)null : categoriaFiltro.Id,
                chkDisponiveis.Checked,
                false);

            dgvCardapio.Rows.Clear();
            foreach (var prato in pratos)
            {
                var estado = !prato.Ativo ? "Inactivo" : (prato.Disponivel ? "Disponível" : "Esgotado");
                var indice = dgvCardapio.Rows.Add(prato.Nome, prato.CategoriaNome,
                    Tema.Moeda(prato.Preco), prato.Descricao ?? "", estado);
                dgvCardapio.Rows[indice].Tag = prato;
            }

            int disponiveis = 0;
            foreach (var prato in pratos)
            {
                if (prato.Disponivel)
                {
                    disponiveis++;
                }
            }

            DefinirStatus(pratos.Count + " prato(s) - " + disponiveis + " disponível(eis) - "
                + _categorias.Count + " categoria(s)");
        }

        private Prato Selecionado()
        {
            if (dgvCardapio.SelectedRows.Count == 0)
            {
                Aviso("Seleccione um prato.", MessageBoxIcon.Information);
                return null;
            }

            return dgvCardapio.SelectedRows[0].Tag as Prato;
        }

        private void NovoPrato()
        {
            if (!EhGerente)
            {
                Aviso("Apenas o gerente pode criar pratos.", MessageBoxIcon.Warning);
                return;
            }

            using (var dialogo = new DialogoPrato(_cardapioService, null))
            {
                if (dialogo.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                _cardapioService.InserirPrato(dialogo.Prato);
                Recarregar();
                Aviso("Prato '" + dialogo.Prato.Nome + "' criado.", MessageBoxIcon.Information);
            }
        }

        private void EditarSelecionado()
        {
            var prato = Selecionado();
            if (prato == null)
            {
                return;
            }

            if (!EhGerente)
            {
                Aviso("Apenas o gerente pode editar pratos.", MessageBoxIcon.Warning);
                return;
            }

            using (var dialogo = new DialogoPrato(_cardapioService, prato))
            {
                if (dialogo.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                _cardapioService.AtualizarPrato(dialogo.Prato);
                Recarregar();
            }
        }

        private void AlternarDisponibilidade()
        {
            var prato = Selecionado();
            if (prato == null)
            {
                return;
            }

            _cardapioService.AlterarDisponibilidade(prato.Id, !prato.Disponivel);
            Recarregar();
        }

        private void AlternarAtivo()
        {
            var prato = Selecionado();
            if (prato == null)
            {
                return;
            }

            if (!EhGerente)
            {
                Aviso("Apenas o gerente pode activar ou desactivar pratos.", MessageBoxIcon.Warning);
                return;
            }

            _cardapioService.AlterarAtivoPrato(prato.Id, !prato.Ativo);
            Recarregar();
        }
    }
}
