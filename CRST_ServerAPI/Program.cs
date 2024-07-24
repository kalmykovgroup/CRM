
using CRST_ServerAPI.Data;
using KTSFClassLibrary;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

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
            builder.Services.AddAuthentication("Bearer")  // схема аутентификации - с помощью jwt-токенов
                .AddJwtBearer();      // подключение аутентификации с помощью jwt-токенов

            //Требовать прошедших проверку подлинности пользователей
          /*  builder.Services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            });
*/

            string connectionString = builder.Configuration.GetConnectionString("MySql") ?? throw new ArgumentNullException("Connection string is null");

            AppDbContext.ConnectionString = connectionString;
            builder.Services.AddDbContext<AppDbContext>(options => options.UseMySQL(connectionString));
           
            var app = builder.Build();

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
