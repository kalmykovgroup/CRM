using CSharpFunctionalExtensions;
using KTSF.Api.Extensions.Repositories;
using KTSF.Application.Service;
using KTSF.Core;
using KTSF.Core.Product_;
using KTSF.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.FileSystemGlobbing;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
using System.Text.Json;

namespace CRST_ServerAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
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
        public async Task<IActionResult> Find(int id)
        {
            Result<User> result = await usersService.Find(id);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            result.TryGetError(out string? error);

            return NotFound(error);
        }


        [HttpGet("GetByEmail")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            Result<User?> result = await usersService.GetByEmail(email);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            result.TryGetError(out string? error);
            return NotFound(error);
        }       


        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            Result<User[]> result = await usersService.GetAll();
            return Ok(result.Value);
        }


        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> Insert([FromBody] string str)
        {
            User user = JsonSerializer.Deserialize<User>(str);
            Result<User> result = await usersService.Create(user);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            result.TryGetError(out string? error);
            return NotFound(error);
        }


        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] string str)
        {
            User user = JsonSerializer.Deserialize<User>(str);
            Result<User> result = await usersService.Update(user);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            result.TryGetError(out string? error);
            return NotFound(error);
        }
    }
}
