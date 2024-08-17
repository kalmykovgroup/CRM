using CSharpFunctionalExtensions;
using KTSF.Application.Service;
using KTSF.Core;
using KTSF.Core.Product_;
using KTSF.Dto.Product_;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CRST_ServerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
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
        public async Task<IActionResult> Find(int id)
        {    
            Result<Product> result = await productsService.Find(id);            

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            result.TryGetError(out string? error);
            return NotFound(error);
        }


        [HttpGet("GetProductFullInfo")]
        public async Task<IActionResult> GetProductFullInfo(int id)
        {
            Result<ProductDTO> result = await productsService.GetProductFullInfo(id);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            result.TryGetError(out string? error);
            return NotFound(error);
        }


        [HttpGet("SearchProduct")]
        public async Task<IActionResult> SearchProduct(string name)
        {
            Result<Product[]> result = await productsService.SearchProduct(name);
            return Ok(result.Value);
        }


        // первая страница продуктов и общее количество продуктов
        [HttpGet("GetFirstPage")]
        public async Task<IActionResult> GetFirstPage()
        {
            Result<FirstPage> result = await productsService.GetFirstPage();
            return Ok(result.Value);
        }


        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts(int page)
        {
            Result<Product[]> result = await productsService.GetProducts(page);
            return Ok(result.Value);
        }


        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            Result<List<Product>> result = await productsService.GetAll();
            return Ok(result.Value);
        }


        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> Insert([FromBody] string str)
        {
            Product product = JsonSerializer.Deserialize <Product>(str);
            Result<Product> result = await productsService.Insert(product);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            result.TryGetError(out string? error);
            return NotFound(error);
        }


        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] string str)
        {
            Product product = JsonSerializer.Deserialize<Product>(str);
            Result<Product> result = await productsService.Update(product);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            result.TryGetError(out string? error);
            return NotFound(error);
        }


      


      

        

    }
 
}
