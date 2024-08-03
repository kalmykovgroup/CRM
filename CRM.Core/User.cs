using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Core
{
    [Table("users")]
    public partial class User
    { 
        public int Id { get; set; }
         
        [MaxLength(255)]
        public string Email { get; set; } = String.Empty;
         
        [MaxLength(255)]
        public string Phone{ get; set; } = String.Empty;
                
        public string? PasswordHash { get; set; } 

        [MaxLength(512)]
        public string AccessToken { get; set; } = String.Empty;
         
        [MaxLength(255)]
        public string Name { get; set; } = String.Empty;
         
        [MaxLength(255)]
        public string Surname { get; set; } = String.Empty;
         
        [MaxLength(255)]
        public string Patronymic { get; set; } = String.Empty;



        public override bool Equals(object? obj)
        {
            return obj is not null && obj is User user && user.Id == Id;
        }
    }
}
