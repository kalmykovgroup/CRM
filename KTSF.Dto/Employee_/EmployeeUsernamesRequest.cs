using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Dto.Employee_
{
    public class EmployeeUsernamesRequest(int companyId, int objectId)
    {
        public int CompanyId { get; set; } = companyId;
        public int ObjectId { get; set; } = objectId;
    }
}
