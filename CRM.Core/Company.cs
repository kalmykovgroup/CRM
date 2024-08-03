using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Core
{
    [Table("companies")]
    public class Company
    { 
        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; } = null!;


        [MaxLength(255)]
        public string Name { get; set; } = String.Empty;

       
    }
}
