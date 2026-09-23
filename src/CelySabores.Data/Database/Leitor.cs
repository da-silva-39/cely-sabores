using System;
using System.Data;

namespace CelySabores.Data.Database
{
    internal static class Leitor
    {
        private static bool Existe(DataRow linha, string campo)
        {
            return linha.Table != null && linha.Table.Columns.Contains(campo);
        }

        public static string String(DataRow linha, string campo)
        {
            if (!Existe(linha, campo))
            {
                return null;
            }

            return linha.IsNull(campo) ? null : Convert.ToString(linha[campo]);
        }

        public static int Int(DataRow linha, string campo)
        {
            return Convert.ToInt32(linha[campo]);
        }

        public static int? IntNulo(DataRow linha, string campo)
        {
            if (!Existe(linha, campo))
            {
                return null;
            }

            return linha.IsNull(campo) ? (int?)null : Convert.ToInt32(linha[campo]);
        }

        public static bool Bool(DataRow linha, string campo)
        {
            return Convert.ToBoolean(linha[campo]);
        }

        public static decimal Decimal(DataRow linha, string campo)
        {
            return Convert.ToDecimal(linha[campo]);
        }

        public static decimal? DecimalNulo(DataRow linha, string campo)
        {
            if (!Existe(linha, campo))
            {
                return null;
            }

            return linha.IsNull(campo) ? (decimal?)null : Convert.ToDecimal(linha[campo]);
        }

        public static DateTime DateTime(DataRow linha, string campo)
        {
            return Convert.ToDateTime(linha[campo]);
        }

        public static DateTime? DateTimeNulo(DataRow linha, string campo)
        {
            if (!Existe(linha, campo))
            {
                return null;
            }

            return linha.IsNull(campo) ? (DateTime?)null : Convert.ToDateTime(linha[campo]);
        }
    }
}
