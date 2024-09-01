 
   
using Microsoft.EntityFrameworkCore;  
using KTSF.Persistence;
using KTSF.Application.Service; 
using KTSF.Infrastructure; 
using KTSF.Application.Interfaces.Auth;  
using Microsoft.Extensions.DependencyInjection;
using KTSF.Application.Middleware;
using KTSF.Api.Extensions;

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

            string appConnectionString = builder.Configuration.GetConnectionString(nameof(ObjectDbContext)) ?? throw new ArgumentNullException("Connection string is null");

            ObjectDbContext.ConnectionString = appConnectionString;


            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            builder.Services.AddDbContext<AppDbContext>(options => options.UseMySQL(connectionString));
            builder.Services.AddDbContext<ObjectDbContext>(options => options.UseMySQL(appConnectionString));
             


            builder.Services.AddTransient<EmployeesService>();
            builder.Services.AddTransient<UsersService>();
            builder.Services.AddTransient<ProductsService>();
            builder.Services.AddTransient<AuthService>();
            builder.Services.AddTransient<AppointmentService>();
            builder.Services.AddTransient<EmployeeStatusService>();
            builder.Services.AddTransient<ASetOfRulesService>();
            builder.Services.AddTransient<CompanyService>();
            builder.Services.AddTransient<ObjectService>();
            builder.Services.AddSingleton<AuthSingletonService>();

            builder.Services.AddTransient<IPasswordHasher, PasswordHasher>();

            builder.Services.AddTransient<IJwtProvider, JwtProvider>(); 


            builder.Services.AddApiAuthentification();
 
            var app = builder.Build();
             

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // // Настройте конвейер HTTP-запросов.
            app.UseHttpsRedirection();         

            app.UseAuthorization();

            app.UseMiddleware<AccessMiddleware>();

            var webSocketOptions = new WebSocketOptions
            {
                KeepAliveInterval = TimeSpan.FromMinutes(2)
            };

            

            app.UseWebSockets(webSocketOptions);

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
