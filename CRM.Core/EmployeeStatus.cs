using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Core
{
    [Table("employee_statuses")]
    public class EmployeeStatus
    {
        public int Id {  get; set; }

        public string Name { get; set; } = null!;

        public override string ToString() => Name;
    }
}
