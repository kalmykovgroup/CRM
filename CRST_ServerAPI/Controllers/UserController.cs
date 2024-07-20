using CRST_ServerAPI.Data;
using KTSFClassLibrary;
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
        public IActionResult Get(int id)
        {
            Repository repository = new UserRepository();
 
            return Ok(repository.Find<Employee>(id));
        }
    }
}
