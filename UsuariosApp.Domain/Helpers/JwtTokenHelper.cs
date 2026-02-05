using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UsuariosApp.Domain.Helpers
{
    public class JwtTokenHelper
    {
        // Chave secreta (ideal: vir de appsettings ou variável de ambiente)
        private static string SecretKey = "d3128426-6ec0-462e-bb9e-1a234bffa404";

        /// <summary>
        /// Método para geração dos TOKENS JWT
        /// </summary>
        public static string GenerateToken(string user, string role, DateTime expiration)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(SecretKey)
            );

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: "UsuariosApp",
                audience: "UsuariosApp",
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}