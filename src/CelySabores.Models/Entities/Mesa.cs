using CelySabores.Models.Enums;

namespace CelySabores.Models.Entities
{
    public class Mesa
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int Capacidade { get; set; }
        public EstadoMesa Estado { get; set; }
        public bool Ativo { get; set; }
        public string Observacoes { get; set; }

        public override string ToString()
        {
            return "Mesa " + Numero;
        }
    }
}