using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Dto.Company_
{
    public class CompanyDeleteResponse(bool? result, string? error = null)
    {
        public bool? Result { get; } = result; 
        public string? Error { get; } = error;
    }
}
