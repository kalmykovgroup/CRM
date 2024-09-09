//using Azure.Core;
//using Dapper;
//using KTSFClassLibrary;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
//using MySql.Data.MySqlClient;
//using System.Data;

//namespace CRST_ServerAPI.Data.Repositories
//{
//    public class AuthRepository : IAuthRepository
//    {
//       /* public Task<Microsoft.Exchange.WebServices.Data.ServiceResponse<string>> Login(string username, string password)
//        {
//            throw new NotImplementedException();
//        }*/

//      /*  public Task<Microsoft.Exchange.WebServices.Data.ServiceResponse<int>> Register(User user, string password)
//        {
//            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

//            user.PasswordHash = passwordHash;
//            user.PasswordSalt = passwordSalt;

//            await _context.Users.AddAsync(user);
//            await _context.SaveChangesAsync();

//            ServiceResponse<int> response = new ServiceResponse<int>();
//            response.Data = user.Id;
//            return response;
//        }*/

//        public Task<bool> UserExists(string username)
//        {
//            throw new NotImplementedException();
//        }

//        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
//        {
//            using (var hmac = new System.Security.Cryptography.HMACSHA512())
//            {
//                passwordSalt = hmac.Key;
//                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
//            }
//        }

//        public string? Login(string username, string password)
//        {
//            using IDbConnection db = new MySqlConnection(ObjectDbContext.DatabaseName);
//            db.Open();

//            User? user = db.Query<User>($"SELECT * FROM users WHERE Email=@username", new {username = username}).FirstOrDefault();

//            if (user != null && password == user.Password) // сравнивыать хеш пароли
//            {
//                user.JwtToken = GenerateUserJwtToken(user.Id);


//                // некорректный запрос
//                //try
//                //{
//                //    db.Execute("update user set JwtToken = @JwtToken where Id = @Id",
//                //                new { Id = user.Id, JwtToken = user.JwtToken });
//                //}catch (Exception ex)
//                //{
//                //    return "это эксепшен"; // ???? подумать
//                //}


//                return user.JwtToken;
//            }            

//            return "это конец";
//        }     

//        private string GenerateUserJwtToken(int id)
//        {
//            return "Token test";
//        }




//    }
//}
