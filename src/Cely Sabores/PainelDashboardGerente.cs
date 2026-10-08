using System;
using System.ComponentModel;
using CelySabores.Business.Exceptions;
using CelySabores.Business.Services;
using CelySabores.Models.Dtos;

namespace Cely_Sabores
{
    /// <summary>
    /// Dashboard administrativo. Exclusivo do gerente (requisito 15).
    /// O layout esta em PainelDashboardGerente.Designer.cs; aqui fica a logica
    /// e a montagem dos cartoes, que so existem depois de vir da base de dados.
    /// </summary>
    public sealed partial class PainelDashboardGerente : PainelBase
    {
        private readonly DashboardService _dashboardService;

        // Construtor usado pelo designer: nao toca na base de dados.
        public PainelDashboardGerente()
            : base("Painel do gerente", "Carregando...")
        {
            InitializeComponent();
        }

        public PainelDashboardGerente(SessaoUsuario sessao, DashboardService dashboardService)
            : this()
        {
            _dashboardService = dashboardService;

            AdicionarAcao("Actualizar", true, Recarregar);

            // no designer nao se toca na base de dados
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                Recarregar();
            }
        }

        public override void Recarregar()
        {
            ResumoDashboard resumo;
            try
            {
                resumo = _dashboardService.ObterResumo();
            }
            catch (RegraNegocioException)
            {
                // falta de permissao ou sessao expirada: nao e um erro de dados.
                // Deixa subir para o PainelBase mostrar a mensagem correcta, em
                // vez de abrir um painel partido (requisito 21).
                throw;
            }
            catch (Exception ex)
            {
                DefinirStatus("Não foi possível carregar o painel: " + ex.Message);
                cartoes.Controls.Clear();
                dgvPratos.Rows.Clear();
                dgvEstoque.Rows.Clear();
                return;
            }

            DefinirStatus("Actualizado em " + Tema.DataHora(resumo.GeradoEm));

            // os cartoes sao recriados a cada recarga: o FlowLayoutPanel do
            // Designer so guarda o contentor
            cartoes.Controls.Clear();
            cartoes.Controls.Add(Tema.Cartao("Vendas do dia", Tema.Moeda(resumo.FaturamentoHoje), Tema.LaranjaEscura));
            cartoes.Controls.Add(Tema.Cartao("Total recebido", Tema.Moeda(resumo.TotalRecebidoHoje), Tema.LaranjaEscura));
            cartoes.Controls.Add(Tema.Cartao("Pedidos do dia", resumo.PedidosFechadosHoje.ToString(), Tema.Texto));
            cartoes.Controls.Add(Tema.Cartao("Pedidos em aberto", resumo.PedidosAbertos.ToString(), Tema.Texto));
            cartoes.Controls.Add(Tema.Cartao("Mesas ocupadas", resumo.MesasOcupadas + " / " + resumo.TotalMesas, Tema.Texto));
            cartoes.Controls.Add(Tema.Cartao("Mesas livres", resumo.MesasLivres.ToString(), Tema.Texto));
            cartoes.Controls.Add(Tema.Cartao("Reservas do dia", resumo.ReservasHoje.ToString(), Tema.Texto));
            cartoes.Controls.Add(Tema.Cartao("Estoque baixo", resumo.IngredientesEstoqueBaixo.ToString(),
                resumo.IngredientesEstoqueBaixo > 0 ? Tema.Perigo : Tema.Texto));
            cartoes.Controls.Add(Tema.Cartao("Funcionários activos", resumo.FuncionariosAtivos.ToString(), Tema.Texto));

            dgvPratos.Rows.Clear();
            foreach (var item in resumo.TopPratos)
            {
                dgvPratos.Rows.Add(item.Nome, item.Quantidade, Tema.Moeda(item.Faturamento));
            }

            dgvEstoque.Rows.Clear();
            foreach (var item in resumo.EstoqueBaixo)
            {
                dgvEstoque.Rows.Add(
                    item.Nome,
                    item.Unidade,
                    item.QuantidadeDisponivel.ToString("0.###"),
                    item.QuantidadeMinima.ToString("0.###"));
            }

            rodape.Text = "Valor em aberto: " + Tema.Moeda(resumo.ValorEmAberto)
                + "   |   Ticket médio: " + Tema.Moeda(resumo.TicketMedioHoje)
                + "   |   Troco hoje: " + Tema.Moeda(resumo.TrocoHoje)
                + "   |   Mesas reservadas: " + resumo.MesasReservadas
                + "   |   Pratos disponíveis: " + resumo.PratosDisponiveis
                + "   |   Indisponíveis: " + resumo.PratosIndisponiveis
                + "   |   Cancelados hoje: " + resumo.PedidosCanceladosHoje;
        }
    }
}
