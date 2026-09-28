namespace CelySabores.Models.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public int Ordem { get; set; }

        public override string ToString()
        {
            return string.IsNullOrWhiteSpace(Nome) ? "(categoria)" : Nome;
        }
    }
}