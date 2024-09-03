using CSharpFunctionalExtensions;
using KTSF.Application.Service;
using KTSF.Core;
using KTSF.Core.Product_;
using KTSF.Dto.Product_;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using KTSF.Core.Receipt_;

namespace CRST_ServerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ReceiptController : ControllerBase
    {
        private readonly ILogger<ReceiptController> _logger;

        private ReceiptsService receiptsService;

        public ReceiptController(ILogger<ReceiptController> logger, ReceiptsService receiptsService)
        {
            _logger = logger;
            this.receiptsService = receiptsService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Find(int id)
        {    
            Result<Receipt> result = await receiptsService.Find(id);            

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            result.TryGetError(out string? error);
            return NotFound(error);
        }


        [HttpGet("GetReceiptFullInfo")]
        public async Task<IActionResult> GetReceiptFullInfo(int id)
        {
            Result<ReceiptDTO> result = await receiptsService.GetReceiptFullInfo(id);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            result.TryGetError(out string? error);
            return NotFound(error);
        }


        // [HttpGet("SearchProduct")]
        // public async Task<IActionResult> SearchProduct(string name)
        // {
        //     Result<Product[]> result = await productsService.SearchProduct(name);
        //     return Ok(result.Value);
        // }


        // первая страница продуктов и общее количество продуктов
        [HttpGet("GetFirstPageReceipt")]
        public async Task<IActionResult> GetFirstPageReceipt()
        {
            Result<FirstPage<Receipt>> result = await receiptsService.GetFirstPageReceipt();
            return Ok(result.Value);
        }


        [HttpGet("GetReceipts")]
        public async Task<IActionResult> GetReceipts(int page)
        {
            Result<Receipt[]> result = await receiptsService.GetReceipts(page);
            return Ok(result.Value);
        }


        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            Result<List<Receipt>> result = await receiptsService.GetAll();
            return Ok(result.Value);
        }


        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> Insert([FromBody] string str)
        {
            Result receipt = JsonSerializer.Deserialize <Receipt>(str);
            Result<Receipt> result = await receiptsService.Insert(receipt);

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
            Receipt receipt = JsonSerializer.Deserialize<Receipt>(str);
            Result<Product> result = await receiptsService.Update(receipt);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            result.TryGetError(out string? error);
            return NotFound(error);
        }


      


      

        

    }
 
}
