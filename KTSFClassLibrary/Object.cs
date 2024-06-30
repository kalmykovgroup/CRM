using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary
{
    public class Object //Обьект(Магазин)
    {
        public int Id {  get; }

        public int CompanyId {  get; } //Компания к которой пренадлежит магазин
        public Company Company {  get; }

        public string? Name { get; set; } 
        public string Address { get; set; }
    }
}
