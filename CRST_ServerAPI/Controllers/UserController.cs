using CRST_ServerAPI.Data;
using KTSFClassLibrary;
using Microsoft.AspNetCore.Mvc;

namespace CRST_ServerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<Employee>Get()
        {
            UserRepository userRepository = new UserRepository();

            List<Employee> employees = userRepository.GetEmployees();
            Console.WriteLine(employees);
            return employees.ToArray();
        }


        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return new Employee()
            {
                Name = "test",
                Id = id,
            };
        }
    }
}
