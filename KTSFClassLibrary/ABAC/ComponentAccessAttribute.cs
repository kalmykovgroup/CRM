using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary.ABAC
{
    [Table("component_access_attribute")]
    public class ComponentAccessAttribute
    {
        public int Id { get; set; }

        public int ASetOfRulesId { get; set; }
        public ASetOfRules ASetOfRules { get; set; }

        //Namespace + component name
        public string Token { get; set; } = string.Empty;
        
    }
}
