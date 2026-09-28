using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CelySabores.Business.Services;
using CelySabores.Models.Entities;

namespace Cely_Sabores
{
    public sealed class PainelCardapio : PainelBase
    {
        private readonly CardapioService _cardapioService;
        private readonly DataGridView _tabela;
        private readonly ComboBox _filtroCategoria;
        private readonly CheckBox _apenasDisponiveis;
        private readonly List<Categoria> _categorias = new List<Categoria>();
        private bool _aAtualizarFiltros;

        public PainelCardapio(CardapioService cardapioService)
            : base("Cardápio", "Carregando...")
        {
            _cardapioService = cardapioService;

            _filtroCategoria = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 190,
                Font = new Font("Segoe UI", 9.5F),
                Margin = new Padding(0, 0, 10, 0)
            };
            _filtroCategoria.SelectedIndexChanged += (s, ev) => AoMudarFiltro();

            _apenasDisponiveis = new CheckBox
            {
                Text = "Só disponíveis",
                AutoSize = true,
                ForeColor = Tema.TextoSuave,
                Font = new Font("Segoe UI", 9.5F),
                Margin = new Padding(0, 7, 12, 0)
            };
            _apenasDisponiveis.CheckedChanged += (s, ev) => AoMudarFiltro();

            var filtros = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 42,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                BackColor = Tema.Fundo
            };
            filtros.Controls.Add(_filtroCategoria);
            filtros.Controls.Add(_apenasDisponiveis);

            _tabela = Tema.Tabela("Prato", "Categoria", "Preço", "Descrição", "Estado");
            _tabela.Columns[0].FillWeight = 26;
            _tabela.Columns[1].FillWeight = 18;
            _tabela.Columns[2].FillWeight = 14;
            _tabela.Columns[3].FillWeight = 30;
            _tabela.Columns[4].FillWeight = 12;
            _tabela.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _tabela.CellDoubleClick += (s, ev) => Executar(EditarSelecionado);

            Conteudo.Controls.Add(_tabela);
            Conteudo.Controls.Add(filtros);

            AdicionarAcao("Actualizar", false, Recarregar);
            AdicionarAcao("Novo prato", true, NovoPrato);
            AdicionarAcao("Editar prato", false, EditarSelecionado);
            AdicionarAcao("Marcar / desmarcar", false, AlternarDisponibilidade);
            AdicionarAcao("Activar / Desactivar", false, AlternarAtivo);

            Recarregar();
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

            var seleccionada = _filtroCategoria.SelectedItem as Categoria;
            _filtroCategoria.Items.Clear();
            _filtroCategoria.Items.Add("Todas as categorias");
            foreach (var categoria in _categorias)
            {
                _filtroCategoria.Items.Add(categoria);
            }
            _filtroCategoria.SelectedItem = seleccionada != null && _filtroCategoria.Items.Contains(seleccionada)
                ? seleccionada
                : _filtroCategoria.Items[0];

            var categoriaFiltro = _filtroCategoria.SelectedItem as Categoria;
            var pratos = _cardapioService.ListarPratos(
                categoriaFiltro == null ? (int?)null : categoriaFiltro.Id,
                _apenasDisponiveis.Checked,
                false);

            _tabela.Rows.Clear();
            foreach (var prato in pratos)
            {
                var estado = !prato.Ativo ? "Inactivo" : (prato.Disponivel ? "Disponível" : "Esgotado");
                var indice = _tabela.Rows.Add(prato.Nome, prato.CategoriaNome,
                    Tema.Moeda(prato.Preco), prato.Descricao ?? "", estado);
                _tabela.Rows[indice].Tag = prato;
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
            if (_tabela.SelectedRows.Count == 0)
            {
                Aviso("Seleccione um prato.", MessageBoxIcon.Information);
                return null;
            }

            return _tabela.SelectedRows[0].Tag as Prato;
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
