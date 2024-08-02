using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Core.Product_
{
    [Table("prices")]
    public class Price
    {
         
        public int Id {  get; set; }
         
        public ulong Cost { get; set; } //Стоимость
         
        public DateTime CreatedAt { get; set; } 
    }
}
