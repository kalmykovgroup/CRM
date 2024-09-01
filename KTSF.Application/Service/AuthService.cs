using CSharpFunctionalExtensions;
using KTSF.Application.Extensions;
using KTSF.Application.Interfaces.Auth;
using KTSF.Core.App;
using KTSF.Core.Object;
using KTSF.Dto.Auth; 
using KTSF.Dto.Object_;
using KTSF.Infrastructure;
using KTSF.Persistence;
using KTSF.Persistence.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using System;
using System.Net.WebSockets; 
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json; 
using Result = CSharpFunctionalExtensions.Result;

namespace KTSF.Application.Service
{
    public class AuthService
    {

        public static JsonSerializerOptions options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            //Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic ),
            WriteIndented = true
        };

        private IPasswordHasher _passwordHasher { get; set; }
        private IJwtProvider _jwtProvider { get; set; }

        private readonly AuthSingletonService _authSingletonService;

        private AppDbContext _appDbContext; 

        private readonly HttpContext? _httpContext;


#if DEBUG


        [Route("/debug-get-employee")]
        public async Task<Result<Employee>> GetDebugEmployee(ObjectDbContext objectDbContext)
        {
            User? user = _appDbContext.Users.Where(u => u.Id == 1).FirstOrDefault();

            Company? company = _appDbContext.Companies.Where(u => u.Id == 1).Include(c => c.Objects.Where(obj => obj.Id == 1)).FirstOrDefault();

            Employee? employee = await objectDbContext.Employees.Where(em => em.Id == 1).FirstOrDefaultAsync();

            if (user is null || company is null || employee is null) return Result.Failure<Employee>("Not found");


            employee.JwtToken = _jwtProvider.GenerateEmployeeJwtToken(user, employee, company, company.Objects[0]);

            return Result.Success<Employee>(employee);

        }

#endif

        public AuthService(AppDbContext appDbContext, AuthSingletonService authSingletonService, IPasswordHasher passwordHasher, IJwtProvider jwtProvider, IHttpContextAccessor IHttpContextAccessor)
        {
            _httpContext = IHttpContextAccessor.HttpContext;
            _appDbContext = appDbContext;
            _authSingletonService = authSingletonService;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider; 
        }

        public Result<string> GenerateLoginQRCode(WebSocket webSocket)
        {
 
            int? userId = _httpContext?.User?.Claims.GetUserId();
            int? companyId = _httpContext?.User?.Claims.GetUserId();
            int? objectId = _httpContext?.User?.Claims.GetObjectId();

            if (userId == null || companyId == null || objectId == null)
            {
                return Result.Failure<string>("data is null");
            }


            User? user = _appDbContext.Users.Where(u => u.Id == userId).FirstOrDefault();
            Company? company = _appDbContext.Companies.Where(c => c.Id == companyId).Include(c => c.Objects.Where(obj => obj.Id == objectId)).FirstOrDefault(); 

            if(user == null || company == null || company.Objects.Count == 0)
            {
                return Result.Failure<string>("There is not enough data");
            }

            AuthSocketData authSocketData = new AuthSocketData((int)userId, (int)companyId, (int)objectId, webSocket);

            _authSingletonService.OpensWebSockets.Add(authSocketData.IdentityString, authSocketData);


            return Result.Success(authSocketData.IdentityString);
        }

        public async Task<Result> AuthEmployee(string identitySocket, ObjectDbContext objectDbContext)
        {
            AuthSocketData? authSocketData = _authSingletonService.OpensWebSockets[identitySocket];

            if (authSocketData.WebSocket.CloseStatus.HasValue) return Result.Failure("Соединение закрыто");

            int? employeeId = _httpContext?.User?.Claims.GetCompanyId();             
            int? userId = _httpContext?.User?.Claims.GetUserId(); 
            int? companyId = _httpContext?.User?.Claims.GetUserId();
            int? objectId = _httpContext?.User?.Claims.GetObjectId();

            Company? company = _appDbContext.Companies
                .Where(c => c.CompanyStatus == CompanyStatus.Active && c.Id == companyId)
                .Include(c => c.Objects.Where(obj => obj.Id == objectId)).FirstOrDefault();

            if (company == null) return Result.Failure("Company not found");
            if (company.Objects.Count == 0) return Result.Failure("Object not found");

            User? user = _appDbContext.Users.Where(u => u.Id == userId).FirstOrDefault();

            if (user == null) return Result.Failure("User not found");

            Employee? employee = objectDbContext.Employees.Where(emp => emp.Id == employeeId).FirstOrDefault();

            if (employee == null) return Result.Failure("Company is null");

           
            if(company == null) return Result.Failure("Company is null");

            if (userId != authSocketData.UserId 
                || company.Id != authSocketData.CompanyId
                || company.Objects[0].Id != authSocketData.ObjectId)
            {
                return Result.Failure("Данные сокета не совпадают");
            }
             

            employee.JwtToken = _jwtProvider.GenerateEmployeeJwtToken(user, employee, company, company.Objects[0]);


            string json = JsonSerializer.Serialize(employee, options);
            var buffer = new byte[1024 * 4];

            buffer = Encoding.UTF8.GetBytes(json);

            //Отправили employee
            await authSocketData.WebSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
               
            return Result.Success();
           
        }

