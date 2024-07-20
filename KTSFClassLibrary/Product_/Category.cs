using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary.Product_
{
    [Table("category")]
    public class Category
    { 
        public int Id { get ; set; }
         
        public int? ParentId { get ; set; }

        public Category? Parent { get ; set; }
    }
}
