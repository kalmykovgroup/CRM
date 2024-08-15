using CSharpFunctionalExtensions; 
using KTSF.Application.Service;
using KTSF.Core;
using KTSF.Core.Product_;
using KTSF.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRST_ServerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        private UsersService usersService;

        public UserController(ILogger<UserController> logger, UsersService usersService)
        {
            _logger = logger;
            this.usersService = usersService;
        }


        [HttpGet("{id}")]
        public IActionResult Find(int id)
        {

            Result<User> result = usersService.Find(id);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }


            result.TryGetError(out string? error);

            return NotFound(error);

        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(usersService.GetAll());
        }


        [HttpPost]
        [Route("insert")]
        public IActionResult Insert(User user)
        {
            Result<User> result = usersService.Create(user);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }


            result.TryGetError(out string? error);

            return NotFound(error);
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update(User user)
        {
            Result<User> result = usersService.Update(user);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }


            result.TryGetError(out string? error);

            return NotFound(error);
        }
    }
}
