using Dapper;
using KTSFClassLibrary;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CRST_ServerAPI.Data
{
    public abstract class Repository : IRepository
    {
        public abstract Type ClassType { get; }

        public virtual string TableName { get; }

        public Repository()
        {
            TableName = GetTableName(ClassType);
        }

        public virtual T? Find<T>(int id) 
        {
            using (IDbConnection db = new MySqlConnection(AppDbContext.ConnectionString))
            {
                return db.Query<T>($"SELECT * FROM {TableName} WHERE ID={id}").FirstOrDefault();
            }
        }


        public virtual List<T> GetAll<T>()
        {

            using (IDbConnection db = new MySqlConnection(AppDbContext.ConnectionString))
            {
                return db.Query<T>($"SELECT * FROM {TableName}").ToList();
            }

        }

        public abstract void Create<T>(T value);

        public abstract void Update<T>(T value);


        private string GetTableName(System.Type type)
        {
            foreach (Attribute attribute in Attribute.GetCustomAttributes(type))
            {
                if (attribute is TableAttribute tableAttribute)
                {
                    return tableAttribute.Name;
                }
            }
            Console.WriteLine(type);
            throw new Exception("Not table attribute");
        }

        private string GenerateAccessToken()
        {
            //Получить аттрибут
            //Получить текущего пользователя
            //Вернуть токен
            return "";
        }

    }
}
