using System;
using CelySabores.Models.Enums;

namespace CelySabores.Models.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public int FuncionarioId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public TipoUsuario Tipo { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? UltimoLogin { get; set; }
        public string NomeFuncionario { get; set; }
        public string Cargo { get; set; }
    }
}