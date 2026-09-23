using System;
using CelySabores.Models.Enums;

namespace CelySabores.Models.Entities
{
    public class Reserva
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int? MesaId { get; set; }
        public DateTime DataHora { get; set; }
        public int NumeroPessoas { get; set; }
        public EstadoReserva Estado { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataCriacao { get; set; }
        public string ClienteNome { get; set; }
        public string ClienteTelefone { get; set; }
        public int? MesaNumero { get; set; }
    }
}