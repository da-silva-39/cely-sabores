using System;
using System.Security.Cryptography;

namespace CelySabores.Business.Security
{
    public static class PasswordHasher
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 100000;

        public static string Hash(string senha)
        {
            var salt = new byte[SaltSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            byte[] hash;
            using (var pbkdf2 = new Rfc2898DeriveBytes(senha, salt, Iterations))
            {
                hash = pbkdf2.GetBytes(HashSize);
            }

            return Iterations + ":" + Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
        }

        public static bool Verify(string senha, string armazenado)
        {
            if (string.IsNullOrEmpty(senha) || string.IsNullOrEmpty(armazenado))
            {
                return false;
            }

            var partes = armazenado.Split(':');
            if (partes.Length != 3)
            {
                return false;
            }

            int iteracoes;
            byte[] salt;
            byte[] hashArmazenado;

            try
            {
                iteracoes = int.Parse(partes[0]);
                salt = Convert.FromBase64String(partes[1]);
                hashArmazenado = Convert.FromBase64String(partes[2]);
            }
            catch (FormatException)
            {
                return false;
            }
            catch (OverflowException)
            {
                return false;
            }

            byte[] hashCalculado;
            using (var pbkdf2 = new Rfc2898DeriveBytes(senha, salt, iteracoes))
            {
                hashCalculado = pbkdf2.GetBytes(hashArmazenado.Length);
            }

            return ComparacaoSegura(hashCalculado, hashArmazenado);
        }

        private static bool ComparacaoSegura(byte[] a, byte[] b)
        {
            if (a == null || b == null || a.Length != b.Length)
            {
                return false;
            }

            int diferenca = 0;
            for (int i = 0; i < a.Length; i++)
            {
                diferenca |= a[i] ^ b[i];
            }

            return diferenca == 0;
        }
    }
}