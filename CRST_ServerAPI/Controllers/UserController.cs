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
        public   IEnumerable<User> Get()
        {

            UserRepository userRepository = new UserRepository();

            List<User> users = userRepository.GetUsers();
            Console.WriteLine(users);
            return users.ToArray();
        }


        [HttpGet("{id}")]
        public User Get(int id)
        {

            return new User()
            {
                Name = "test",
                Id = id,
            };
        }
    }
}
