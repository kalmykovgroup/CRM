using KTSFClassLibrary.Product_;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary.PackingList_
{
    public class PackingList //Товарная накладная
    {
        public int Id { get; set; }
         
        public ObservableCollection<Product> Products { get; } = new(); //Ссылки на товар в базе

        public ObservableCollection<string> UrlImg { get; } = new(); //Фото накладной

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
