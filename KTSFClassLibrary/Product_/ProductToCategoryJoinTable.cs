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
    public class ProductToCategoryJoinTable
    {

        [Key]
        [Column(Order = 0)]
        public int ProductId {  get; set; }
        public Product Product { get; set; } = null!;

        [Key]
        [Column(Order = 1)]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
