
using KTSF.Core.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Dto.Company_
{
    public class CompanyCreateResponse(Company? company, string? error = null)
    {
        public Company? Company { get; } = company;
        public string? Error { get; } = error;
    }
}
