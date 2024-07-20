using Dapper;
using KTSFClassLibrary;
using KTSFClassLibrary.ABAC;
using Microsoft.Data.SqlClient; 
using MySql.Data.MySqlClient;
using NuGet.Protocol.Core.Types;
using System.Configuration;
using System.Data;

namespace CRST_ServerAPI.Data
{


    public class UserRepository : Repository
    {
        public override string TableName { get; } = "users";

        public string InsertQueryString { get{ 
            
                return $@"insert into {TableName}
                    (id, object_id, barcode, name, surname, patronymic)
                    values
                    @{nameof(Employee.Id)}, 
                    @{nameof(Employee.ObjectId)},  
                    @{nameof(Employee.Name)}, 
                    @{nameof(Employee.Surname)}, 
                    @{nameof(Employee.Patronymic)}, 
                    returning id";

            } }

        public   string UpdateQueryString { get {
            return $@"insert into {TableName}
                    (id, object_id, barcode, name, surname, patronymic)
                    values
                    @{nameof(Employee.Id)}, 
                    @{nameof(Employee.ObjectId)},  
                    @{nameof(Employee.Name)}, 
                    @{nameof(Employee.Surname)}, 
                    @{nameof(Employee.Patronymic)}, 
                    returning id";
            } }

       
      

        public override T? Find<T>(int id) where T : default
        {
            using (IDbConnection db = new MySqlConnection(" "))
            {
                return db.Query<T>($"SELECT * FROM {TableName} WHERE ID={id}").FirstOrDefault();
            }
        }


       
        public override void Delete<T>(int id)
        {
          


            using (IDbConnection db = new MySqlConnection(AppDbContext.ConnectionString))
            {
                db.Query<T>($"DELETE FROM {TableName} WHERE ID={id}");
            }
        }

        public override List<T> GetAll<T>()
        {
            
            using (IDbConnection db = new MySqlConnection(AppDbContext.ConnectionString))
            {
                return db.Query<T>($"SELECT * FROM {TableName}").ToList();
            }
           
        }



        public override void Create<T>(T value)
        {
            throw new NotImplementedException();
        }

        public override void Update<T>(T value)
        {

            throw new NotImplementedException();
        }
 
    }
}
