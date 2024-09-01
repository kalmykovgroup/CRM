using KTSF.Application.Service;
 
using KTSF.Core.App;
using KTSF.Core.Object;
using KTSF.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KTSF.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class TestController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;


        private readonly HttpContext? _httpContext;

        public TestController(ILogger<UserController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;

            _httpContext = httpContextAccessor.HttpContext;
        }

        [HttpGet("test")]
        [Authorize(Roles = $"{Role.Employee},{Role.User}")] 
        public async Task<IActionResult> Test()
        {
            await Task.Delay(0);
            

           

            return Ok(_httpContext?.User?.Identity?.Name);
        }
         

         
    }
}
