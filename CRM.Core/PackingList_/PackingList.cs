using KTSF.Core.Product_;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTSF.Core.PackingList_
{
    [Table("packing_lists")]
    public class PackingList //Товарная накладная
    {
        public int Id { get; set; }

        public List<Product> Products { get; } = []; //Ссылки на товар в базе 
        public List<PackingListToProductJoinTable> PackingListToProductJoinTables { get; } = [];  
        

        //public string UrlImg { get; } = "";  //Фото накладной (если не на одном листе) 

        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

    }
}
