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
//            using IDbConnection db = new MySqlConnection(AppDbContext.ConnectionString);
//            db.Open();

//            User? user = db.Query<User>($"SELECT * FROM users WHERE Email=@username", new {username = username}).FirstOrDefault();

//            if (user != null && password == user.Password) // сравнивыать хеш пароли
//            {
//                user.AccessToken = GenerateAccessToken(user.Id);


//                // некорректный запрос
//                //try
//                //{
//                //    db.Execute("update user set AccessToken = @AccessToken where Id = @Id",
//                //                new { Id = user.Id, AccessToken = user.AccessToken });
//                //}catch (Exception ex)
//                //{
//                //    return "это эксепшен"; // ???? подумать
//                //}


//                return user.AccessToken;
//            }            

//            return "это конец";
//        }     

//        private string GenerateAccessToken(int id)
//        {
//            return "Token test";
//        }




//    }
//}
