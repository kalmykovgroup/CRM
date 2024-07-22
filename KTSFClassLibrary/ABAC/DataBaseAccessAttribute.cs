using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary.ABAC
{
    public enum DataBaseAction { Read,  Write, Update, Delete }
    //Сдесь храняться все возможные действия с таблицами и полями
    [Table("database_access_attributes")]
    public class DataBaseAccessAttribute
    {
        public int Id { get; set; }


        [ForeignKey(nameof(ASetOfRules))]
        public int ASetOfRulesId { get; set; }
        public ASetOfRules ASetOfRules { get; set; } = null!;

        //TableName + FieldName + UserId + Action
        public string Token { get; set; } = String.Empty;

        public bool IsAdminsConsent { get; set; } //Нужно ли подтверждение администратора на это действие

        [ForeignKey(nameof(Employee))]
        public int? EmployeeId { get; set; } //Ссылка на старшего работника, который должен подтвердить действие
        public Employee? Employee { get; set; } //Ссылка на старшего работника, который должен подтвердить действие

        public DateTime RangeFrom { get; set; }
        public DateTime RangeTo { get; set; }

    }
}
