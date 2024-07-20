using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary.Product_
{
    [Table("price")]
    public class Price
    {
         
        public int Id {  get; set; }
         
        public int Cost { get; set; } //Стоимость
         
        public DateTime CreatedAt { get; set; } 
    }
}
