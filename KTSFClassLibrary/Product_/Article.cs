using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary.Product_
{
    [Table("article")]
    public class Article
    { 
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        [MaxLength(512)]
        [Key]
        public string Name { get; set; } = String.Empty;
    }
}
