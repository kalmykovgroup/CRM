
using Azure.Core;
using Dapper;
using KTSFClassLibrary;
using KTSFClassLibrary.ABAC;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Exchange.WebServices.Data;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using MySql.Data.MySqlClient;
using System.Data;

namespace CRST_ServerAPI.Data.Repositories
{
    public class EmployeeRepository : Repository
    {  
        public override Type ClassType => typeof(Employee);


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
                string sqlQuery = $@"INSERT INTO employees (    
                                        ObjectId, 
                                        AppointmentId,
                                        ASetOfRulesId,
                                        EmployeeStatusId,
                                        AccessToken,
                                        Name,
                                        Surname,
                                        Patronymic,
                                        PassportSeries,
                                        PassportNumber,
                                        Tin,
                                        Snils,
                                        Address,
                                        Phone,
                                        Email,
                                        ApplyingDate,
                                        Created_At,
                                        Updated_At,
                                        Password
                                    ) VALUES (
                                        @ObjectId, 
                                        @AppointmentId, 
                                        @ASetOfRulesId, 
                                        @EmployeeStatusId, 
                                        @AccessToken, 
                                        @Name, 
                                        @Surname, 
                                        @Patronymic, 
                                        @PassportSeries, 
                                        @PassportNumber, 
                                        @Tin, 
                                        @Snils, 
                                        @Address, 
                                        @Phone, 
                                        @Email, 
                                        @ApplyingDate, 
                                        @Created_At, 
                                        @Updated_At,
                                        @Password
                                        )";

                // ???? переменная нужна???
                int userId = db.ExecuteScalar<int>(sqlQuery, value);

                transaction.Commit();                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                transaction.Rollback();
            }

            return value;
        }

        public override T Update<T>(T value)
        {
            using IDbConnection db = new MySqlConnection(AppDbContext.ConnectionString);
            db.Open();

            Employee? employee = value as Employee;
            // проверка на NULL

            using var transaction = db.BeginTransaction();

            try
            {    
                string slqQuery = $@"UPDATE employees SET 
                                        ObjectId = @ObjectId, 
                                        AppointmentId = @AppointmentId, 
                                        ASetOfRulesId = @ASetOfRulesId, 
                                        EmployeeStatusId = @EmployeeStatusId, 
                                        AccessToken = @AccessToken , 
                                        Name = @Name, 
                                        Surname = @Surname, 
                                        Patronymic = @Patronymic, 
                                        PassportSeries = @PassportSeries, 
                                        PassportNumber = @PassportNumber, 
                                        Tin = @Tin, 
                                        Snils = @Snils, 
                                        Address = @Address, 
                                        Phone = @Phone, 
                                        Email = @Email, 
                                        ApplyingDate = @ApplyingDate, 
                                        Created_At =  @Created_At, 
                                        Updated_At = @Updated_At, 
                                        Password = @Password , 
                                        LayoffDate = @LayoffDate 
                                    WHERE Id = @Id
                ";                               

                db.ExecuteScalar(slqQuery, new {
                    ObjectId = employee.ObjectId,
                    AppointmentId = employee.AppointmentId,
                    ASetOfRulesId = employee.ASetOfRulesId,
                    EmployeeStatusId = employee.EmployeeStatusId,
                    AccessToken = employee.AccessToken  ,
                    Name = employee.Name,
                    Surname = employee.Surname,
                    Patronymic = employee.Patronymic,
                    PassportSeries = employee.PassportSeries,
                    PassportNumber = employee.PassportNumber,
                    Tin = employee.Tin,
                    Snils = employee.Snils,
                    Address = employee.Address,
                    Phone = employee.Phone,
                    Email = employee.Email,
                    ApplyingDate = employee.ApplyingDate,
                    Created_At = employee.Created_At,
                    Updated_At = employee.Updated_At,
                    Password = employee.Password,
                    LayoffDate = employee.LayoffDate,
                    Id = employee.Id
                });
                
                transaction.Commit();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                transaction.Rollback();
            }

            return value;
        }
    }
}
