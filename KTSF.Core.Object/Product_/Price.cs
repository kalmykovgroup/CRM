using System.ComponentModel.DataAnnotations.Schema;

namespace KTSF.Core.Object.Product_
{
    [Table("prices")]
    public class Price
    {
         
        public int Id {  get; set; }
         
        public ulong Cost { get; set; } //Стоимость
         
        public DateTime CreatedAt { get; set; } 

        public int ProductInformationIp { get; set; }
        public ProductInformation ProductInformation { get; set; } = null!;
    }
}
