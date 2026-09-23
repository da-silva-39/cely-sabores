using CelySabores.Business.Exceptions;

namespace CelySabores.Business.Validators
{
    public static class Validacoes
    {
        public static string Obrigatorio(string valor, string campo)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                throw new RegraNegocioException("O campo '" + campo + "' é obrigatório.");
            }

            return valor.Trim();
        }

        public static string Opcional(string valor)
        {
            return string.IsNullOrWhiteSpace(valor) ? null : valor.Trim();
        }

        public static decimal Preco(decimal valor, string campo = "preço")
        {
            if (valor < 0)
            {
                throw new RegraNegocioException("O valor de '" + campo + "' não pode ser negativo.");
            }

            return valor;
        }

        public static int Positivo(int valor, string campo)
        {
            if (valor <= 0)
            {
                throw new RegraNegocioException("O campo '" + campo + "' deve ser maior que zero.");
            }

            return valor;
        }
    }
}