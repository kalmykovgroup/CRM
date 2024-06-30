using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KTSFClassLibrary.ABAC;

namespace KTSFClassLibrary
{
    internal class Cashier //Кассир
    {
        public int Id { get; set; }

        public int ObjectId { get; set; }
        public Object Object { get; set; }

        public string Barcode { get; set; } //Штрих-код 

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }

        public List<AccessAttribute> AccessAttibutes { get; } = new List<AccessAttribute>();

    }
}
