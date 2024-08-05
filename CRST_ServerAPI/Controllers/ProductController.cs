using CSharpFunctionalExtensions;
using KTSF.Application.Service;
using KTSF.Core.Product_;
using Microsoft.AspNetCore.Mvc;

namespace CRST_ServerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        private ProductsService productsService;

        public ProductController(ILogger<ProductController> logger, ProductsService productsService)
        {
            _logger = logger;
            this.productsService = productsService;
        }

        [HttpGet("{id}")]
        public IActionResult Find(int id)
        {

            Result<Product> result = productsService.Find(id);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            result.TryGetError(out string? error);

            return NotFound(error);

        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(productsService.GetAll());
        }


        [HttpPost]
        [Route("insert")]
        public IActionResult Insert(Product product)
        {
            Result<Product> result = productsService.Create(product);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }


            result.TryGetError(out string? error);

            return NotFound(error);
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update(Product product)
        {
            Result<Product> result = productsService.Update(product);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }


            result.TryGetError(out string? error);

            return NotFound(error);
        }

        ////Получить подробную информацию о товаре
        //[HttpPost("GetProductFullInfo")]
        //public ActionResult<ProductInformation> GetProductFullInfo(int productId)
        //{
        //    ProductRepository repository = new ProductRepository();
        //    return Ok(repository.GetProductFullInfo(productId));
        //}
    }
 
}
