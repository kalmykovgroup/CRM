using CRST_ServerAPI.Data;
using CRST_ServerAPI.Data.Repositories;
using KTSFClassLibrary;
using KTSFClassLibrary.Product_;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRST_ServerAPI.Controllers
{
    public class ProductController : ApiController
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger) : base(logger) {

            _logger = logger;
        }

        public override IActionResult Find(int id)
        {
            Repository repository = new ProductRepository();

            var product = repository.Find<Product>(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }


        public override IActionResult GetAll()
        {
            Repository repository = new ProductRepository();
            return Ok(repository.GetAll<Product>());
        }

        public override IActionResult Insert<T>(int id, T obj)
        {
            throw new NotImplementedException();
        }

        public override IActionResult Update<T>(T obj)
        {
            throw new NotImplementedException();
        }

        //Получить подробную информацию о товаре
        [HttpPost("GetProductFullInfo")]
        public ActionResult<ProductInformation> GetProductFullInfo(int productId)
        {
            ProductRepository repository = new ProductRepository();
            return Ok(repository.GetProductFullInfo(productId));
        }
    }
 
}
