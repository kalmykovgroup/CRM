using KTSF.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Application.Interfaces.Auth
{
    public interface IJwtProvider
    {
        public string GenerateAccessToken(User user); 
    }
}
