
using System.ComponentModel.DataAnnotations.Schema;
namespace KTSF.Core.Object.Product_
{
    [Table("product_to_category_join_tables")]
    public class ProductToCategoryJoinTable
    { 
        public int Id { get; set; }
         
        public int ProductId {  get; set; }
        public Product Product { get; set; } = null!;
         
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
