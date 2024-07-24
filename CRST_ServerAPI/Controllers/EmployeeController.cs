using CRST_ServerAPI.Data;
using CRST_ServerAPI.Data.Repositories;
using KTSFClassLibrary;
using KTSFClassLibrary.Product_;
using Microsoft.AspNetCore.Mvc;

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

    }
}
