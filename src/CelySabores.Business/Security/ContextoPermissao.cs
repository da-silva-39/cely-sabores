using CelySabores.Business.Exceptions;
using CelySabores.Models.Dtos;
using CelySabores.Models.Enums;

namespace CelySabores.Business.Security
{
    public static class ContextoPermissao
    {
        public static SessaoUsuario UsuarioAtual { get; private set; }

        public static void Autenticar(SessaoUsuario sessao)
        {
            UsuarioAtual = sessao;
        }

        public static void Encerrar()
        {
            UsuarioAtual = null;
        }

        public static void Exigir(TipoUsuario tipo)
        {
            if (UsuarioAtual == null)
            {
                throw new RegraNegocioException("A sessão expirou. Efetue o login novamente.");
            }

            if (UsuarioAtual.Tipo != tipo)
            {
                throw new RegraNegocioException("Acesso negado. Permissão insuficiente.");
            }
        }

        public static void ExigirGerente()
        {
            Exigir(TipoUsuario.Gerente);
        }

        public static bool Pode(TipoUsuario tipo)
        {
            return UsuarioAtual != null && UsuarioAtual.Tipo == tipo;
        }

        public static bool EhGerente()
        {
            return Pode(TipoUsuario.Gerente);
        }
    }
}