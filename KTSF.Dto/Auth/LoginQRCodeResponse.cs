using KTSF.Core.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Dto.Auth
{
    public class LoginQRCodeResponse
    {
        public string? QRCode { get; set; }
        public string? Error { get; set; }

        public LoginQRCodeResponse() { }

        public LoginQRCodeResponse(string? _QRCode, string? Error = null)
        {
            QRCode = _QRCode; 
            Error = null;
        }
         
    }
}
