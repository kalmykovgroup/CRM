using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace KTSF.Core.ABAC
{
    //Класс содержит набор правил доступа в приложении
    [Table("a_set_of_rules")]
    public class ASetOfRules 
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; } = String.Empty;

        [MaxLength(1000)]
        public string Description { get; set; } = String.Empty;

        public List<DataBaseAccessAttribute> AccessAttributes { get; } = [];
        public List<ComponentAccessAttribute> ComponentAccessAttributes { get; } = [];

        public override string ToString() => Name;
    }
}
