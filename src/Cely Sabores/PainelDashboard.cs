using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CelySabores.Business.Services;
using CelySabores.Models.Dtos;
using CelySabores.Models.Enums;

namespace Cely_Sabores
{
    public sealed class PainelDashboard : PainelBase
    {
        private readonly SessaoUsuario _sessao;
        private readonly DashboardService _dashboardService;
        private readonly FlowLayoutPanel _cartoes;
        private readonly Panel _areaTopo;
        private readonly DataGridView _tabela;

        public PainelDashboard(SessaoUsuario sessao, DashboardService dashboardService)
            : base("Bem-vindo(a), " + sessao.FuncionarioNome + "!", "Carregando...")
        {
            _sessao = sessao;
            _dashboardService = dashboardService;
            BackColor = Tema.Fundo;

            _areaTopo = new Panel
            {
                Dock = DockStyle.Top,
                Height = 116,
                AutoScroll = true,
                BackColor = Tema.Fundo
            };

            _cartoes = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                AutoScroll = true,
                BackColor = Tema.Fundo
            };
            _areaTopo.Controls.Add(_cartoes);

            _tabela = Tema.Tabela("Prato", "Qtd", "Faturamento");
            _tabela.Columns[0].FillWeight = 60;
            _tabela.Columns[1].FillWeight = 15;
            _tabela.Columns[2].FillWeight = 25;
            _tabela.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var lblRanking = Tema.Titulo("Pratos mais vendidos", 13F, true);
            lblRanking.Dock = DockStyle.Top;
            lblRanking.Height = 28;

            var rodape = new Label
            {
                Dock = DockStyle.Bottom,
                Height = 26,
                AutoSize = false,
                ForeColor = Tema.TextoSuave,
                Font = new Font("Segoe UI", 9F),
                TextAlign = ContentAlignment.MiddleLeft
            };
            _rodape = rodape;

            Conteudo.Controls.Add(_tabela);
            Conteudo.Controls.Add(lblRanking);
            Conteudo.Controls.Add(rodape);
            Conteudo.Controls.Add(_areaTopo);

            AdicionarAcao("Actualizar", true, Recarregar);

            Recarregar();
        }

        private readonly Label _rodape;

        public override void Recarregar()
        {
            ResumoDashboard resumo;
            try
            {
                resumo = _dashboardService.ObterResumo();
            }
            catch (Exception ex)
            {
                DefinirStatus("Não foi possível carregar o resumo: " + ex.Message);
                _cartoes.Controls.Clear();
                _tabela.Rows.Clear();
                return;
            }

            DefinirStatus("Actualizado em " + Tema.DataHora(resumo.GeradoEm)
                + (_sessao.EhGerente ? "" : "  (visão de atendente)"));

            _cartoes.Controls.Clear();
            _cartoes.Controls.Add(Tema.Cartao("Faturamento hoje", Tema.Moeda(resumo.FaturamentoHoje), Tema.LaranjaEscura));
            _cartoes.Controls.Add(Tema.Cartao("Pedidos fechados", resumo.PedidosFechadosHoje.ToString(), Tema.Texto));
            _cartoes.Controls.Add(Tema.Cartao("Pedidos em aberto", resumo.PedidosAbertos.ToString(), Tema.Texto));
            _cartoes.Controls.Add(Tema.Cartao("Valor em aberto", Tema.Moeda(resumo.ValorEmAberto), Tema.Texto));
            _cartoes.Controls.Add(Tema.Cartao("Mesas livres", resumo.MesasLivres + " / " + resumo.TotalMesas, Tema.Texto));
            _cartoes.Controls.Add(Tema.Cartao("Mesas ocupadas", resumo.MesasOcupadas.ToString(), Tema.Texto));
            _cartoes.Controls.Add(Tema.Cartao("Mesas reservadas", resumo.MesasReservadas.ToString(), Tema.Texto));
            _cartoes.Controls.Add(Tema.Cartao("Ticket médio", Tema.Moeda(resumo.TicketMedioHoje), Tema.Texto));

            _tabela.Rows.Clear();
            foreach (var item in resumo.TopPratos)
            {
                _tabela.Rows.Add(item.Nome, item.Quantidade, Tema.Moeda(item.Faturamento));
            }

            _rodape.Text = "Pratos disponíveis: " + resumo.PratosDisponiveis
                + "   |   Indisponíveis: " + resumo.PratosIndisponiveis
                + "   |   Cancelados hoje: " + resumo.PedidosCanceladosHoje;
        }
    }
}
