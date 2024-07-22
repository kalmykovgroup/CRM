using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary.ABAC
{
    //Класс содержит набор правил доступа в приложении
    [Table("a_set_of_rules")]
    public class ASetOfRules 
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; } = "";

        public List<DataBaseAccessAttribute> AccessAttributes { get; } = new List<DataBaseAccessAttribute>();
        public List<ComponentAccessAttribute> ComponentAccessAttributes { get; } = new List<ComponentAccessAttribute>();

    }
}
