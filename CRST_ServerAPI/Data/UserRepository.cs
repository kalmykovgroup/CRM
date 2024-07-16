using Dapper;
using KTSFClassLibrary;
using KTSFClassLibrary.ABAC;
using Microsoft.Data.SqlClient; 
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace CRST_ServerAPI.Data
{
    public interface IUserRepository
    {
        void Create(User user);
        void Delete(int id);
        User Get(int id);
        List<User> GetUsers();
        void Update(User user);
    }

    public class UserRepository : IUserRepository
    { 
 

        private static string tableName = "users";
         

        private static readonly string _insertQuery = $@"insert into {tableName}
                    (id, object_id, barcode, name, surname, patronymic)
                    values
                    @{nameof(User.Id)}, 
                    @{nameof(User.ObjectId)}, 
                    @{nameof(User.Barcode)}, 
                    @{nameof(User.Name)}, 
                    @{nameof(User.Surname)}, 
                    @{nameof(User.Patronymic)}, 
                    returning id";

       


        public List<User> GetUsers()
        {
            using (IDbConnection db = new MySqlConnection(AppDbContext.ConnectionString))
            {
               return db.Query<User>($"SELECT * FROM {tableName}").ToList();
             
            }
        }

        public void Create(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
         
    }
}
