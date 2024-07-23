using Dapper;
using KTSFClassLibrary;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MySql.Data.MySqlClient;
using System.Data;

namespace CRST_ServerAPI.Data
{
    public abstract class Repository : IRepository
    {
        public abstract string TableName { get; } 

        public abstract void Delete<T>(int id);

        public abstract List<T> GetAll<T>();
        
        public abstract T? Find<T>(int id);

        public abstract void Create<T>(T value);

        public abstract void Update<T>(T value);
         
    }
}
