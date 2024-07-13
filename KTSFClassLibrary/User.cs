using CommunityToolkit.Mvvm.ComponentModel;
using KTSFClassLibrary.ABAC;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTSFClassLibrary
{ 
    public partial class User : ObservableObject
    { 
        public int Id { get; set; }
         
        public int ObjectId { get; set; }
        public Object Object { get; set; }

         
        [MaxLength(255)]
        public string Barcode { get; set; } //Штрих-код 
         
        [MaxLength(255)]
        public string Name { get; set; }
         
        [MaxLength(255)]
        public string Surname { get; set; }
         
        [MaxLength(255)]
        public string Patronymic { get; set; }

        public string PassportSeries {  get; set; }
        public string PassportNumber { get; set; }
        public string InnNumber { get; set; } // переименовать??
        public string Snils { get; set; } // переименовать??
        public string Position { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime ApplyingDate { get; set; } = DateTime.Now; // Дата оформления 
        public DateTime? LayoffDate { get; set; } // Дата увольнения
        public bool IsFired { get; set; } = false;

        // фото сотрудника - ???
        // ИНН (12 цифр) - string
        // трудовая -- ????
        // СНИЛС (123-456-789-00) - string
        // Должность
        // Адрес
        // Телефон
        // Почта
        // Дата оформления 
        // Дата увольнения
        // IsFired - уволен


        public List<AccessAttribute> AccessAttibutes { get; } = new List<AccessAttribute>();

    }
}
