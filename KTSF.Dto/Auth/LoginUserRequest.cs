namespace KTSF.Dto.Auth
{
    public class LoginUserRequest(string username, string password)
    {
        public string Username { get; set; } = username;
        public string Password { get; set; } = password;
    }
}
