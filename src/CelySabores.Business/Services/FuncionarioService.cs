using System.Collections.Generic;
using CelySabores.Business.Exceptions;
using CelySabores.Business.Security;
using CelySabores.Business.Validators;
using CelySabores.Data.Repositories;
using CelySabores.Models.Entities;

namespace CelySabores.Business.Services
{
    public class FuncionarioService
    {
        private readonly FuncionarioRepository _funcionarioRepository;

        public FuncionarioService(FuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public IList<Funcionario> Listar(bool apenasAtivos)
        {
            return _funcionarioRepository.Listar(apenasAtivos);
        }

        public Funcionario ObterPorId(int id)
        {
            return _funcionarioRepository.ObterPorId(id);
        }

        public Funcionario Inserir(Funcionario funcionario)
        {
            ContextoPermissao.ExigirGerente();
            Validar(funcionario);

            funcionario.Id = _funcionarioRepository.Inserir(funcionario);
            return funcionario;
        }

        public void Atualizar(Funcionario funcionario)
        {
            ContextoPermissao.ExigirGerente();
            Validar(funcionario);

            _funcionarioRepository.Atualizar(funcionario);
        }

        public void AlterarAtivo(int id, bool ativo)
        {
            ContextoPermissao.ExigirGerente();

            var funcionario = _funcionarioRepository.ObterPorId(id);
            if (funcionario == null)
            {
                throw new RegraNegocioException("Funcionário não encontrado.");
            }

            if (ContextoPermissao.UsuarioAtual != null
                && ContextoPermissao.UsuarioAtual.IdFuncionario == id
                && !ativo)
            {
                throw new RegraNegocioException("Não pode desativar o próprio acesso.");
            }

            _funcionarioRepository.AlterarAtivo(id, ativo);
        }

        private static void Validar(Funcionario funcionario)
        {
            if (funcionario == null)
            {
                throw new RegraNegocioException("Funcionário não informado.");
            }

            funcionario.NomeCompleto = Validacoes.Obrigatorio(funcionario.NomeCompleto, "nome");
            funcionario.Cargo = Validacoes.Obrigatorio(funcionario.Cargo, "cargo");
            funcionario.Telefone = Validacoes.Opcional(funcionario.Telefone);
            funcionario.Email = Validacoes.Opcional(funcionario.Email);
            funcionario.Endereco = Validacoes.Opcional(funcionario.Endereco);
            funcionario.Observacoes = Validacoes.Opcional(funcionario.Observacoes);
        }
    }
}
