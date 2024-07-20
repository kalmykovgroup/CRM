using CommunityToolkit.Mvvm.ComponentModel;
using KTSFClassLibrary.ABAC;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTSFClassLibrary
{

    [Table("employee")]
    public partial class Employee
    { 
        public int Id { get; set; }
         
        public int ObjectId { get; set; }
        public Object Object { get; set; }     
        
        public Appointment Appointment { get; set; } //Должность

        public string AccessToken { get; set; } = String.Empty;

        [MaxLength(255)]
        public string Name { get; set; } = String.Empty;

        [MaxLength(255)]
        public string Surname { get; set; } = String.Empty;

        [MaxLength(255)]
        public string Patronymic { get; set; } = String.Empty; //Отчество

        [Length(4, 4)]
        public int? PassportSeries {  get; set; }

        [Length(6, 6)]
        public int? PassportNumber { get; set; }

        [Length(12, 12)]
        public string? Tin{ get; set; }  //ИНН (12 цифр)

        [Length(12, 12)] 
        public string? Snils { get; set; } = String.Empty; // переименовать??

        public string? Address { get; set; } = String.Empty; // Адрес

        [Length(3, 12)]
        public string Phone { get; set; } = String.Empty; // Телефон

        [Length(7, 255)]
        public string? Email { get; set; } = String.Empty;

        public DateTime ApplyingDate { get; set; } // Дата оформления 
        public DateTime? LayoffDate { get; set; } // Дата увольнения

        public DateTime Created_At { get; set; } // Дата создания
        public DateTime Updated_At { get; set; } // Дата последнего обновления

        

    }
}
