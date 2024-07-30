using CommunityToolkit.Mvvm.ComponentModel;
using KTSFClassLibrary.ABAC;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTSFClassLibrary
{

    [Table("employees")]
    public partial class Employee
    { 
         
        public int Id { get; set; }

        [ForeignKey(nameof(Object))]
        public int ObjectId { get; set; }
        public Object Object { get; set; } = null!;

        [ForeignKey(nameof(Appointment))]
        public int AppointmentId { get; set; } //Должность
        public Appointment Appointment { get; set; } = null!; //Должность

        [ForeignKey(nameof(ASetOfRules))]
        public int ASetOfRulesId { get; set; } //Набор правил доступа
        public ASetOfRules ASetOfRules { get; set; } = null!; //Набор правил доступа

        [MaxLength(512)]
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

        [MaxLength(255)]
        [MinLength(7)]
        public string? Email { get; set; } = String.Empty;

        public DateTime? ApplyingDate { get; set; } // Дата оформления 
        public DateTime? LayoffDate { get; set; } // Дата увольнения
        
        public DateTime Created_At { get; set; } // Дата создания
        public DateTime Updated_At { get; set; } // Дата последнего обновления


        [MaxLength(255)]
        public string Password { get; set; } = null!; // генерируется и приходит на почту




        [ForeignKey(nameof(EmployeeStatus))]
        public int EmployeeStatusId { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; } = null!;

        public Employee Copy()
        {
            return new Employee()
            {
                Id = this.Id,
                ObjectId = this.ObjectId, 
                AccessToken = this.AccessToken,
                AppointmentId = this.AppointmentId,
                Name = this.Name,
                Surname = this.Surname,
                Patronymic = this.Patronymic,
                PassportSeries = this.PassportSeries,
                PassportNumber = this.PassportNumber,
                Tin = this.Tin,
                Snils = this.Snils,
                Address = this.Address,
                Phone = this.Phone,
                Email = this.Email,
                ApplyingDate = this.ApplyingDate,
                LayoffDate = this.LayoffDate,
                Created_At = this.Created_At,
                Updated_At = this.Updated_At, 
                Password = this.Password,
                EmployeeStatusId = this.EmployeeStatusId
            };
        }

    }
}
