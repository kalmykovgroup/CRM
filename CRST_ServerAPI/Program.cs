

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
using KTSF.Api.Extensions.Repositories;
using KTSF.Infrastructure;
using KTSF.Application.Interfaces.Auth;
using KTSF.Api.Controllers;

namespace CRST_ServerAPI;

public class Program {
    public static void Main (string[] args) {
        var builder = WebApplication.CreateBuilder (args);

        // Add services to the container.

        builder.Configuration.AddJsonFile ("appsettings.json", optional: true, reloadOnChange: true);


        builder.Services.AddControllers ()
        .ConfigureApiBehaviorOptions (options => {
            // options.SuppressMapClientErrors = true; //���������� ������ ProblemDetails
        });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer ();
        builder.Services.AddSwaggerGen ();


        // ���������� �������� ��������������
        /* builder.Services.AddAuthentication("Bearer")  // ����� �������������� - � ������� jwt-�������
             .AddJwtBearer();      // ����������� �������������� � ������� jwt-�������*/

        builder.Services.AddAuthentication (JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer (options => {
                   options.RequireHttpsMetadata = false;
                   options.TokenValidationParameters = new TokenValidationParameters {
                       // ��������, ����� �� �������������� �������� ��� ��������� ������
                       ValidateIssuer = true,
                       // ������, �������������� ��������
                       ValidIssuer = AuthOptions.ISSUER,

                       // ����� �� �������������� ����������� ������
                       ValidateAudience = true,
                       // ��������� ����������� ������
                       ValidAudience = AuthOptions.AUDIENCE,
                       // ����� �� �������������� ����� �������������
                       ValidateLifetime = true,

                       // ��������� ����� ������������
                       IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey (),
                       // ��������� ����� ������������
                       ValidateIssuerSigningKey = true,
                   };
               });

        /* builder.Services.AddAuthentication("BasicAuthentication")
     .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);*/

        //��������� ��������� �������� ����������� �������������
        /*  builder.Services.AddAuthorization(options =>
          {
              options.FallbackPolicy = new AuthorizationPolicyBuilder()
                  .RequireAuthenticatedUser()
                  .Build();
          });
*/

        string connectionString = builder.Configuration.GetConnectionString (nameof (AppDbContext)) ?? throw new ArgumentNullException ("Connection string is null");

        AppDbContext.ConnectionString = connectionString;
        builder.Services.AddDbContext<AppDbContext> (options => options.UseMySQL (connectionString));


        builder.Services.AddTransient<IPasswordHasher, PasswordHasher> ();

        builder.Services.AddTransient<EmployeesService> ();
        builder.Services.AddTransient<UsersService> ();
        builder.Services.AddTransient<ProductsService> ();
        builder.Services.AddTransient<AuthService> ();
        builder.Services.AddTransient<AppointmentService> ();
        builder.Services.AddTransient<EmployeeStatusService> ();
        builder.Services.AddTransient<ASetOfRulesService> ();


        var app = builder.Build ();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment ()) {
            app.UseSwagger ();
            app.UseSwaggerUI ();
        }


        // // ��������� �������� HTTP-��������.
        app.UseHttpsRedirection ();




        //app.UseAuthentication();   // ���������� middleware ��������������

        app.UseAuthorization ();


        // ������������� ������������� ��������� � �������������
        app.MapControllerRoute (
         name: "default",
         pattern: "{controller=Home}/{action=Index}/{id?}"

         );


        app.MapControllers ();


        app.Run ();

    }


}
