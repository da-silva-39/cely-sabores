using System;
using System.ComponentModel;
using CelySabores.Business.Services;
using CelySabores.Models.Dtos;

namespace Cely_Sabores
{
    /// <summary>
    /// Dashboard operacional do atendente. Mostra apenas o necessario para o
    /// atendimento: mesas, pedidos em aberto, reservas proximas e atendimentos
    /// em andamento. Nao mostra faturamento, relatorios ou qualquer outra
    /// funcao administrativa (requisito 15).
    /// O layout esta em PainelDashboardFuncionario.Designer.cs; aqui fica a
    /// logica e a montagem dos cartoes, que so existem depois de vir da base
    /// de dados.
    /// </summary>
    public sealed partial class PainelDashboardFuncionario : PainelBase
    {
        private readonly DashboardService _dashboardService;

        // Construtor usado pelo designer: nao toca na base de dados e mostra
        // um titulo sem nome, porque aqui nao ha sessao.
        public PainelDashboardFuncionario()
            : base("Bom trabalho!", "Carregando...")
        {
            InitializeComponent();
        }

        public PainelDashboardFuncionario(SessaoUsuario sessao, DashboardService dashboardService)
            : this()
        {
            _dashboardService = dashboardService;

            DefinirTitulo("Bom trabalho, " + sessao.FuncionarioNome + "!");

            AdicionarAcao("Actualizar", true, Recarregar);

            // no designer nao se toca na base de dados
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                Recarregar();
            }
        }

        public override void Recarregar()
        {
            ResumoOperacional resumo;
            try
            {
                resumo = _dashboardService.ObterResumoOperacional();
            }
            catch (Exception ex)
            {
                DefinirStatus("Não foi possível carregar o painel: " + ex.Message);
                cartoes.Controls.Clear();
                dgvAtendimentos.Rows.Clear();
                dgvReservas.Rows.Clear();
                return;
            }

            DefinirStatus("Actualizado em " + Tema.DataHora(resumo.GeradoEm));

            // os cartoes sao recriados a cada recarga: o FlowLayoutPanel do
            // Designer so guarda o contentor
            cartoes.Controls.Clear();
            cartoes.Controls.Add(Tema.Cartao("Mesas livres", resumo.MesasLivres + " / " + resumo.TotalMesas, Tema.Texto));
            cartoes.Controls.Add(Tema.Cartao("Em atendimento", resumo.MesasEmAtendimento.ToString(), Tema.Texto));
            cartoes.Controls.Add(Tema.Cartao("Aguardando pagamento", resumo.MesasAguardandoPagamento.ToString(),
                resumo.MesasAguardandoPagamento > 0 ? Tema.LaranjaEscura : Tema.Texto));
            cartoes.Controls.Add(Tema.Cartao("Pedidos em aberto", resumo.PedidosAbertos.ToString(), Tema.Texto));
            cartoes.Controls.Add(Tema.Cartao("Os meus pedidos", resumo.MeusPedidosAbertos.ToString(), Tema.Texto));
            cartoes.Controls.Add(Tema.Cartao("Reservas próximas", resumo.ReservasProximasTotal.ToString(), Tema.Texto));

            dgvAtendimentos.Rows.Clear();
            foreach (var item in resumo.Atendimentos)
            {
                var indice = dgvAtendimentos.Rows.Add(
                    item.MesaNumero.ToString(),
                    item.ClienteNome ?? "(sem cliente)",
                    Tema.Moeda(item.ValorTotal),
                    TempoPorExtenso(item.TempoDecorrido),
                    "#" + item.PedidoId);
                dgvAtendimentos.Rows[indice].Tag = item;
                if (item.MeuAtendimento)
                {
                    dgvAtendimentos.Rows[indice].DefaultCellStyle.BackColor = Tema.CartaoSelecao;
                }
            }

            dgvReservas.Rows.Clear();
            foreach (var item in resumo.ReservasProximas)
            {
                dgvReservas.Rows.Add(
                    item.DataHora.ToString("HH:mm"),
                    item.ClienteNome,
                    item.NumeroPessoas.ToString(),
                    item.MesaNumero.HasValue ? item.MesaNumero.Value.ToString() : "-",
                    item.Estado.ToString());
            }

            rodape.Text = resumo.MinutosParaProximaReserva < 0
                ? "Sem reservas nas próximas horas."
                : "Próxima reserva em " + MinutosPorExtenso(resumo.MinutosParaProximaReserva)
                    + "  |  As linhas destacadas são atendimentos abertos por si.";
        }

        private static string TempoPorExtenso(TimeSpan tempo)
        {
            if (tempo.TotalMinutes < 1)
            {
                return "agora";
            }

            if (tempo.TotalHours < 1)
            {
                return (int)tempo.TotalMinutes + " min";
            }

            return ((int)tempo.TotalHours) + "h" + (tempo.Minutes > 0 ? " " + tempo.Minutes + "min" : "");
        }

        private static string MinutosPorExtenso(int minutos)
        {
            if (minutos < 60)
            {
                return minutos + " min";
            }

            return (minutos / 60) + "h" + (minutos % 60 > 0 ? " " + (minutos % 60) + "min" : "");
        }
    }
}
