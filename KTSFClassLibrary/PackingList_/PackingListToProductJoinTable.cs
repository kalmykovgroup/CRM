using KTSFClassLibrary.Product_;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary.PackingList_
{
    [Table("packing_list_to_product_joint_table")]
    public class PackingListToProductJoinTable //Связь многие ко многим 
    { 
        public int Id { get; set; }

        [Key]
        [Column(Order = 0)]
        public int PackingListId { get; set; }
        public PackingList PackingList { get; set; } = null!;

        [Key]
        [Column(Order = 1)]
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int Count { get; set; }

      
         
    }
}
