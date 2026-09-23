namespace CelySabores.Models.Entities
{
    public class ReceitaPrato
    {
        public int Id { get; set; }
        public int PratoId { get; set; }
        public int IngredienteId { get; set; }
        public decimal Quantidade { get; set; }
    }
}