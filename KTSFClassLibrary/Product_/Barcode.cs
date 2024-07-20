using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary.Product_
{
    [Table("barcode")]
    public class Barcode
    { 
        public int Id { get; set; }
         
        [MaxLength(255)]
        public string Code { get; set; } = String.Empty;
    }
}
