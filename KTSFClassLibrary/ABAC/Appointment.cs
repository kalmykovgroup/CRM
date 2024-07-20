using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary.ABAC
{
    [Table("appointment")]
    public class Appointment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<DataBaseAccessAttribute> AccessAttibutes { get; } = new List<DataBaseAccessAttribute>();

    }
}
