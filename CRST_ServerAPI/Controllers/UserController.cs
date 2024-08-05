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

        //[HttpPost("Update")]
        //public ActionResult<User> Update(int id) // в параметрах ID и JSON ???
        //{
        //    using IDbConnection db = new MySqlConnection(AppDbContext.ConnectionString);
        //    db.Open();

        //    User? user = db.Query<User>("SELECT * FROM users WHERE Id = @Id", new {Id = id}).FirstOrDefault();

        //    if (user != null)
        //    {
        //        user.Email = "garry@test.ru";
        //        user.Phone = "+2223331100";
        //        user.Name = "SSSSSSS";
        //        user.Surname = "DDDDDDD";
        //        user.Patronymic = "FFFFFF";

        //        UserRepository repository = new UserRepository();
        //        repository.Update(user);
        //    }

        //    return user == null ? NotFound() : Ok(user); // ????
        //}

        //[HttpPost("Create")]
        //public ActionResult<User> Create() // User в параметрах ??? нужен ??
        //{      
        //    User us = new User() // тестовый (использовать user из параметров) 
        //    {
        //        Email = "qqq@qqq.ru",
        //        Phone = "+79260128187",
        //        Password = "tester",
        //        AccessToken = "bgUYGBvkuybjkyGJGVjhyvbjyuBKYJ",
        //        Name = "QQQ",
        //        Surname = "WWW",
        //        Patronymic = "EEE",
        //        PasswordHash = Encoding.UTF8.GetBytes("test"),
        //        PasswordSalt = Encoding.UTF8.GetBytes("test")
        //    };

        //    UserRepository repository = new UserRepository();
        //    repository.Create(us);


        //    return Ok(us);
        //}

        //[HttpGet("GetByEmail")]
        //public string GetByEmail(string email)
        //{    
        //    using IDbConnection db = new MySqlConnection(AppDbContext.ConnectionString);
        //    db.Open();

        //    var user = db.Query<User>($"SELECT * FROM users WHERE Email={email}").First();

        //    return $"{user.Name} {user.Surname} {user.Email}";
        //}

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
