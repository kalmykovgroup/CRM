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
        private static readonly string _insertQuery = $@"insert into employees
                         (ObjectId, AppointmentId, ASetOfRulesId, EmployeeStatusId, AccessToken, Name, Surname,
                          Patronymic, PassportSeries, PassportNumber, Tin, Snils, Address, Phone, Email, ApplyingDate,
                          Created_At, Updated_At, EmployeeStatusId)
                          values
                          @ObjectId, @AppointmentId, @ASetOfRulesId, @EmployeeStatusId, @AccessToken, @Name, @Surname,
                          @Patronymic, @PassportSeries, @PassportNumber, @Tin, @Snils, @Address, @Phone, @Email, @ApplyingDate, @Created_At,Updated_At, @EmployeeStatusId";


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
 
        public override IActionResult GetAll()
        {
            Repository repository = new EmployeeRepository();
            return Ok(repository.GetAll<Employee>());
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
        public ActionResult<Employee> Create()
        {
            EmployeeRepository repository = new EmployeeRepository();          

            return Ok(repository.Create());
        }

    }
}
