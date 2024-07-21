using CRST_ServerAPI.Model;
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
    public enum ActionDatabase { Delete, Read,}

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
 

        private string GetTableName(Type type)
        {
            foreach (var attrib in Attribute.GetCustomAttributes(type))
            {
                if (attrib.GetType().Name == "Table")
                {
                    return attrib.GetType().FullName;
                }
            }
            throw new Exception("Not attribute `Table`");
        }




        public override T? Find<T>(int id) where T : default
        {
            using (IDbConnection db = new MySqlConnection(" "))
            {
                return db.Query<T>($"SELECT * FROM {TableName} WHERE ID={id}").FirstOrDefault();
            }
        }


        [ABAC("", "", 1, 1)]
        public override void Delete<T>(int id)
        {

            string accessToken = GenerateAccessToken();

            //Сделать запрос в базу и посмотреть есть ли такой токен в таблице доступа
            if (true)
            {

            }

            using (IDbConnection db = new MySqlConnection(AppDbContext.ConnectionString))
            {
                db.Query<T>($"DELETE FROM {TableName} WHERE ID={id}");
            }
        }

        private string GenerateAccessToken()
        {
            //Получить аттрибут
            //Получить текущего пользователя
            //Вернуть токен
            return "";
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
