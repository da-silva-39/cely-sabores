using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CelySabores.Business.Services;
using CelySabores.Models.Entities;
using CelySabores.Models.Enums;

namespace Cely_Sabores
{
    public sealed class PainelPedidos : PainelBase
    {
        private readonly PedidoService _pedidoService;
        private readonly DataGridView _tabela;
        private readonly ComboBox _filtroEstado;

        public PainelPedidos(PedidoService pedidoService) : base("Pedidos", "Carregando...")
        {
            _pedidoService = pedidoService;

            _filtroEstado = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 170,
                Font = new Font("Segoe UI", 9.5F),
                Margin = new Padding(0, 0, 10, 0)
            };
            _filtroEstado.Items.AddRange(new object[] { "Todos", "Abertos", "Fechados", "Cancelados" });
            _filtroEstado.SelectedIndex = 0;
            _filtroEstado.SelectedIndexChanged += (s, ev) => Executar(Recarregar);

            var filtros = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 42,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                BackColor = Tema.Fundo
            };
            filtros.Controls.Add(_filtroEstado);

            _tabela = Tema.Tabela("Nº", "Mesa", "Cliente", "Aberto em", "Estado", "Total");
            _tabela.Columns[0].FillWeight = 8;
            _tabela.Columns[1].FillWeight = 10;
            _tabela.Columns[2].FillWeight = 26;
            _tabela.Columns[3].FillWeight = 22;
            _tabela.Columns[4].FillWeight = 16;
            _tabela.Columns[5].FillWeight = 18;
            _tabela.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _tabela.CellDoubleClick += (s, ev) => Executar(AbrirSelecionado);

            Conteudo.Controls.Add(_tabela);
            Conteudo.Controls.Add(filtros);

            AdicionarAcao("Actualizar", false, Recarregar);
            AdicionarAcao("Abrir pedido", true, AbrirPedido);
            AdicionarAcao("Ver / gerir", false, AbrirSelecionado);
            AdicionarAcao("Cancelar pedido", false, CancelarSelecionado);

            Recarregar();
        }

        public override void Recarregar()
        {
            EstadoPedido? estado = null;
            switch (_filtroEstado.SelectedIndex)
            {
                case 1: estado = EstadoPedido.Aberto; break;
                case 2: estado = EstadoPedido.Fechado; break;
                case 3: estado = EstadoPedido.Cancelado; break;
            }

            var pedidos = _pedidoService.Listar(estado, null, null);
            _tabela.Rows.Clear();

            foreach (var pedido in pedidos)
            {
                var indice = _tabela.Rows.Add(
                    pedido.Id,
                    pedido.MesaNumero,
                    string.IsNullOrEmpty(pedido.ClienteNome) ? "(balcão)" : pedido.ClienteNome,
                    Tema.DataHora(pedido.DataAbertura),
                    DescreverEstado(pedido.Estado),
                    Tema.Moeda(pedido.ValorTotal));

                _tabela.Rows[indice].Tag = pedido;
            }

            DefinirStatus(pedidos.Count + " pedido(s)");
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

        private Pedido Selecionado()
        {
            if (_tabela.SelectedRows.Count == 0)
            {
                Aviso("Seleccione um pedido.", MessageBoxIcon.Information);
                return null;
            }

            return _tabela.SelectedRows[0].Tag as Pedido;
        }

        private void AbrirPedido()
        {
            using (var dialogo = new DialogoAbrirPedido(_pedidoService))
            {
                if (dialogo.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                var pedido = dialogo.Pedido;
                Recarregar();
                AbrirDetalhe(pedido);
            }
        }

        private void AbrirSelecionado()
        {
            var pedido = Selecionado();
            if (pedido == null)
            {
                return;
            }

            AbrirDetalhe(pedido);
        }

        private void AbrirDetalhe(Pedido pedido)
        {
            using (var detalhe = new PainelPedidoDetalhe(_pedidoService, pedido))
            {
                detalhe.ShowDialog(this);
            }

            Recarregar();
        }

        private void CancelarSelecionado()
        {
            var pedido = Selecionado();
            if (pedido == null)
            {
                return;
            }

            if (Confirmar("Cancelar o pedido " + pedido.Id + " da mesa " + pedido.MesaNumero + "?") != DialogResult.Yes)
            {
                return;
            }

            _pedidoService.Cancelar(pedido.Id);
            Recarregar();
        }
    }
}
