using System;
using System.Security.Cryptography;
using System.Text;

namespace CT_Negocio.Infraestrutura
{
    public static class CriptografiaSenha
    {
        public static string GerarSalt()
        {
            return Guid.NewGuid().ToString().ToLowerInvariant();
        }

        public static string CalcularHash(string salt, string senha)
        {
            if (salt == null)  throw new ArgumentNullException("salt");
            if (senha == null) throw new ArgumentNullException("senha");

            // SQL Server NVARCHAR = UTF-16 LE; deve coincidir com HASHBYTES do seed
            byte[] entrada = Encoding.Unicode.GetBytes(salt + senha);
            using (var sha = SHA256.Create())
            {
                byte[] hash = sha.ComputeHash(entrada);
                return BitConverter.ToString(hash).Replace("-", string.Empty).ToUpperInvariant();
            }
        }

        public static bool Verificar(string senhaPlana, string saltArmazenado, string hashArmazenado)
        {
            string calculado = CalcularHash(saltArmazenado, senhaPlana);
            return string.Equals(calculado, hashArmazenado, StringComparison.OrdinalIgnoreCase);
        }
    }
}
