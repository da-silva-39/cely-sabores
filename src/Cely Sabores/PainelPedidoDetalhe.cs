using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CelySabores.Business.Exceptions;
using CelySabores.Business.Services;
using CelySabores.Models.Entities;
using CelySabores.Models.Enums;

namespace Cely_Sabores
{
    public sealed class PainelPedidoDetalhe : Form
    {
        private readonly PedidoService _pedidoService;
        private readonly int _pedidoId;
        private readonly DataGridView _cardapio;
        private readonly DataGridView _itens;
        private readonly Label _cabecalho;
        private readonly Label _total;

        public PainelPedidoDetalhe(PedidoService pedidoService, Pedido pedido)
        {
            _pedidoService = pedidoService;
            _pedidoId = pedido.Id;

            Text = "Pedido " + pedido.Id + " - Mesa " + pedido.MesaNumero;
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(1080, 660);
            MinimumSize = new Size(940, 600);
            BackColor = Tema.Fundo;
            Font = new Font("Segoe UI", 10F);
            ShowInTaskbar = false;

            _cabecalho = new Label
            {
                Dock = DockStyle.Top,
                Height = 56,
                ForeColor = Tema.Texto,
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(0, 0, 0, 0)
            };

            // ---- cardapio (esquerda) ----
            _cardapio = Tema.Tabela("Prato", "Preço");
            _cardapio.Columns[0].FillWeight = 70;
            _cardapio.Columns[1].FillWeight = 30;
            _cardapio.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _cardapio.CellDoubleClick += (s, ev) => Executar(AdicionarPratoSelecionado);

            var lblCardapio = Tema.Titulo("Cardápio (duplo clique para adicionar)", 11F, true);
            lblCardapio.Dock = DockStyle.Top;
            lblCardapio.Height = 26;

            var esquerda = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0, 0, 10, 0) };
            esquerda.Controls.Add(_cardapio);
            esquerda.Controls.Add(lblCardapio);

            // ---- itens (direita) ----
            _itens = Tema.Tabela("Item", "Qtd", "P. Unit.", "Subtotal");
            _itens.Columns[0].FillWeight = 50;
            _itens.Columns[1].FillWeight = 12;
            _itens.Columns[2].FillWeight = 18;
            _itens.Columns[3].FillWeight = 20;
            _itens.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _itens.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _itens.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var lblItens = Tema.Titulo("Itens do pedido", 11F, true);
            lblItens.Dock = DockStyle.Top;
            lblItens.Height = 26;

