using System;
using System.Collections.Generic;
using CelySabores.Business.Exceptions;
using CelySabores.Business.Security;
using CelySabores.Business.Validators;
using CelySabores.Data.Repositories;
using CelySabores.Models.Entities;
using CelySabores.Models.Enums;

namespace CelySabores.Business.Services
{
    /// <summary>
    /// Regras do estoque. O modulo e do gerente: tanto a consulta como a
    /// alteracao sao bloqueadas ao funcionario, para o inventario e o custo dos
    /// ingredientes nao fiquem acessiveis a quem so atende mesas.
    /// </summary>
    public class EstoqueService
    {
        private readonly EstoqueRepository _estoqueRepository;
        private readonly CardapioRepository _cardapioRepository;

        public EstoqueService(EstoqueRepository estoqueRepository, CardapioRepository cardapioRepository)
        {
            _estoqueRepository = estoqueRepository;
            _cardapioRepository = cardapioRepository;
        }

        public IList<Ingrediente> ListarIngredientes(bool incluirInativos)
        {
            ContextoPermissao.ExigirGerente();
            return _estoqueRepository.ListarIngredientes(incluirInativos);
        }

        public IList<Ingrediente> ListarEstoqueBaixo()
        {
            ContextoPermissao.ExigirGerente();
            return _estoqueRepository.ListarEstoqueBaixo();
        }

        public Ingrediente ObterIngrediente(int id)
        {
            ContextoPermissao.ExigirGerente();
            return _estoqueRepository.ObterIngrediente(id);
        }

        public IList<Prato> ListarPratos()
        {
            ContextoPermissao.ExigirGerente();
            return _cardapioRepository.ListarPratos(null, false, true);
        }

        public IList<string> ListarPratosSemReceita()
        {
            ContextoPermissao.ExigirGerente();
            return _estoqueRepository.ListarPratosSemReceita();
        }

        public Ingrediente InserirIngrediente(Ingrediente ingrediente)
        {
            ContextoPermissao.ExigirGerente();
            Validar(ingrediente);

            // um ingrediente novo entra activo: sem isto, um ingrediente criado
            // sem definir a flag ficaria invisivel na listagem
            ingrediente.Ativo = true;

            ingrediente.Id = _estoqueRepository.InserirIngrediente(ingrediente);
            return ingrediente;
        }

        public void AtualizarIngrediente(Ingrediente ingrediente)
        {
            ContextoPermissao.ExigirGerente();

            if (ingrediente == null || ingrediente.Id <= 0)
            {
                throw new RegraNegocioException("Ingrediente não encontrado.");
            }

            Validar(ingrediente);
            _estoqueRepository.AtualizarIngrediente(ingrediente);
        }

        /// <summary>
        /// Regista uma entrada, saida ou ajuste. A quantidade so muda por aqui,
        /// e o movimento fica guardado com o funcionario responsavel.
        /// </summary>
        public MovimentoEstoque RegistrarMovimento(Ingrediente ingrediente, TipoMovimentoEstoque tipo,
            decimal quantidade, string observacao)
        {
            ContextoPermissao.ExigirGerente();

            if (ingrediente == null || ingrediente.Id <= 0)
            {
                throw new RegraNegocioException("Ingrediente não encontrado.");
            }

            if (quantidade < 0)
            {
                throw new RegraNegocioException("A quantidade não pode ser negativa.");
            }

            if (tipo == TipoMovimentoEstoque.Entrada || tipo == TipoMovimentoEstoque.Saida)
            {
                if (quantidade <= 0)
                {
                    throw new RegraNegocioException("Informe uma quantidade maior que zero.");
                }
            }

            int? funcionarioId = null;
            if (ContextoPermissao.UsuarioAtual != null)
            {
                funcionarioId = ContextoPermissao.UsuarioAtual.IdFuncionario;
            }

            try
            {
                return _estoqueRepository.RegistrarMovimento(ingrediente.Id, tipo, quantidade,
                    Validacoes.Opcional(observacao), null, funcionarioId);
            }
            catch (InvalidOperationException ex)
            {
                throw new RegraNegocioException(ex.Message);
            }
        }

        public IList<MovimentoEstoque> ListarMovimentos(int? ingredienteId, DateTime? de, DateTime? ate)
        {
            ContextoPermissao.ExigirGerente();

            if (de.HasValue && ate.HasValue && de.Value.Date > ate.Value.Date)
            {
                throw new RegraNegocioException("A data inicial não pode ser depois da data final.");
            }

            return _estoqueRepository.ListarMovimentos(ingredienteId, de, ate);
        }

        public IList<ReceitaPrato> ListarReceita(int pratoId)
        {
            ContextoPermissao.ExigirGerente();
            return _estoqueRepository.ListarReceita(pratoId);
        }

        /// <summary>
        /// Guarda a receita de um prato. As quantidades sao as que um prato
        /// consome; a baixa automatica no stock quando o prato e vendido fica
        /// para uma fase seguinte, para ja nao inventar nada aqui.
        /// </summary>
        public void GuardarReceita(int pratoId, IList<ReceitaPrato> receita)
        {
            ContextoPermissao.ExigirGerente();

            if (pratoId <= 0)
            {
                throw new RegraNegocioException("Prato não encontrado.");
            }

            if (receita == null || receita.Count == 0)
            {
                throw new RegraNegocioException("A receita precisa de pelo menos um ingrediente.");
            }

            var repetidos = new HashSet<int>();
            foreach (var linha in receita)
            {
                if (linha == null || linha.IngredienteId <= 0)
                {
                    throw new RegraNegocioException("Escolha um ingrediente para cada linha da receita.");
                }

                if (linha.Quantidade <= 0)
                {
                    throw new RegraNegocioException(
                        "A quantidade do ingrediente '" + linha.IngredienteNome + "' deve ser maior que zero.");
                }

                if (!repetidos.Add(linha.IngredienteId))
                {
                    throw new RegraNegocioException(
                        "O ingrediente '" + linha.IngredienteNome + "' está repetido na receita.");
                }
            }

            _estoqueRepository.SubstituirReceita(pratoId, receita);
        }

        private static void Validar(Ingrediente ingrediente)
        {
            if (ingrediente == null)
            {
                throw new RegraNegocioException("Ingrediente não informado.");
            }

            ingrediente.Nome = Validacoes.Obrigatorio(ingrediente.Nome, "nome do ingrediente");
            ingrediente.Unidade = Validacoes.Obrigatorio(ingrediente.Unidade, "unidade (kg, g, L, un)");

            if (ingrediente.QuantidadeMinima < 0)
            {
                throw new RegraNegocioException("A quantidade mínima não pode ser negativa.");
            }

            ingrediente.PrecoCusto = Validacoes.Preco(ingrediente.PrecoCusto, "preço de custo");
        }
    }
}
