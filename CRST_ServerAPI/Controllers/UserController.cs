using CRST_ServerAPI.Data;
using KTSFClassLibrary;
using KTSFClassLibrary.Product_;
using Microsoft.AspNetCore.Mvc; 

namespace CRST_ServerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {


       
        [HttpGet]
        [Route("all")]
        public IActionResult Get()
        {
            Repository repository = new UserRepository();
            return Ok(repository.GetAll<Employee>()); 
  
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            Repository repository = new UserRepository();

            var employee = repository.Find<Employee>(id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }

 
    }
}
