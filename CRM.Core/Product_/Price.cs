using System.ComponentModel.DataAnnotations.Schema;

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
