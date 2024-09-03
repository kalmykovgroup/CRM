
using KTSF.Core.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Dto.Auth
{
    public class LoginUserResponse
    {
        public User? User { get; set; }  
        public string? Error { get; set; } 

        public bool IsSuccess { get; set; }

        public LoginUserResponse()
        {

        }

        public LoginUserResponse(User user)
        {
            User = user;
            Error = null;
            IsSuccess = true;
        }

        public LoginUserResponse(string error)
        {
            User = null;
            Error = error;
            IsSuccess = false;
        }
    }
}
