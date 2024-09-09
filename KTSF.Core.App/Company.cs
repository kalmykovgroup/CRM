using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Core.App
{
    public enum CompanyStatus { Active, Delete }

    [Table("companies")]
    public class Company
    { 
        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public List<Object> Objects { get; set; } = new();

        [MaxLength(255)]
        public string Name { get; set; } = String.Empty;

        public CompanyStatus CompanyStatus { get; set; } = CompanyStatus.Active;

        public DateTime Created_At { get; set; } = DateTime.Now;

       
    }
}
