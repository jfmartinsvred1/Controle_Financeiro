using Controle_Financeiro.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Controle_Financeiro.Services.TokenService
{
    public class TokenServices
    {
        public string GenerateToken(Usuario usuario)
        {
            Claim[] claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier,usuario.Id),
                new Claim("username",usuario.UserName),
                new Claim(ClaimTypes.DateOfBirth,usuario.DataNascimento.ToString())
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("32O4B23GO4BG234JBHHJBJ34"));

            var signingCredentials= new SigningCredentials(chave,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                expires:DateTime.Now.AddHours(1),
                claims:claims,
                signingCredentials:signingCredentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
