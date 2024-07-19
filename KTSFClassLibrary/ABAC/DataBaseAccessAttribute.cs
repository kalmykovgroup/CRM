using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary.ABAC
{
    //Сдесь храняться все возможные действия с таблицами и полями
    public class DataBaseAccessAttribute
    {
        public int Id { get; set; }

        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        public string TableName { get; set; }
        public string FieldName { get; set; }

        public int DataBaseActionId { get; set; }
        public DataBaseAction DataBaseAction { get; set; }

        public bool IsAdminsСonsent { get; set; } //Нужно ли подтверждение администратора на это действие
        public int? WorkerId { get; set; } //Ссылка на старшего работника, который должен подтвердить действие

        public DateTime RangeFrom { get; set; }
        public DateTime RangeTo { get; set; }

    }
}
