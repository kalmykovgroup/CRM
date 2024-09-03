using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Dto.Employee_
{
    public class EmployeeUsernameResponse(List<string>? list, string? error = null)
    {
        public List<string>? Names { get; set; } = list;
        public string? Error { get; set; } = error;
    }
}