            _total = new Label
            {
                Dock = DockStyle.Bottom,
                Height = 34,
                TextAlign = ContentAlignment.MiddleRight,
                ForeColor = Tema.LaranjaEscura,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold)
            };

            var direita = new Panel { Dock = DockStyle.Fill, Padding = new Padding(10, 0, 0, 0) };
            direita.Controls.Add(_itens);
            direita.Controls.Add(lblItens);
            direita.Controls.Add(_total);

            var corpo = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                BackColor = Tema.Fundo
            };
            corpo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            corpo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            corpo.Controls.Add(esquerda, 0, 0);
            corpo.Controls.Add(direita, 1, 0);

            // ---- barra de accoes ----
            var barra = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                Height = 56,
                FlowDirection = FlowDirection.RightToLeft,
                WrapContents = false,
                BackColor = Color.White,
                Padding = new Padding(10, 10, 10, 0)
            };

            var btnPagar = Tema.Botao("Registar pagamento", true);
            btnPagar.Click += (s, ev) => Executar(Pagar);
            var btnCancelar = Tema.Botao("Cancelar pedido", false);
            btnCancelar.Click += (s, ev) => Executar(Cancelar);
            var btnQtd = Tema.Botao("+/- quantidade", false);
            btnQtd.Click += (s, ev) => Executar(AlterarQuantidade);
            var btnRemover = Tema.Botao("Remover item", false);
            btnRemover.Click += (s, ev) => Executar(RemoverItem);
            var btnAdd = Tema.Botao("Adicionar item", false);
            btnAdd.Click += (s, ev) => Executar(AdicionarPratoSelecionado);
            var btnFechar = Tema.Botao("Fechar", false);
            btnFechar.Click += (s, ev) => Close();

            barra.Controls.Add(btnFechar);
            barra.Controls.Add(btnPagar);
            barra.Controls.Add(btnCancelar);
            barra.Controls.Add(btnQtd);
            barra.Controls.Add(btnRemover);
            barra.Controls.Add(btnAdd);

            Controls.Add(corpo);
            Controls.Add(_cabecalho);
            Controls.Add(barra);

            Recarregar();
        }

        private void Executar(Action acao)
        {
            try
            {
                acao();
            }
            catch (RegraNegocioException ex)
            {
                MessageBox.Show(ex.Message, "Cely Sabores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message, "Cely Sabores",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Recarregar()
        {
            var pedido = _pedidoService.ObterPorId(_pedidoId);
            var itens = _pedidoService.ListarItens(_pedidoId);

            _cabecalho.Text = "Pedido " + pedido.Id + "   |   Mesa " + pedido.MesaNumero
                + "   |   " + DescreverEstado(pedido.Estado)
                + "   |   " + (string.IsNullOrEmpty(pedido.ClienteNome) ? "Cliente: balcão" : "Cliente: " + pedido.ClienteNome)
                + "   |   Aberto por " + pedido.FuncionarioNome
                + "   |   " + Tema.DataHora(pedido.DataAbertura);

            _itens.Rows.Clear();
            foreach (var item in itens)
            {
                _itens.Rows.Add(
                    item.PratoNome + (string.IsNullOrEmpty(item.Observacao) ? "" : "  (" + item.Observacao + ")"),
                    item.Quantidade,
                    Tema.Moeda(item.PrecoUnitario),
                    Tema.Moeda(item.Subtotal));
            }

            _total.Text = "Total: " + Tema.Moeda(pedido.ValorTotal);

            _cardapio.Rows.Clear();
            foreach (var prato in _pedidoService.ListarPratosDisponiveis())
            {
                var indice = _cardapio.Rows.Add(prato.Nome, Tema.Moeda(prato.Preco));
                _cardapio.Rows[indice].Tag = prato;
            }
        }

        private static string DescreverEstado(EstadoPedido estado)
        {
            switch (estado)
            {
                case EstadoPedido.Aberto: return "Aberto";
                case EstadoPedido.Fechado: return "Fechado";
                case EstadoPedido.Cancelado: return "Cancelado";
                default: return estado.ToString();
            }
        }

        private void AdicionarPratoSelecionado()
        {
            if (_cardapio.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione um prato do cardápio.", "Cely Sabores",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var prato = _cardapio.SelectedRows[0].Tag as Prato;
            using (var dialogo = new DialogoQuantidade(prato))
            {
                if (dialogo.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                _pedidoService.AdicionarItem(_pedidoId, prato.Id, dialogo.Quantidade, dialogo.Observacao);
            }

            Recarregar();
        }

        private void AlterarQuantidade()
        {
            var item = ItemSeleccionado();
            if (item == null)
            {
                return;
            }

            using (var dialogo = new DialogoQuantidade(null, item.Quantidade))
            {
                if (dialogo.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                if (dialogo.Quantidade <= 0)
                {
                    _pedidoService.RemoverItem(item.Id);
                }
                else
                {
                    _pedidoService.AlterarQuantidade(item.Id, dialogo.Quantidade);
                }
            }

            Recarregar();
        }

        private void RemoverItem()
        {
            var item = ItemSeleccionado();
            if (item == null)
            {
                return;
            }

            if (MessageBox.Show("Remover '" + item.PratoNome + "' do pedido?", "Cely Sabores",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            _pedidoService.RemoverItem(item.Id);
            Recarregar();
        }

        private ItemPedido ItemSeleccionado()
        {
            if (_itens.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione um item do pedido.", "Cely Sabores",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            var linha = _itens.SelectedRows[0].Index;
            var itens = _pedidoService.ListarItens(_pedidoId);
            return linha >= 0 && linha < itens.Count ? itens[linha] : null;
        }

        private void Pagar()
        {
            var pedido = _pedidoService.ObterPorId(_pedidoId);
            using (var dialogo = new DialogoPagamento(pedido))
            {
                if (dialogo.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                var pagamento = _pedidoService.RegistarPagamento(_pedidoId, dialogo.ValorRecebido);
                MessageBox.Show(
                    "Pagamento registado. Troco: " + Tema.Moeda(pagamento.Troco),
                    "Cely Sabores", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Recarregar();
        }

        private void Cancelar()
        {
            if (MessageBox.Show("Cancelar este pedido? A mesa será libertada.",
                    "Cely Sabores", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            _pedidoService.Cancelar(_pedidoId);
            Recarregar();
        }
    }
}
