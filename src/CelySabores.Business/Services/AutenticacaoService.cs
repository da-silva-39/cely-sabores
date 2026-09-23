using System;
using CelySabores.Business.Exceptions;
using CelySabores.Business.Security;
using CelySabores.Data.Repositories;
using CelySabores.Models.Dtos;

namespace CelySabores.Business.Services
{
    public class AutenticacaoService
    {
        private readonly UsuarioRepository _usuarioRepository;

        public AutenticacaoService(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public SessaoUsuario Autenticar(string username, string senha)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(senha))
            {
                throw new RegraNegocioException("Informe o usuário e a senha.");
            }

            username = username.Trim();

            var usuario = _usuarioRepository.ObterPorUsername(username);
            if (usuario == null || !PasswordHasher.Verify(senha, usuario.PasswordHash))
            {
                throw new RegraNegocioException("Usuário ou senha inválidos.");
            }

            if (!usuario.Ativo)
            {
                throw new RegraNegocioException("Conta desativada. Contacte o gerente.");
            }

            _usuarioRepository.AtualizarUltimoLogin(usuario.Id);

            var sessao = new SessaoUsuario
            {
                IdUsuario = usuario.Id,
                IdFuncionario = usuario.FuncionarioId,
                Username = usuario.Username,
                FuncionarioNome = usuario.NomeFuncionario,
                Cargo = usuario.Cargo,
                Tipo = usuario.Tipo,
                DataLogin = DateTime.Now
            };

            ContextoPermissao.Autenticar(sessao);
            return sessao;
        }

        public void EncerrarSessao()
        {
            ContextoPermissao.Encerrar();
        }
    }
}