using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary.Product_
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
