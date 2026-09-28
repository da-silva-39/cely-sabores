using System;

namespace CelySabores.Models.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataCadastro { get; set; }

        public override string ToString()
        {
            return string.IsNullOrWhiteSpace(NomeCompleto) ? "(cliente sem nome)" : NomeCompleto;
        }
    }
}