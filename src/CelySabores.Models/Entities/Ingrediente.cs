namespace CelySabores.Models.Entities
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Unidade { get; set; }
        public decimal QuantidadeDisponivel { get; set; }
        public decimal QuantidadeMinima { get; set; }
        public decimal PrecoCusto { get; set; }
        public bool Ativo { get; set; }
    }
}