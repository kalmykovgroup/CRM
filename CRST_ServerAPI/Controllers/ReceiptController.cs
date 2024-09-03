﻿using CSharpFunctionalExtensions;
using KTSF.Application.Service;
using KTSF.Core.Object.Receipt_;
using KTSF.Dto.Product_;
using Microsoft.AspNetCore.Mvc;
using KTSF.Dto.Receipt_;
using System.Text.Json;

namespace KTSF.Api.Controllers
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
        
        // первая страница продуктов и общее количество продуктов
        [HttpGet("GetFirstPage")]
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
            Receipt receipt = JsonSerializer.Deserialize <Receipt>(str);
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
            Result<Receipt> result = await receiptsService.Update(receipt);
            
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            
            result.TryGetError(out string? error);
            return NotFound(error);
        }
    }
 
}
