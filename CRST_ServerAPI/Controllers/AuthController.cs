

using Microsoft.AspNetCore.Mvc;

using KTSF.Application.Service;
using KTSF.Dto.Auth;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Authorization;
using KTSF.Core.App;
using KTSF.Dto.Object_;
using System.Net.WebSockets;
using System.Text;
using MySqlX.XDevAPI.Common;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Net.Http;
using KTSF.Application.Interfaces.Auth;
using KTSF.Core.Object;
using KTSF.Persistence;
using System.Net.Sockets;
using System.Diagnostics;
namespace KTSF.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class AuthController : ControllerBase
    {
         

        private readonly AuthService _authService; 
       

        private readonly HttpContext? _httpContext;

        public AuthController(AuthService authService, IHttpContextAccessor IHttpContextAccessor)
        {
            _authService = authService; 
            _httpContext = IHttpContextAccessor.HttpContext;
        }
     

        //Аутентификация с помощью логина и пароля 
        [HttpPost("login")] 
        public async Task<IActionResult> Login([FromBody] LoginUserRequest loginUserRequest)
        {
            Result<User> result = await _authService.Login(loginUserRequest);

            if (result.IsSuccess)
            {
                return Ok(new LoginUserResponse(result.Value));
            }
            else
            {
                return Ok(new LoginUserResponse(result.Error));
            }
               
        }

      

        [HttpGet("employee-data")]
        [Authorize(Roles = $"{Role.Employee}")]
        public async Task<IActionResult> EmployeeData(string identitySocket, ObjectDbContext appDbContext)
        {
            if(_httpContext is null) return BadRequest();                       

            CSharpFunctionalExtensions.Result result = await _authService.AuthEmployee(identitySocket, appDbContext);

            if (result.IsSuccess) {
                return Ok();
            }

            return BadRequest();
        }

 

        

#if DEBUG


    [Route("debug-get-employee")]
    public async Task<IActionResult> GetDebugEmployee(ObjectDbContext objectDbContext)
    {
            Result<Employee> result = await _authService.GetDebugEmployee(objectDbContext);

            if(result.IsSuccess)
                 return Ok(result.Value);
            else
            {
                return BadRequest();
            }
           
    }
 
#endif




        [Route("/Employee-SignIn")]
        [Authorize(Roles = Role.Anonym)]
        public async Task Get()
        {
          
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                await OpenAuthSocket(webSocket); 
            }
            else
            {
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
        }



        private async Task OpenAuthSocket(WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            try
            {
               
                Result<string> result = _authService.GenerateLoginQRCode(webSocket);

                if (result.IsSuccess)
                {

                    buffer = Encoding.UTF8.GetBytes(result.Value);

                    //Отправили QRCode
                    await webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);

                    //Дождались ответа об завершении.
                    var receiveResult = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                    if (!receiveResult.CloseStatus.HasValue)
                    {
                        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, null, CancellationToken.None);
                    }

                }
                else
                {

                    await webSocket.CloseAsync(WebSocketCloseStatus.InternalServerError, result.Error, CancellationToken.None);
                     
                }
            }
            catch (Exception ex)
            {
                await webSocket.CloseAsync(WebSocketCloseStatus.InternalServerError, ex.Message, CancellationToken.None);
            } 

            
           
        }

        [HttpPost("select-object")]
        [Authorize(Roles = Role.User)]
        public async Task<IActionResult> SelectObject([FromBody] ObjectSelectRequest companyObjectRequest)
        {

            Result <ObjectSelectResponse> result = await _authService.GenerateTokenSelectObject(companyObjectRequest);

            if (result.IsSuccess)
                return Ok(result.Value);
            else
                return BadRequest(result.Error);

        }



        //Аутентификация с помощью логина и пароля 
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
