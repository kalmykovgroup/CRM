using CommunityToolkit.Mvvm.ComponentModel;
using KTSFClassLibrary.ABAC;

namespace KTSFClassLibrary
{
    public partial class User : ObservableObject
    {
        public int Id { get; set; }

        public int ObjectId { get; set; }
        public Object Object { get; set; }

        public string Barcode { get; set; } //Штрих-код 

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }

        public int PassportSeries {  get; set; }
        public int PassportNumber { get; set; }
        public string InnNumber { get; set; } // переименовать??
        public string Snils { get; set; } // переименовать??
        public string Position { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime ApplyingDate { get; set; } = DateTime.Now; // Дата оформления 
        public DateTime? LayoffDate { get; set; } // Дата увольнения

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


        public List<AccessAttribute> AccessAttibutes { get; } = new List<AccessAttribute>();

    }
}
