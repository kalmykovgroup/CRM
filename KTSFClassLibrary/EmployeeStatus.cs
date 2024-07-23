using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary
{
    [Table("employee_statuses")]
    public class EmployeeStatus
    {
        public int Id {  get; set; }

        public string Name { get; set; } = null!;
    }
}
