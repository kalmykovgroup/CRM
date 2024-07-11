using KTSFClassLibrary.Product_;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary
{
    [Table(nameof(UserActions))]
    public class UserActions //Действия пользователей   
    {
         
        public int Id { get; set; }
         
        [MaxLength(255)]
        public string TableName { get; set; } //Таблица в которой произошло изменение
         
        public int FieldId { get; set; } //Поле на которое меняют
         
        public Type DataType { get; set; } //Тип поля
         
        [MaxLength(255)]
        public string OldData { get; set; } //Старое значение
         
        [MaxLength(255)]
        public string NewData { get; set; } //Новое значение
         
        public bool AdminsСonsent { get; set; } //Было ли подтверждение администратора
         
        public int AdminId { get; set; } //Админ или Менеджер который дал согласие на изменение
         
        public DateTime CreatedAt { get; set; } //Дата, когда изменение было применено
    }
}
