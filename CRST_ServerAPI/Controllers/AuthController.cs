 
 
using Microsoft.AspNetCore.Mvc;

using KTSF.Core;
using KTSF.Application.Service;
using KTSF.Dto.Auth;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Authorization;
namespace CRST_ServerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AuthController : ControllerBase
    {
         

        private readonly AuthService _authService; 

        public AuthController(AuthService authService )
        {
            _authService = authService; 
        }


        //Аутентификация с помощью логина и пароля
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest loginUserDto)
        {

        //public AuthController(IAuthRepository authRepository)
        //{
        //    _authRepo = authRepository;
        //}

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

            if (result.IsSuccess)
                return Ok(result.Value);
            else
                return BadRequest(result.Error);


        }
        
  

        //Аутентификация с помощью логина и пароля
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserRequest registerUserDto)
        {

            Result<User> result = _authService.Register(registerUserDto);

            if (result.IsSuccess)
                return Ok(result.Value);
            else
                return BadRequest(result.Error);


        }

    }
}
