using System;
using System.Collections.Generic;

namespace CelySabores.Models.Dtos
{
    public class ItemTopPrato
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Faturamento { get; set; }
    }

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

        public IList<ItemTopPrato> TopPratos { get; set; }

        public ResumoDashboard()
        {
            TopPratos = new List<ItemTopPrato>();
        }
    }
}
