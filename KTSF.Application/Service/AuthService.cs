using CSharpFunctionalExtensions;
using Google.Protobuf.Compiler;
using KTSF.Application.Interfaces.Auth;
using KTSF.Core;
using KTSF.Dto.Auth;
using KTSF.Persistence;
using KTSF.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Application.Service
{
    public class AuthService
    {
        private IPasswordHasher _passwordHasher { get; set; }
        private IJwtProvider _jwtProvider { get; set; }

        private AppDbContext _appDbContext;
         

        public AuthService(AppDbContext appDbContext, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
        {  
            _appDbContext = appDbContext;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
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
                return Result.Failure<User>("Email или PhoneNumber должно быть заполненно!");

            
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

                    user.AccessToken = _jwtProvider.GenerateAccessToken(user);

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


        public async Task<Result<User>> Login(string username, string password)
        { 
            User? user = null;

            if (User.IsValidEmail(username).IsSuccess)
            {
                user = await _appDbContext.Users.Where(user => user.Email == username).FirstOrDefaultAsync();
            }
            else if (User.IsValidPhone(username).IsSuccess)
            {
                user = await _appDbContext.Users.Where(user => user.PhoneNumber == username).FirstOrDefaultAsync();
            }

            if (user is null ||
                user.PasswordHash is null || //Что-бы не ругался
               !_passwordHasher.Verify(password, user.PasswordHash))
            {
                return Result.Failure<User>("Логин или пароль не верны!");
            }

                        
            user.AccessToken = _jwtProvider.GenerateAccessToken(user);

            try { 
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            { 
                Result.Failure(ex.Message);
            }
 
            return Result.Success(user);
        }


      
    }
}
