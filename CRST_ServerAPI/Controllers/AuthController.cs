 
 
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

            Result<User> result = await _authService.Login(loginUserDto.Username, loginUserDto.Password);

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
