using System;
using System.Security.Cryptography;
using System.Text;

namespace UsuariosApp.Domain.Helpers
{
    public class CryptoHelper
    {
        public static string GetSHA256(string value)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(value);
                var hashBytes = sha256.ComputeHash(bytes);

                var builder = new StringBuilder();
                foreach (var b in hashBytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}