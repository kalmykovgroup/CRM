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
        
        public int AppointmentId { get; set; } //Должность
        public Appointment Appointment { get; set; } //Должность

        public string AccessToken { get; set; } = String.Empty;

        [MaxLength(255)]
        public string Name { get; set; } = String.Empty;

        [MaxLength(255)]
        public string Surname { get; set; } = String.Empty;

        [MaxLength(255)]
        public string Patronymic { get; set; } = String.Empty; //Отчество

        [MaxLength(4)]
        [MinLength(4)]
        public string? PassportSeries {  get; set; }

        [MaxLength(6)]
        [MinLength(6)]
        public string? PassportNumber { get; set; }

        [MaxLength(12)]
        [MinLength(12)]
        public string? Tin{ get; set; }  //ИНН (12 цифр)

        [MaxLength(12)] 
        [MinLength(12)] 
        public string? Snils { get; set; } = String.Empty; // переименовать??

        [MaxLength(255)]
        public string? Address { get; set; } = String.Empty; // Адрес

        [MaxLength(12)]
        [MinLength(3)]
        public string Phone { get; set; } = String.Empty; // Телефон

        [MaxLength(7)]
        [MinLength(255)]
        public string? Email { get; set; } = String.Empty;
         

        public DateTime ApplyingDate { get; set; } // Дата оформления 
        public DateTime? LayoffDate { get; set; } // Дата увольнения

        public DateTime Created_At { get; set; } // Дата создания
        public DateTime Updated_At { get; set; } // Дата последнего обновления

        

    }
}
