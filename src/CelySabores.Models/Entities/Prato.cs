namespace CelySabores.Models.Entities
{
    public class Prato
    {
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string Imagem { get; set; }
        public bool Disponivel { get; set; }
        public bool Ativo { get; set; }
        public string CategoriaNome { get; set; }
    }
}