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

       

        public override IActionResult Insert<T>(int id, T obj)
        {
            throw new NotImplementedException();
        }

        public override IActionResult Update<T>(T obj)
        {
            throw new NotImplementedException();
        }

        [HttpPost("Create")]
        public string Create()
        {     

            User us = new User()
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


            using IDbConnection db = new MySqlConnection(AppDbContext.ConnectionString);
            db.Open();


            string sqlQuery = $@"insert into users
               ({nameof(us.Email)}, 
                {nameof(us.Phone)},  
                {nameof(us.Password)}, 
                {nameof(us.AccessToken)}, 
                {nameof(us.Name)}, 
                {nameof(us.Surname)}, 
                {nameof(us.Patronymic)})
               values (
               @{nameof(us.Email)}, 
               @{nameof(us.Phone)},  
               @{nameof(us.Password)}, 
               @{nameof(us.AccessToken)}, 
               @{nameof(us.Name)}, 
               @{nameof(us.Surname)}, 
               @{nameof(us.Patronymic)})"; 


            int userId = db.ExecuteScalar<int>(sqlQuery, us);


            return "Ok";
        }

        [HttpGet("GetByEmail")]
        public string GetByEmail(string email)
        {
            // не ищет по email ... в строке запроса какая то херь!)))
            // https://localhost:7286/User/GetByEmail?phone=qqq%40qqq.ru

            using IDbConnection db = new MySqlConnection(AppDbContext.ConnectionString);
            db.Open();

            var user = db.Query<User>($"SELECT * FROM users WHERE Email={email}").First();

            return $"{user.Name} {user.Surname} {user.Email}";
        }
        



    }
}
