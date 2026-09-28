using System.Collections.Generic;
using CelySabores.Business.Exceptions;
using CelySabores.Business.Security;
using CelySabores.Business.Validators;
using CelySabores.Data.Repositories;
using CelySabores.Models.Entities;

namespace CelySabores.Business.Services
{
    public class CardapioService
    {
        private readonly CardapioRepository _cardapioRepository;

        public CardapioService(CardapioRepository cardapioRepository)
        {
            _cardapioRepository = cardapioRepository;
        }

        public IList<Categoria> ListarCategorias(bool apenasAtivas)
        {
            return _cardapioRepository.ListarCategorias(apenasAtivas);
        }

        public IList<Prato> ListarPratos(int? categoriaId, bool apenasDisponiveis, bool apenasAtivos)
        {
            return _cardapioRepository.ListarPratos(categoriaId, apenasDisponiveis, apenasAtivos);
        }

        public Prato ObterPrato(int id)
        {
            return _cardapioRepository.ObterPrato(id);
        }

        public Prato InserirPrato(Prato prato)
        {
            ContextoPermissao.ExigirGerente();
            ValidarPrato(prato);

            prato.Ativo = true;
            prato.Id = _cardapioRepository.InserirPrato(prato);
            return prato;
        }

        public void AtualizarPrato(Prato prato)
        {
            ContextoPermissao.ExigirGerente();
            ValidarPrato(prato);

            _cardapioRepository.AtualizarPrato(prato);
        }

        public void AlterarDisponibilidade(int id, bool disponivel)
        {
            var prato = _cardapioRepository.ObterPrato(id);
            if (prato == null)
            {
                throw new RegraNegocioException("Prato não encontrado.");
            }

            if (!prato.Ativo)
            {
                throw new RegraNegocioException("O prato '" + prato.Nome + "' está inactivo.");
            }

            _cardapioRepository.AlterarDisponibilidade(id, disponivel);
        }

        public void AlterarAtivoPrato(int id, bool ativo)
        {
            ContextoPermissao.ExigirGerente();

            if (_cardapioRepository.ObterPrato(id) == null)
            {
                throw new RegraNegocioException("Prato não encontrado.");
            }

            _cardapioRepository.AlterarAtivoPrato(id, ativo);
        }

        public Categoria InserirCategoria(Categoria categoria)
        {
            ContextoPermissao.ExigirGerente();

            categoria.Nome = Validacoes.Obrigatorio(categoria.Nome, "nome da categoria");
            if (_cardapioRepository.NomeCategoriaEmUso(categoria.Nome, categoria.Id) != null)
            {
                throw new RegraNegocioException("Já existe uma categoria com o nome '" + categoria.Nome + "'.");
            }

            categoria.Ativo = true;
            categoria.Id = _cardapioRepository.InserirCategoria(categoria);
            return categoria;
        }

        public void AtualizarCategoria(Categoria categoria)
        {
            ContextoPermissao.ExigirGerente();

            categoria.Nome = Validacoes.Obrigatorio(categoria.Nome, "nome da categoria");
            if (_cardapioRepository.NomeCategoriaEmUso(categoria.Nome, categoria.Id) != null)
            {
                throw new RegraNegocioException("Já existe uma categoria com o nome '" + categoria.Nome + "'.");
            }

            _cardapioRepository.AtualizarCategoria(categoria);
        }

        private void ValidarPrato(Prato prato)
        {
            if (prato == null)
            {
                throw new RegraNegocioException("Prato não informado.");
            }

            prato.Nome = Validacoes.Obrigatorio(prato.Nome, "nome do prato");
            prato.Preco = Validacoes.Preco(prato.Preco, "preço do prato");
            prato.Descricao = Validacoes.Opcional(prato.Descricao);

            if (prato.CategoriaId <= 0)
            {
                throw new RegraNegocioException("Escolha a categoria do prato.");
            }

            if (_cardapioRepository.NomePratoJaExiste(prato.Nome, prato.Id))
            {
                throw new RegraNegocioException("Já existe um prato com o nome '" + prato.Nome + "'.");
            }
        }
    }
}
