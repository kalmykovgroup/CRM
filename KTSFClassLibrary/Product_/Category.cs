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
         
        // НЕ ПОНЯТНО ... ЧТО ЭТО?
        public int? ParentId { get ; set; }

        // И ТУТ ТОЖЕ
        public Category? Parent { get ; set; }
    }
}
