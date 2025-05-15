using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SenaiNotesAlffas.Services
{
    public class TokenService
    {
        public string GenerateToken(string email)
        {
            // Criar as Claims - Informações do usuário que quero guardar no Token
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email)
            };

            //Criar uma chave de segurança e criptografar ela
            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("minha-chave-ultra-mega-secreta-senai"));

            //criptografando a chave de segurança
            var creds = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            //montar um token
            var token = new JwtSecurityToken(

                issuer: "senaiNotes",
                audience: "senaiNotes",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
