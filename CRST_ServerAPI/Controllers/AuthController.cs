using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using MySql.Data.MySqlClient;
using System.Data;
using Dapper;
using KTSF.Core;
using KTSF.Persistence;
using Microsoft.AspNetCore.Authentication.OAuth;
namespace CRST_ServerAPI.Controllers {

    [ApiController]
    [Route ("[controller]")]
    public class AuthController : ControllerBase {


        private string GeneratePassword (string password) {
            return BCrypt.Net.BCrypt.EnhancedHashPassword (password);
        }


        /*  private readonly IAuthRepository _authRepo;
          public AuthController(IAuthRepository authRepository)
          {
              _authRepo = authRepository;
          }*/

        //public AuthController(IAuthRepository authRepository)
        //{
        //    _authRepo = authRepository;
        //}

        private bool VerifyPasswordHash (string password, byte[] passwordHash, byte[] passwordSalt) {
            using (var hmac = new System.Security.Cryptography.HMACSHA512 (passwordSalt)) {
                var computedHash = hmac.ComputeHash (System.Text.Encoding.UTF8.GetBytes (password));
                for (int i = 0; i < computedHash.Length; i++) {
                    if (computedHash[i] != passwordHash[i]) {
                        return false;
                    }
                }
                return true;
            }
        }

        /*  public IActionResult Login(string username, string password)
          {
              ServiceResponse<string> response = new ServiceResponse<string>();
              User user = await _context.Users.FirstOrDefaultAsync(x => x.Username.ToLower().Equals(username.ToLower()));

              return response;
          }

          [HttpPost("Login")]
          public async Task<IActionResult> Login(string username, string password)
          {
              ServiceResponse<string> response = await _authRepo.Login(
                  request.Username, request.Password);
              if (!response.Success)
              {
                  return BadRequest(response);
              }
              return Ok(response);
          }*/

        // тестовые данные вместо использования базы данных
        private List<User> people = new List<User>
        {
            new User {Email="admin@gmail.com", PasswordHash="12345" },
            new User { Email="qwerty@gmail.com", PasswordHash="55555" }
        };

        [HttpPost ("login")]
        public IActionResult Login (string username, string password) {
            return Ok ("ok");

            //ClaimsIdentity? identity = GetIdentity (username, password);
            //if (identity == null) {
            //    return BadRequest (new { errorText = "Invalid username or password." });
            //}

            //var now = DateTime.UtcNow;
            //// создаем JWT-токен
            //var jwt = new JwtSecurityToken (
            //issuer: AuthOptions.ISSUER,
            //        audience: AuthOptions.AUDIENCE,
            //        notBefore: now,
            //claims: identity.Claims,
            //        expires: now.Add (TimeSpan.FromMinutes (AuthOptions.LIFETIME)),
            //        signingCredentials: new SigningCredentials (AuthOptions.GetSymmetricSecurityKey (), SecurityAlgorithms.HmacSha256));
            //var encodedJwt = new JwtSecurityTokenHandler ().WriteToken (jwt);

            //var response = new {
            //    access_token = encodedJwt,
            //    username = identity.Name
            //};

            //return Ok (response);
        }

        private ClaimsIdentity? GetIdentity (string username, string password) {
            using IDbConnection db = new MySqlConnection (AppDbContext.ConnectionString);

            db.Open ();

            User? user = db.ExecuteScalar<User> ($"SELECT * FROM user WHERE email = {username} and password_hash = {password}");
            if (user != null) {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                 //   new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity (claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }

    }
}
