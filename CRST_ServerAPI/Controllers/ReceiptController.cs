using KTSF.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace KTSF.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReceiptController : ControllerBase
    {
        private ReceiptService receiptService;

        public ReceiptController(ReceiptService receiptService)
        {
            this.receiptService = receiptService;
        }





    }
}