        public Result<User> Register(RegisterUserRequest registerUserDto)
        {
            
            if (!String.IsNullOrEmpty(registerUserDto.Email) && User.IsValidEmail(registerUserDto.Email).IsFailure)
            {
                return Result.Failure<User>("поле Email не являеться правильным email адресом");
            }
            if (!String.IsNullOrEmpty(registerUserDto.Phone) && User.IsValidPhone(registerUserDto.Phone).IsFailure)
            {
                return Result.Failure<User>("поле PhoneNumber не являеться правильным номером телефона");
            }

            if (String.IsNullOrEmpty(registerUserDto.Email) && String.IsNullOrEmpty(registerUserDto.Phone))
            {
                return Result.Failure<User>("Email или PhoneNumber должно быть заполненно!");
            }
                
 
            if (!String.IsNullOrEmpty(registerUserDto.Email) && _appDbContext.Users.Any(u => u.Email == registerUserDto.Email)) 
                return Result.Failure<User>("Email занят!");

            if (!String.IsNullOrEmpty(registerUserDto.Phone) && _appDbContext.Users.Any(u => u.PhoneNumber == registerUserDto.Phone)) 
                return Result.Failure<User>("PhoneNumber занят!");
          


            User user = new User()
            { 
                Name = registerUserDto.Name,
                Surname = registerUserDto.Surname,
                Patronymic = registerUserDto.Patronymic,
                Email = registerUserDto.Email,
                PhoneNumber = registerUserDto.Phone
            };


            user.PasswordHash = _passwordHasher.Generate(registerUserDto.Password);

         
            using (var transaction = _appDbContext.Database.BeginTransaction())
            {
                try
                {
                    _appDbContext.Users.Add(user);

                    _appDbContext.SaveChanges();

                    user.JwtToken = _jwtProvider.GenerateUserJwtToken(user);

                    _appDbContext.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    Result.Failure(ex.Message);
                }
            } 
  
          return Result.Success(user);
        }




        public async Task<Result<ObjectSelectResponse>> GenerateTokenSelectObject(ObjectSelectRequest companyObjectRequest)
        {
           
             
            int? userId = _httpContext?.User?.Claims.GetUserId(); 


            if (userId != null)
            {
                User? user = _appDbContext.Users.Where(u => u.Id == userId).FirstOrDefault();

                if(user != null)
                {
                    Company? company = await _appDbContext.Companies.Where(u => u.Id == companyObjectRequest.CompanyId)
                        .Include(c => c.Objects.Where(obj => obj.Id == companyObjectRequest.ObjectId))
                        .FirstOrDefaultAsync(); 

                    if(company != null && company.Objects.Count == 1)
                    {
                        string token = _jwtProvider.GenerateJwtTokenSelectedObject(user, company, company.Objects[0]);
                       
                        return Result.Success(new ObjectSelectResponse(token));
                        
                    } 
                  
                }
            }

            return Result.Failure<ObjectSelectResponse>("Request error! IdentityId is null");

        }

        public async Task<Result<User>> Login(LoginUserRequest loginUserRequest)
        { 
            User? user = null;

            if (User.IsValidEmail(loginUserRequest.Username).IsSuccess)
            {
                user = await _appDbContext.Users.Where(user => user.Email == loginUserRequest.Username).FirstOrDefaultAsync();
            }
            else if (User.IsValidPhone(loginUserRequest.Username).IsSuccess)
            {
                user = await _appDbContext.Users.Where(user => user.PhoneNumber == loginUserRequest.Username).FirstOrDefaultAsync();
            }

            if (user is null ||
                user.PasswordHash is null || //Что-бы не ругался
               !_passwordHasher.Verify(loginUserRequest.Password, user.PasswordHash))
            {
                return Result.Failure<User>("Логин или пароль не верны!");
            } 

            try {
                user.JwtToken = _jwtProvider.GenerateUserJwtToken(user);

                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            { 
                Result.Failure(ex.Message);
            }
 
            return Result.Success(user);
        }

        public async Task<Result<User>> Login(string token)
        {
            throw new NotImplementedException();
        }




    }
}
