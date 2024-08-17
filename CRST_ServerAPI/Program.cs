 
  
using Microsoft.AspNetCore.Authentication.JwtBearer; 
using Microsoft.EntityFrameworkCore;  
using KTSF.Persistence;
using KTSF.Application.Service; 
using KTSF.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using KTSF.Application.Interfaces.Auth;
using KTSF.Persistence.Configurations;
using Microsoft.AspNetCore.Authentication; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using KTSF.Application.Extensions;
using CRST_ServerAPI.Extensions;

namespace CRST_ServerAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
 

            builder.Services.AddControllers()
            .ConfigureApiBehaviorOptions(options =>
            {
               // options.SuppressMapClientErrors = true; //Отключение ответа ProblemDetails
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

         

         /*   builder.Services.AddAuthentication("BasicAuthentication")
         .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null); */
 
         /*   //Требовать прошедших проверку подлинности пользователей
              builder.Services.AddAuthorization(options =>
              {
                  options.FallbackPolicy = new AuthorizationPolicyBuilder()
                      .RequireAuthenticatedUser()
                      .Build();
              });*/
          
 
            string connectionString = builder.Configuration.GetConnectionString(nameof(AppDbContext)) ?? throw new ArgumentNullException("Connection string is null");

            AppDbContext.ConnectionString = connectionString;

            builder.Services.AddDbContext<AppDbContext>(options => options.UseMySQL(connectionString));

            builder.Services.AddTransient<EmployeesService>();
            builder.Services.AddTransient<UsersService>();
            builder.Services.AddTransient<ProductsService>();
            builder.Services.AddTransient<AuthService>();

            builder.Services.AddTransient<IPasswordHasher, PasswordHasher>();

            builder.Services.AddTransient<IJwtProvider, JwtProvider>();


            builder.Services.AddApiAuthentification();
 
            var app = builder.Build();

            app.UseMiddleware<AuthMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            // // Настройте конвейер HTTP-запросов.
            app.UseHttpsRedirection();




            app.UseAuthentication();   // добавление middleware аутентификации

            app.UseAuthorization(); 
            

            // устанавливаем сопоставление маршрутов с контроллерами
            app.MapControllerRoute(
             name: "default",
             pattern: "{controller=Home}/{action=Index}/{id?}"
             
             );


            app.MapControllers();
             

            app.Run();


           
        }
         

    }
}
