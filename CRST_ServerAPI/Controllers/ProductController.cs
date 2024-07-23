using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRST_ServerAPI.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public ProductController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

    }
 
}
