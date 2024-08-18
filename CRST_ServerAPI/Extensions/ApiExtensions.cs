namespace KTSF.Api.Extensions
{
    public static class ApiExtensions
    {
        /* public static void AddApiAuthentification(this IServiceCollection services, IConfiguration configuration)
         {
             // var jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();

             services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                 .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                 {
                     options.TokenValidationParameters = new()
                     {
                         ValidateIssuer = false,
                         ValidateAudience = false,
                         ValidateLifetime = false,
                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions!.SecretKey))
                     };
                 });
         }*/
    }
}
