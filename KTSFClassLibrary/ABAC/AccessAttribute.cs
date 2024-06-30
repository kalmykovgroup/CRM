using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary.ABAC
{
    //Сдесь храняться все возможные действия с таблицами и полями
    internal class AccessAttribute
    {
        public int Id { get; set; }

        public int CashierId { get; set; }
        public Cashier Cashier { get; set; }

        public int DataBaseActionId { get; set; }
        public int DatabaseTableId { get; set; }
        public int TableFieldId { get; set; }

    }
}
