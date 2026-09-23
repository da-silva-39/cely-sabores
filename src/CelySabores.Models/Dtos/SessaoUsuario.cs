using System;
using CelySabores.Models.Enums;

namespace CelySabores.Models.Dtos
{
    public class SessaoUsuario
    {
        public int IdUsuario { get; set; }
        public int IdFuncionario { get; set; }
        public string Username { get; set; }
        public string FuncionarioNome { get; set; }
        public string Cargo { get; set; }
        public TipoUsuario Tipo { get; set; }
        public DateTime DataLogin { get; set; }
        public bool EhGerente
        {
            get { return Tipo == TipoUsuario.Gerente; }
        }
    }
}