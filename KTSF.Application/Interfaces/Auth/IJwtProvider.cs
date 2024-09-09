using KTSF.Core.App;
using KTSF.Core.Object;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Object = KTSF.Core.App.Object;

namespace KTSF.Application.Interfaces.Auth
{
    public interface IJwtProvider
    {
       public string GenerateUserJwtToken(User user);
        public string GenerateJwtTokenSelectedObject(User user, Company company, Object @object);
        public string GenerateEmployeeJwtToken(User user, Employee employee, Company company, Object @object);
         
    }
}
