using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary
{
    [Table("company")]
    public class Company
    { 
        public int Id { get; set; }
         
        public int UserId { get; set; }
        public User User { get; set; } // точно Employee ??? может User ??

         
        [MaxLength(255)]
        public string Name { get; set; }

       
    }
}
