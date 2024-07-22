using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary.ABAC
{
    [Table("component_access_attributes")]
    public class ComponentAccessAttribute
    {
        public int Id { get; set; }


        [ForeignKey(nameof(ASetOfRules))]
        public int ASetOfRulesId { get; set; }
        public ASetOfRules ASetOfRules { get; set; } = null!;

        //Namespace + component name
        public string Token { get; set; } = string.Empty;
        
    }
}
