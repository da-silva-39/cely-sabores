namespace CelySabores.Models.Entities
{
    public class ItemPedido
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int PratoId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public string Observacao { get; set; }
        public string PratoNome { get; set; }
    }
}