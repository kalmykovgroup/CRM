using Microsoft.IdentityModel.Tokens; 
using System.IdentityModel.Tokens.Jwt; 
using System.Security.Claims; 
using KTSF.Persistence.Configurations;
using KTSF.Core;
using KTSF.Application.Interfaces.Auth;

namespace KTSF.Infrastructure
{
    public class JwtProvider : IJwtProvider
    {  

        public string GenerateAccessToken(User user)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, $"{user.Id}"),
                new Claim(ClaimTypes.Name, user.Email ?? user.PhoneNumber)
            };

            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: JwtOptions.ISSUER,
                    audience: JwtOptions.AUDIENCE,
                    claims: claims, 
                    expires: DateTime.UtcNow.Add(JwtOptions.LIFETIME), //Срок жизни
                    signingCredentials: new SigningCredentials(JwtOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
 
    }
}
