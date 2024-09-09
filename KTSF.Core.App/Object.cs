 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTSF.Core.App
{

    public enum ObjectStatus { Active, Delete }

    [Table("objects")]
    public class Object //Обьект(Магазин)
    { 
        public int Id { get; set; }

        [ForeignKey(nameof(Company))]
        public int CompanyId {  get; set; } //Компания к которой пренадлежит магазин

        [NotMapped] 
        public Company Company {  get; set; } = null!;

        [MaxLength(255)]
        public string Address { get; set; } = null!;

        [MaxLength(255)]
        public string? Name { get; set; }

        [MaxLength(255)]
        public string DatabaseName { get; set; } = null!;

        public ObjectStatus ObjectStatus { get; set; } = ObjectStatus.Active;

        public DateTime Created_At { get; set; } = DateTime.Now;

    }
}
