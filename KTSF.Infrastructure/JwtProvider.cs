using Microsoft.IdentityModel.Tokens; 
using System.IdentityModel.Tokens.Jwt; 
using System.Security.Claims; 
using KTSF.Persistence.Configurations;
 
using KTSF.Application.Interfaces.Auth; 
using KTSF.Core.App; 
using Object = KTSF.Core.App.Object;
using KTSF.Core.Object;
using Microsoft.AspNetCore.Http;
using System;

namespace KTSF.Infrastructure
{ 
    public class JwtProvider : IJwtProvider
    {
         
        public string GenerateUserJwtToken(User user)
        {

            var claims = new List<Claim> {
                new Claim(ClaimsExtensions.userId, $"{user.Id}"),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, Role.User)
            }; 

           // создаем JWT-токен
           var jwt = new JwtSecurityToken(
                    issuer: JwtOptions.ISSUER,
                    audience: JwtOptions.AUDIENCE,
                    claims: claims, 
                    expires: DateTime.UtcNow.Add(JwtOptions.USER_LIFETIME), //Срок жизни
                    signingCredentials: new SigningCredentials(JwtOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
         
        

        public string GenerateJwtTokenSelectedObject(User user, Company company, Object @object)
        {

            var claims = new List<Claim> {
                new Claim(ClaimsExtensions.userId, $"{user.Id}"),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, Role.Anonym),
                new Claim(ClaimsExtensions.companyId,  $"{company.Id}"),
                new Claim(ClaimsExtensions.objectId, $"{@object.Id}")
            };
             

           // создаем JWT-токен
           var jwt = new JwtSecurityToken(
                    issuer: JwtOptions.ISSUER,
                    audience: JwtOptions.AUDIENCE,
                    claims: claims, 
                    expires: DateTime.UtcNow.Add(JwtOptions.ANONYM_LIFETIME), //Срок жизни
                    signingCredentials: new SigningCredentials(JwtOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public string GenerateEmployeeJwtToken(User user, Employee employee, Company company, Object @object)
        {
            var claims = new List<Claim> {
                new Claim(ClaimsExtensions.employeeId, $"{employee.Id}"),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, Role.Employee),
                new Claim(ClaimsExtensions.userId, $"{user.Id}"),
                new Claim(ClaimsExtensions.companyId, $"{company.Id}"),
                new Claim(ClaimsExtensions.objectId, $"{@object.Id}")
            };

            var jwt = new JwtSecurityToken(
                    issuer: JwtOptions.ISSUER,
                    audience: JwtOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(JwtOptions.EMPLOYEE_LIFETIME), //Срок жизни
                    signingCredentials: new SigningCredentials(JwtOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

      
      


    }
     
}
