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
        void Create(Employee employee);
        void Delete(int id);
        Employee Get(int id);
        List<Employee> GetEmployees();
        void Update(Employee employee);
    }

    public class UserRepository : IUserRepository
    { 
 

        private static string tablename = "users";
         

        private static readonly string _insertQuery = $@"insert into {tablename}
                    (id, object_id, barcode, name, surname, patronymic)
                    values
                    @{nameof(Employee.Id)}, 
                    @{nameof(Employee.ObjectId)},  
                    @{nameof(Employee.Name)}, 
                    @{nameof(Employee.Surname)}, 
                    @{nameof(Employee.Patronymic)}, 
                    returning id";

       


        public List<Employee> GetEmployees()
        {
            using (IDbConnection db = new MySqlConnection(AppDbContext.ConnectionString))
            {
               return db.Query<Employee>($"SELECT * FROM {tablename}").ToList();
             
            }
        }

        public void Create(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Employee Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee employee)
        {
            throw new NotImplementedException();
        }
         
    }
}
