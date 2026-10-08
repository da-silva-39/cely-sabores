using System;
using System.Collections.Generic;
using CelySabores.Models.Entities;

namespace CelySabores.Models.Dtos
{
    public class ReservaPorDia
    {
        public DateTime Dia { get; set; }
        public int Reservas { get; set; }
        public int Pessoas { get; set; }
        public int Confirmadas { get; set; }
        public int Compareceram { get; set; }
        public int Canceladas { get; set; }
    }

    public class ReservaPorEstado
    {
        public string Estado { get; set; }
        public int Reservas { get; set; }
        public int Pessoas { get; set; }
    }

    public class RelatorioReservas
    {
        public int Total { get; set; }
        public int Confirmadas { get; set; }
        public int Compareceram { get; set; }
        public int Canceladas { get; set; }
        public int PessoasPrevistas { get; set; }
        public int PessoasPerdidas { get; set; }

        public IList<ReservaPorDia> PorDia { get; set; }
        public IList<ReservaPorEstado> PorEstado { get; set; }

        public RelatorioReservas()
        {
            PorDia = new List<ReservaPorDia>();
            PorEstado = new List<ReservaPorEstado>();
        }
    }

    public class MesaUtilizada
    {
        public int IdMesa { get; set; }
        public int Numero { get; set; }
        public int Capacidade { get; set; }
        public int Pedidos { get; set; }
        public decimal Faturamento { get; set; }
        public decimal TicketMedio { get; set; }
    }

    public class RelatorioMesas
    {
        public int MesasAtivas { get; set; }
        public int MesasUtilizadas { get; set; }
        public int MesasOcupadasAgora { get; set; }
        public decimal PercentagemOcupacao { get; set; }
        public decimal Faturamento { get; set; }
        public decimal TicketMedio { get; set; }

        public IList<MesaUtilizada> PorMesa { get; set; }

        public RelatorioMesas()
        {
            PorMesa = new List<MesaUtilizada>();
        }
    }

    public class RelatorioEstoque
    {
        public int IngredientesActivos { get; set; }
        public int IngredientesBaixo { get; set; }
        public decimal ValorReposicao { get; set; }

        public IList<Ingrediente> Baixo { get; set; }

        public RelatorioEstoque()
        {
            Baixo = new List<Ingrediente>();
        }
    }

    public class RelatorioCompleto
    {
        public DateTime De { get; set; }
        public DateTime Ate { get; set; }
        public DateTime GeradoEm { get; set; }

        public RelatorioVendas Vendas { get; set; }
        public RelatorioReservas Reservas { get; set; }
        public RelatorioMesas Mesas { get; set; }
        public RelatorioEstoque Estoque { get; set; }
    }
}
