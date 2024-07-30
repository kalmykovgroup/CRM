using CRST_ServerAPI.Model;
using Dapper;
using KTSFClassLibrary;
using KTSFClassLibrary.ABAC;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using NuGet.Protocol.Core.Types;
using System;
using System.Configuration;
using System.Data;

namespace CRST_ServerAPI.Data.Repositories
{
    public enum ActionDatabase { Delete, Read, }

    public class UserRepository : Repository
    {
        public override Type ClassType => typeof(User);

        public override T? Find<T>(int id) where T : default
        {
            return base.Find<T>(id);
        }

     

        public override List<T> GetAll<T>()
        {

            return base.GetAll<T>();

        }

      



        public override void Create<T>(T value)
        {
            using IDbConnection db = new MySqlConnection(AppDbContext.ConnectionString);

            db.Open();

            using var tran = db.BeginTransaction();

            try
            {


                tran.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                tran.Rollback();
            }
        }

        public override void Update<T>(T value)
        {
            using IDbConnection db = new MySqlConnection(AppDbContext.ConnectionString);

            db.Open();

            using var tran = db.BeginTransaction();

            try
            {
                

                tran.Commit();

               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                tran.Rollback();
            }
        }

 


    }
}
