using CRST_ServerAPI.Data;
using CRST_ServerAPI.Data.Repositories;
using Dapper;
using KTSFClassLibrary;
using KTSFClassLibrary.Product_;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.FileSystemGlobbing;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace CRST_ServerAPI.Controllers
{

    public class UserController : ApiController
    {

        public UserController(ILogger<UserController> logger) : base(logger)
        {

        }


        public override IActionResult Find(int id)
        {
            Repository repository = new UserRepository();

            var employee = repository.Find<User>(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }


        public override IActionResult GetAll()
        {
            Repository repository = new UserRepository();
            return Ok(repository.GetAll<User>());
        }


        // ????
        public override IActionResult Insert<T>(int id, T obj)
        {
            throw new NotImplementedException();
        }

        [HttpPost("Update")]
        public ActionResult<User> Update(int id) // в параметрах ID и JSON ???
        {
            using IDbConnection db = new MySqlConnection(AppDbContext.ConnectionString);
            db.Open();

            User? user = db.Query<User>("SELECT * FROM users WHERE Id = @Id", new {Id = id}).FirstOrDefault();

            if (user != null)
            {
                user.Email = "garry@test.ru";
                user.Phone = "+2223331100";
                user.Name = "SSSSSSS";
                user.Surname = "DDDDDDD";
                user.Patronymic = "FFFFFF";

                UserRepository repository = new UserRepository();
                repository.Update(user);
            }

            return user == null ? NotFound() : Ok(user); // ????
        }

        [HttpPost("Create")]
        public ActionResult<User> Create() // User в параметрах ??? нужен ??
        {      
            User us = new User() // тестовый (использовать user из параметров) 
            {
                Email = "qqq@qqq.ru",
                Phone = "+79260128187",
                Password = "tester",
                AccessToken = "bgUYGBvkuybjkyGJGVjhyvbjyuBKYJ",
                Name = "QQQ",
                Surname = "WWW",
                Patronymic = "EEE",
                PasswordHash = Encoding.UTF8.GetBytes("test"),
                PasswordSalt = Encoding.UTF8.GetBytes("test")
            };

            UserRepository repository = new UserRepository();
            repository.Create(us);


            return Ok(us);
        }

        [HttpGet("GetByEmail")]
        public string GetByEmail(string email)
        {    
            using IDbConnection db = new MySqlConnection(AppDbContext.ConnectionString);
            db.Open();

            var user = db.Query<User>($"SELECT * FROM users WHERE Email={email}").First();

            return $"{user.Name} {user.Surname} {user.Email}";
        }


        // ?????
        public override IActionResult Update<T>(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
