using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary.ABAC
{
    //Сдесь храняться все возможные действия с таблицами и полями
    [Table("database_access_attribute")]
    public class DataBaseAccessAttribute
    {
        public int Id { get; set; }

        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        [MaxLength(255)]
        public string TableName { get; set; }

        [MaxLength(255)]
        public string FieldName { get; set; }

        public int DataBaseActionId { get; set; }
        public DataBaseAction DataBaseAction { get; set; }

        public bool IsAdminsСonsent { get; set; } //Нужно ли подтверждение администратора на это действие
        public int? EmployeeId { get; set; } //Ссылка на старшего работника, который должен подтвердить действие

        public DateTime RangeFrom { get; set; }
        public DateTime RangeTo { get; set; }

    }
}
