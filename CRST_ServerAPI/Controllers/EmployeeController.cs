using CRST_ServerAPI.Data;
using CRST_ServerAPI.Data.Repositories;
using Dapper;
using KTSFClassLibrary;
using KTSFClassLibrary.ABAC;
using KTSFClassLibrary.Product_;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Exchange.WebServices.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace CRST_ServerAPI.Controllers
{
     
    public class EmployeeController : ApiController
    {
   


        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger) : base(logger)
        {
            _logger = logger;
        }

        public override IActionResult Find(int id)
        {
            Repository repository = new EmployeeRepository();

            var employee = repository.Find<Employee>(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        //Получить список всех сотрудников
        public override IActionResult GetAll()
        {
            Repository repository = new EmployeeRepository();
            return Ok(repository.GetAll<Employee>());
        }


        //  ?????? Зачем ID в параметрах, если мы инсертим??? и вообще нужен этот метод (есть Create)????
        public override IActionResult Insert<T>(int id, T obj)
        {
            throw new NotImplementedException();
        }


        [HttpPost("Update")]
        public  ActionResult<Employee> Update(int id) // в параметрах ID и JSON ???
        {
            using IDbConnection db = new MySqlConnection(AppDbContext.ConnectionString);
            db.Open();

            Employee? empl = db.Query<Employee>("SELECT * FROM employees WHERE Id = @Id", new { Id = id }).FirstOrDefault();

            if (empl != null)
            {
                empl.ObjectId = 1;
                empl.AppointmentId = 4;
                empl.ASetOfRulesId = 4;
                empl.AccessToken = "lkvbmekjlgnwieufhwyueigf";
                empl.Name = "XXXXXXXX";
                empl.Surname = "XXXXXXXXX";
                empl.Patronymic = "XXXXXXXX";
                empl.PassportSeries = "1234";
                empl.PassportNumber = "123456";
                empl.Tin = "999999999999";
                empl.Snils = "5555555555555";
                empl.Address = "Красная прощать 4";
                empl.Phone = "+79260128187";
                empl.Email = "aaa@aaa.ru";
                empl.ApplyingDate = DateTime.Now;
                empl.Created_At = DateTime.Now;
                empl.Updated_At = DateTime.Now;
                empl.Password = "tester";
                empl.EmployeeStatusId = 2;


                EmployeeRepository repository = new EmployeeRepository();
                repository.Update(empl);
            }
            return Ok(empl);
        }

        [HttpPost("Create")]
        public ActionResult<Employee> Create() // Employee в параметрах ??? нужен ??
        {
            Employee empl = new Employee()  // тестовый (использовать employee из параметров) 
            {
                ObjectId = 1,
                AppointmentId = 4,
                ASetOfRulesId = 4,
                AccessToken = "lkvbmekjlgnwieufhwyueigf",
                Name = "QQQQ",
                Surname = "WWWW",
                Patronymic = "EEEE",
                PassportSeries = "1234",
                PassportNumber = "123456",
                Tin = "999999999999",
                Snils = "5555555555555",
                Address = "Красная прощать 4",
                Phone = "+79260128187",
                Email = "aaa@aaa.ru",
                ApplyingDate = DateTime.Now,
                Created_At = DateTime.Now,
                Updated_At = DateTime.Now,
                Password = "tester",
                EmployeeStatusId = 2
            };            

            EmployeeRepository repository = new EmployeeRepository();
            repository.Create(empl);

            return Ok(empl);
        }


        // ????
        public override IActionResult Update<T>(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
