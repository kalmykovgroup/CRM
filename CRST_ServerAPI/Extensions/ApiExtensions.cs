using KTSF.Persistence.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CRST_ServerAPI.Extensions
{
    public static class ApiExtensions
    {
        // подключение аутентификации с помощью jwt-токенов*/
        public static void AddApiAuthentification(this IServiceCollection services)
        {

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                  .AddJwtBearer(options =>
                  {
                    //  options.RequireHttpsMetadata = false;
                      options.TokenValidationParameters = new TokenValidationParameters
                      {
                          // укзывает, будет ли валидироваться издатель при валидации токена
                          ValidateIssuer = false,
                          // строка, представляющая издателя
                          ValidIssuer = JwtOptions.ISSUER,

                          // будет ли валидироваться потребитель токена
                          ValidateAudience = false,
                          // установка потребителя токена
                          ValidAudience = JwtOptions.AUDIENCE,
                          // будет ли валидироваться время существования
                          ValidateLifetime = false,

                          // валидация ключа безопасности
                          ValidateIssuerSigningKey = true,

                          // установка ключа безопасности
                          IssuerSigningKey = JwtOptions.GetSymmetricSecurityKey(),


                      };
                  });

            services.AddAuthentication();

        }
    }
}
