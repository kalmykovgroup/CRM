
using KTSFClassLibrary;
using Microsoft.EntityFrameworkCore;

namespace CRST_ServerAPI.Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
       /* public Task<Microsoft.Exchange.WebServices.Data.ServiceResponse<string>> Login(string username, string password)
        {
            throw new NotImplementedException();
        }*/

      /*  public Task<Microsoft.Exchange.WebServices.Data.ServiceResponse<int>> Register(User user, string password)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            ServiceResponse<int> response = new ServiceResponse<int>();
            response.Data = user.Id;
            return response;
        }*/

        public Task<bool> UserExists(string username)
        {
            throw new NotImplementedException();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }


     
    }
}
