using System;
using System.Collections.Generic;
using CelySabores.Models.Enums;

namespace CelySabores.Models.Dtos
{
    public class ItemTopPrato
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Faturamento { get; set; }
    }

    public class ItemEstoqueBaixo
    {
        public string Nome { get; set; }
        public string Unidade { get; set; }
        public decimal QuantidadeDisponivel { get; set; }
        public decimal QuantidadeMinima { get; set; }
    }

    /// <summary>
    /// Dashboard administrativo. Exclusivo do gerente (requisito 15).
    /// </summary>
    public class ResumoDashboard
    {
        public DateTime GeradoEm { get; set; }

        public int PedidosAbertos { get; set; }
        public int PedidosFechadosHoje { get; set; }
        public int PedidosCanceladosHoje { get; set; }
        public int MesasLivres { get; set; }
        public int MesasOcupadas { get; set; }
        public int MesasReservadas { get; set; }
        public int TotalMesas { get; set; }
        public int PratosDisponiveis { get; set; }
        public int PratosIndisponiveis { get; set; }
        public decimal FaturamentoHoje { get; set; }
        public decimal TicketMedioHoje { get; set; }
        public decimal ValorEmAberto { get; set; }

        /// <summary>Soma de Pagamentos.ValorRecebido do dia (diferente de vendas).</summary>
        public decimal TotalRecebidoHoje { get; set; }

        /// <summary>Total de troco devolvido no dia.</summary>
        public decimal TrocoHoje { get; set; }

        public int ReservasHoje { get; set; }
        public int FuncionariosAtivos { get; set; }
        public int IngredientesEstoqueBaixo { get; set; }

        public IList<ItemTopPrato> TopPratos { get; set; }
        public IList<ItemEstoqueBaixo> EstoqueBaixo { get; set; }

        public ResumoDashboard()
        {
            TopPratos = new List<ItemTopPrato>();
            EstoqueBaixo = new List<ItemEstoqueBaixo>();
        }
    }

    public class ItemAtendimento
    {
        public int PedidoId { get; set; }
        public int MesaNumero { get; set; }
        public string ClienteNome { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataAbertura { get; set; }
        public TimeSpan TempoDecorrido { get; set; }
        public bool MeuAtendimento { get; set; }
    }

    public class ItemReservaProxima
    {
        public int ReservaId { get; set; }
        public string ClienteNome { get; set; }
        public string ClienteTelefone { get; set; }
        public DateTime DataHora { get; set; }
        public int NumeroPessoas { get; set; }
        public int? MesaNumero { get; set; }
        public EstadoReserva Estado { get; set; }
    }

    /// <summary>
    /// Dashboard operacional do atendente. Sem qualquer dado administrativo
    /// (requisito 15: "Nao mostrar funcoes administrativas ao funcionario").
    /// </summary>
    public class ResumoOperacional
    {
        public DateTime GeradoEm { get; set; }

        public int TotalMesas { get; set; }
        public int MesasLivres { get; set; }
        public int MesasEmAtendimento { get; set; }
        public int MesasAguardandoPagamento { get; set; }
        public int MesasReservadas { get; set; }

        /// <summary>Pedidos abertos na casa (todos os funcionarios).</summary>
        public int PedidosAbertos { get; set; }

        /// <summary>Pedidos abertos abertos pelo proprio funcionario.</summary>
        public int MeusPedidosAbertos { get; set; }

        public int ReservasProximasTotal { get; set; }

        /// <summary>Minutos que faltam para a reserva mais proxima. -1 se nao houver.</summary>
        public int MinutosParaProximaReserva { get; set; }

        public IList<ItemAtendimento> Atendimentos { get; set; }
        public IList<ItemReservaProxima> ReservasProximas { get; set; }

        public ResumoOperacional()
        {
            Atendimentos = new List<ItemAtendimento>();
            ReservasProximas = new List<ItemReservaProxima>();
            MinutosParaProximaReserva = -1;
        }
    }
}
