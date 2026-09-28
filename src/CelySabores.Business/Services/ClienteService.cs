using System;
using System.Collections.Generic;
using CelySabores.Business.Exceptions;
using CelySabores.Business.Security;
using CelySabores.Business.Validators;
using CelySabores.Data.Repositories;
using CelySabores.Models.Entities;

namespace CelySabores.Business.Services
{
    public class ClienteService
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteService(ClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IList<Cliente> Listar(string pesquisa)
        {
            return _clienteRepository.Listar(pesquisa);
        }

        public Cliente ObterPorId(int id)
        {
            return _clienteRepository.ObterPorId(id);
        }

        public Cliente Inserir(Cliente cliente)
        {
            Validar(cliente);

            cliente.Id = _clienteRepository.Inserir(cliente);
            return cliente;
        }

        public void Atualizar(Cliente cliente)
        {
            if (cliente == null || cliente.Id <= 0)
            {
                throw new RegraNegocioException("Cliente não encontrado.");
            }

            Validar(cliente);
            _clienteRepository.Atualizar(cliente);
        }

        private static void Validar(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new RegraNegocioException("Cliente não informado.");
            }

            cliente.NomeCompleto = Validacoes.Obrigatorio(cliente.NomeCompleto, "nome do cliente");
            cliente.Telefone = Validacoes.Opcional(cliente.Telefone);
            cliente.Email = Validacoes.Opcional(cliente.Email);
            cliente.Endereco = Validacoes.Opcional(cliente.Endereco);
            cliente.Observacoes = Validacoes.Opcional(cliente.Observacoes);

            if (cliente.Email != null && !cliente.Email.Contains("@"))
            {
                throw new RegraNegocioException("O e-mail informado não é válido.");
            }
        }
    }
}
