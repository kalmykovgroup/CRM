using KTSFClassLibrary.Product_;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary.ABAC
{
    [Table("employee_action")]
    public class EmployeeAction //Действия пользователей   
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string TableName { get; set; } = null!; //Таблица в которой произошло изменение

        public int FieldId { get; set; } //запись которую меняют
    
        //Здесь храняться json представление обьекта, который изменяют. Не полный! Только те поля которые были изменены.
        public string OldData { get; set; } = null!; //Старое значение

        public string NewData { get; set; } = null!; //Новое значение

        public bool AdminsСonsent { get; set; } = false; //Было ли подтверждение администратора

        public int? EmployeeId { get; set; } //Админ который дал согласие на изменение
        public Employee? Employee { get; set; }

        [MaxLength(255)]
        public string Ip { get; set; } = String.Empty; //Ip address 

        public string Agent { get; set; } = String.Empty; //HTTP Agent 

        public DateTime CreatedAt { get; set; } //Дата, когда изменение было применено
    }
}
