 
 
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.IdentityModel.Tokens;
using KTSF.Api.Model;
using Microsoft.AspNetCore.Authentication;
using KTSF.Persistence;
using KTSF.Application.Service; 
using KTSF.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using KTSF.Application.Interfaces.Auth;
using KTSF.Api.Controllers;

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

            
            // добавление сервисов аутентификации
           /* builder.Services.AddAuthentication("Bearer")  // схема аутентификации - с помощью jwt-токенов
                .AddJwtBearer();      // подключение аутентификации с помощью jwt-токенов*/

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       options.RequireHttpsMetadata = false;
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           // укзывает, будет ли валидироваться издатель при валидации токена
                           ValidateIssuer = true,
                           // строка, представляющая издателя
                           ValidIssuer = AuthOptions.ISSUER,

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
            builder.Services.AddTransient<AppointmentService>();
            builder.Services.AddTransient<EmployeeStatusService>();
            builder.Services.AddTransient<ASetOfRulesService>();

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




            //app.UseAuthentication();   // добавление middleware аутентификации

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
