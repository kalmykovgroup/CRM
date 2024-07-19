using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary
{ 
    public class Company
    { 
        public int Id { get; }
         
        public int UserId { get; }
        public Employee User { get; }

         
        [MaxLength(255)]
        public string Name { get; }

    }
}
