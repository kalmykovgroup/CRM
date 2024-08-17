using System.ComponentModel.DataAnnotations;

namespace KTSF.Dto.Auth
{
    public class RegisterUserRequest
    { 
        public string Password { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;
         
        public string Phone { get; set; } = String.Empty;
                
        public string Name { get; set; } = String.Empty;
         
        public string Surname { get; set; } = String.Empty;
         
        public string Patronymic { get; set; } = String.Empty;

    }
}
