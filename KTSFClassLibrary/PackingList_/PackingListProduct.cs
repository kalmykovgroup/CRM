using KTSFClassLibrary.Product_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary.PackingList_
{
    public class PackingListProduct
    {
        public int Id { get; set; }

        public int PackingListId { get; set; }
        public PackingList PackingList { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
         
    }
}
