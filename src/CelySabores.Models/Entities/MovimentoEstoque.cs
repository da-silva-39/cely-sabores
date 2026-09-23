using System;
using CelySabores.Models.Enums;

namespace CelySabores.Models.Entities
{
    public class MovimentoEstoque
    {
        public int Id { get; set; }
        public int IngredienteId { get; set; }
        public TipoMovimentoEstoque Tipo { get; set; }
        public decimal Quantidade { get; set; }
        public DateTime Data { get; set; }
        public string Observacao { get; set; }
        public int? PedidoId { get; set; }
        public int? FuncionarioId { get; set; }
        public string IngredienteNome { get; set; }
    }
}