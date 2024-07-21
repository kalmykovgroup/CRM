using KTSFClassLibrary.Product_;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary.PackingList_
{
    [Table("packing_list")]
    public class PackingList //Товарная накладная
    {
        public int Id { get; set; }

        public List<PackingListProduct> PackingListProducts { get; } = new(); //Ссылки на товар в базе

        //public string UrlImg { get; } = "";  //Фото накладной (если не на одном листе) 

        public DateTime CreatedAt { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
      
    }
}
