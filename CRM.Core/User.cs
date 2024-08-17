using CSharpFunctionalExtensions; 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
using System.Text.RegularExpressions; 

namespace KTSF.Core
{
    [Table("users")] 
    public class User
    {
       
        public int Id { get; set; }

        [MaxLength(255)]
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = String.Empty;

        public bool EmailConfirmed { get; set; } = false;

        [MaxLength(512)]
        public string PasswordHash { get; set; } = String.Empty;

        [MaxLength(255)]
        public string PhoneNumber { get; set; } = String.Empty;

        public bool PhoneNumberConfirmed { get; set; } = false; 

        [MaxLength(512)]
        public string AccessToken { get; set; } = String.Empty;
         
        [MaxLength(255)]
        public string Name { get; set; } = String.Empty;
         
        [MaxLength(255)]
        public string Surname { get; set; } = String.Empty;
         
        [MaxLength(255)]
        public string Patronymic { get; set; } = String.Empty;


         public static User Create(string email, string passwordHash, string phoneNumber, string accessToken, string name, string surname, string patronymic)
        {
            return new User()
            {
                Email = email,
                PasswordHash = passwordHash,
                PhoneNumber = phoneNumber, 
                AccessToken = accessToken,
                Name = name,
                Surname = surname,
                Patronymic = patronymic
            };
        }

 

        public override bool Equals(object? obj)
        {
            return obj is not null && obj is User user && user.Id == Id;
        }


        public static Result IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();
          
            try
            {
                if (!trimmedEmail.EndsWith("."))
                {
                    var addr = new System.Net.Mail.MailAddress(email);

                    if (addr.Address == trimmedEmail)
                    {
                        return Result.Success();
                    }
                }
               
            }
            catch{}

            return Result.Failure("Email не валидный");
        }


        public static Result IsValidPhone(string number)
        {
            string strPattern = @"(\+7|8|\b)[\(\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[)\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)";

            if (number != null && Regex.IsMatch(number, strPattern))
                return Result.Success();
            else 
                return Result.Failure("Телефон не валидный");
        }
    }
}
