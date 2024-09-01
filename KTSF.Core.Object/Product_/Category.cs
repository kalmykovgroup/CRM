using System.ComponentModel.DataAnnotations.Schema;

namespace KTSF.Core.Object.Product_
{
    [Table("categories")]
    public class Category
    { 
        public int Id { get ; set; }
         
        public string Name { get ; set; } = String.Empty;


        [ForeignKey(nameof(Category))]
        public int? ParentId { get ; set; }
        public Category? Parent { get ; set; }

        public List<Product> Products { get; } = [];
        public List<ProductToCategoryJoinTable> ProductToCategoryJoinTables { get; } = [];
    }
}
