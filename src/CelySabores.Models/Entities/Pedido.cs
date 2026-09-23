using System;
using CelySabores.Models.Enums;

namespace CelySabores.Models.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public int MesaId { get; set; }
        public int? ClienteId { get; set; }
        public int FuncionarioAberturaId { get; set; }
        public DateTime DataAbertura { get; set; }
        public EstadoPedido Estado { get; set; }
        public decimal ValorTotal { get; set; }
        public string Observacao { get; set; }
        public DateTime? DataFechamento { get; set; }
        public int? FuncionarioFechamentoId { get; set; }
        public int MesaNumero { get; set; }
        public string MesaNome { get; set; }
        public string ClienteNome { get; set; }
        public string FuncionarioNome { get; set; }
    }
}