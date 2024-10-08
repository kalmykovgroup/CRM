﻿using KTSF.Core.Object.Product_; 
using System.ComponentModel.DataAnnotations.Schema;

namespace KTSF.Core.Object.PackingList_
{
    [Table("packing_list_to_product_joint_tables")]
    public class PackingListToProductJoinTable //Связь многие ко многим 
    { 
        public int Id { get; set; }

        public int PackingListId { get; set; }
        public PackingList PackingList { get; set; } = null!;
         
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int Count { get; set; }

      
         
    }
}
