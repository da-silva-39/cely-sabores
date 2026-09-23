using System;

namespace CelySabores.Models.Entities
{
    public class Pagamento
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public decimal ValorRecebido { get; set; }
        public decimal Troco { get; set; }
        public DateTime DataPagamento { get; set; }
        public int FuncionarioId { get; set; }
        public int MesaNumero { get; set; }
        public string FuncionarioNome { get; set; }
    }
}