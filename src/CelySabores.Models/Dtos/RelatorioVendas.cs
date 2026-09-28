using System;
using System.Collections.Generic;

namespace CelySabores.Models.Dtos
{
    public class VendaPorDia
    {
        public DateTime Dia { get; set; }
        public int PedidosFechados { get; set; }
        public decimal Faturamento { get; set; }
        public decimal TicketMedio { get; set; }
    }

    public class VendaPorFuncionario
    {
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public int PedidosFechados { get; set; }
        public decimal Faturamento { get; set; }
        public decimal TotalRecebido { get; set; }
        public decimal TotalTroco { get; set; }
    }

    public class VendaPorPrato
    {
        public int IdPrato { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Faturamento { get; set; }
    }

    public class RelatorioVendas
    {
        public DateTime De { get; set; }
        public DateTime Ate { get; set; }
        public DateTime GeradoEm { get; set; }

        public int PedidosFechados { get; set; }
        public int PedidosCancelados { get; set; }
        public int ItensVendidos { get; set; }
        public decimal Faturamento { get; set; }
        public decimal TicketMedio { get; set; }
        public decimal TotalRecebido { get; set; }
        public decimal TotalTroco { get; set; }
        public decimal ValorMedioPrato { get; set; }

        public IList<VendaPorDia> PorDia { get; set; }
        public IList<VendaPorFuncionario> PorFuncionario { get; set; }
        public IList<VendaPorPrato> PorPrato { get; set; }

        public RelatorioVendas()
        {
            PorDia = new List<VendaPorDia>();
            PorFuncionario = new List<VendaPorFuncionario>();
            PorPrato = new List<VendaPorPrato>();
        }
    }
}
