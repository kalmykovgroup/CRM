 
using KTSF.Core.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Dto.Company_
{
    public class CompanyAllResponse(List<Company>? companies, string? error = null)
    {
        public List<Company>? Companies { get; } = companies;
        public string? Error { get; } = error;   
    }
}
