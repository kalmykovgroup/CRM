using Azure.Core;
using CRST_ServerAPI.Model;
using Dapper;
using KTSFClassLibrary;
using KTSFClassLibrary.ABAC;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
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


        public override T Create<T>(T value)
        {
            using IDbConnection db = new MySqlConnection(AppDbContext.ConnectionString);
            db.Open();

            using var transaction = db.BeginTransaction();

            try
            {
                string query = $@"INSERT INTO users (
                                    Email,
                                    Phone,
                                    Password,
                                    PasswordHash,
                                    PasswordSalt,
                                    AccessToken,
                                    Name,
                                    Surname,
                                    Patronymic
                                ) VALUES (
                                    @Email,
                                    @Phone,
                                    @Password,
                                    @PasswordHash,
                                    @PasswordSalt,
                                    @AccessToken,
                                    @Name,
                                    @Surname,
                                    @Patronymic
                                  )";

                int inserted =  db.Execute(query, value);

                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                transaction.Rollback();
            }

            return value;
        }


        public override T Update<T>(T value) // в параметрах JSON ??? 
        {
            using IDbConnection db = new MySqlConnection(AppDbContext.ConnectionString);
            db.Open();

            using var transaction = db.BeginTransaction();
            
            User? user = value as User;

            if (user != null)
            {
                try
                {
                    string query = $@"UPDATE users SET 
                                        Email = @Email, 
                                        Phone = @Phone, 
                                        Password = @Password, 
                                        PasswordHash = @PasswordHash, 
                                        PasswordSalt = @PasswordSalt, 
                                        AccessToken = @AccessToken, 
                                        Name = @Name, 
                                        Surname = @Surname, 
                                        Patronymic = @Patronymic 
                                    WHERE Id = @Id
                    ";

                    int updated = db.Execute(query, new { 
                                    Email = user.Email, 
                                    Phone = user.Phone, 
                                    Password = user.Password,
                                    PasswordHash = user.PasswordHash,
                                    PasswordSalt = user.PasswordSalt, 
                                    AccessToken = user.AccessToken,
                                    Name = user.Name,
                                    Surname = user.Surname, 
                                    Patronymic = user.Patronymic, 
                                    Id = user.Id });

                    transaction.Commit();


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    transaction.Rollback();
                }
            }

            return value;
        }

 


    }
}
