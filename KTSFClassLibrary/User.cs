using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary
{ 
    public partial class User: ObservableObject
    { 
        public int Id { get; set; }
         
        [MaxLength(255)]
        public string Email { get; set; } = String.Empty;

         
        [MaxLength(255)]
        public string Phone{ get; set; } = String.Empty;
         
        [MaxLength(255)]
        public string Username { get; set; } = String.Empty;

         
        [MaxLength(255)]
        public string Password { get; set; } = String.Empty;
         
        public string AccessToken { get; set; } = String.Empty;
         
        [MaxLength(255)]
        public string Name { get; set; } = String.Empty;
         
        [MaxLength(255)]
        public string Surname { get; set; } = String.Empty;
         
        [MaxLength(255)]
        public string Patronimyc { get; set; } = String.Empty;


        public override bool Equals(object? obj)
        {
            return obj is not null && obj is Employee user && user.Id == Id;
        }
    }
}
