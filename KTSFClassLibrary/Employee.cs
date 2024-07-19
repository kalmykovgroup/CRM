using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KTSFClassLibrary
{


    public partial class Employee : ObservableObject
    { 
        public int Id { get; set; }
         
        public int ObjectId { get; set; }
        public Object Object { get; set; }     
        
        public Appointment Appointment { get; set; } //Должность

        public string AccessToken { get; set; } = String.Empty;

        [MaxLength(255)]
        public string Name { get; set; }
         
        [MaxLength(255)]
        public string Surname { get; set; }
         
        [MaxLength(255)]
        public string Patronymic { get; set; } //Отчество

        [Length(4, 4)]
        public int PassportSeries {  get; set; }

        [Length(6, 6)]
        public int PassportNumber { get; set; }

        [Length(12, 12)]
        public string Tin{ get; set; } //ИНН (12 цифр)

        [Length(12, 12)] 
        public string Snils { get; set; } // переименовать??
         
        public string Address { get; set; } // Адрес

        [Length(3, 12)]
        public string Phone { get; set; } // Телефон

        [Length(7, 255)]
        public string Email { get; set; }

        public DateTime ApplyingDate { get; set; } // Дата оформления 
        public DateTime? LayoffDate { get; set; } // Дата увольнения

        public DateTime Created_At { get; set; } // Дата создания
        public DateTime Updated_At { get; set; } // Дата последнего обновления

        

    }
}
