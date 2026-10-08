namespace CelySabores.Models.Entities
{
    public class ReceitaPrato
    {
        public int Id { get; set; }
        public int PratoId { get; set; }
        public int IngredienteId { get; set; }
        public decimal Quantidade { get; set; }

        /// <summary>Apenas para listar a receita com o nome do ingrediente.</summary>
        public string IngredienteNome { get; set; }

        /// <summary>Unidade do ingrediente, para mostrar a quantidade com sentido.</summary>
        public string IngredienteUnidade { get; set; }
    }
}