using CRST_ServerAPI.Data;
using KTSFClassLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MySql.Data.MySqlClient;
using System.Data;

namespace CRST_ServerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {

        private readonly ILogger<ApiController> _logger;

        public ApiController(ILogger<ApiController> logger)
        {
            _logger = logger;
        }


        [HttpGet("{id}")] 
        public abstract IActionResult Find(int id);

        [HttpGet("all")]
        public abstract IActionResult GetAll();

        [HttpPost]
        [Route("update")]
        public abstract IActionResult Update<T>(T obj);

        [HttpPost]
        [Route("insert")]
        public abstract IActionResult Insert<T>(int id, T obj);

         
    }
}
