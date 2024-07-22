using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary
{
    [Table("objects")]
    public class Object //Обьект(Магазин)
    { 
        public int Id { get; set; }

        [ForeignKey(nameof(Company))]
        public int CompanyId {  get; set; } //Компания к которой пренадлежит магазин
        public Company Company {  get; set; } = null!;

        [MaxLength(255)]
        public string Address { get; set; } = null!;

        [MaxLength(255)]
        public string? Name { get; set; }

       
    }
}
