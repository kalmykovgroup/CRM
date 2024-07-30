
using Dapper;
using KTSFClassLibrary;
using Microsoft.AspNetCore.Mvc;
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

      
        public Employee Create()
        {
            Employee employee = new Employee()
            {
                ObjectId = 1,
                AppointmentId = 4,
                ASetOfRulesId = 4,
                AccessToken = "lkvbmekjlgnwieufhwyueigf",
                Name = "QQQQ",
                Surname = "WWWW",
                Patronymic = "EEEE",
                PassportSeries = "1234",
                PassportNumber = "123456",
                Tin = "999999999999",
                Snils = "5555555555555",
                Address = "Красная прощать 4",
                Phone = "+79260128187",
                Email = "aaa@aaa.ru",
                ApplyingDate = DateTime.Now,
                Created_At = DateTime.Now,
                Updated_At = DateTime.Now,
                EmployeeStatusId = 2

            };

            //using IDbConnection db = new MySqlConnection(AppDbContext.ConnectionString);
            //db.Open();

            //int inserted = db.Execute(_insertQuery, new Employee()
            //{
            //    employee.ObjectId,
            //    employee.AppointmentId,
            //    employee.ASetOfRulesId,
            //    employee.AccessToken,
            //    employee.Name,
            //    employee.Surname,
            //    employee.Patronymic,
            //    employee.PassportSeries,
            //    employee.PassportNumber,
            //    employee.Tin,
            //    employee.Snils,
            //    employee.Address,
            //    employee.Phone,
            //    employee.Email,
            //    employee.ApplyingDate,
            //    employee.Created_At,
            //    employee.Updated_At,
            //    employee.EmployeeStatusId,
            //});


            using IDbConnection db = new MySqlConnection(AppDbContext.ConnectionString);
            db.Open();

            string sqlQuery = $@"insert into employees 
               ({nameof(employee.ObjectId)}, 
                {nameof(employee.AppointmentId)},
                {nameof(employee.ASetOfRulesId)},
                {nameof(employee.EmployeeStatusId)},
                {nameof(employee.AccessToken)},
                {nameof(employee.Name)},
                {nameof(employee.Surname)},
                {nameof(employee.Patronymic)},
                {nameof(employee.PassportSeries)},
                {nameof(employee.PassportNumber)},
                {nameof(employee.Tin)},
                {nameof(employee.Snils)},
                {nameof(employee.Address)},
                {nameof(employee.Phone)},
                {nameof(employee.Email)},
                {nameof(employee.ApplyingDate)},
                {nameof(employee.Created_At)},
                {nameof(employee.Updated_At)})
               values (
                @{nameof(employee.ObjectId)}, 
                @{nameof(employee.AppointmentId)}, 
                @{nameof(employee.ASetOfRulesId)}, 
                @{nameof(employee.EmployeeStatusId)}, 
                @{nameof(employee.AccessToken)}, 
                @{nameof(employee.Name)}, 
                @{nameof(employee.Surname)}, 
                @{nameof(employee.Patronymic)}, 
                @{nameof(employee.PassportSeries)}, 
                @{nameof(employee.PassportNumber)}, 
                @{nameof(employee.Tin)}, 
                @{nameof(employee.Snils)}, 
                @{nameof(employee.Address)}, 
                @{nameof(employee.Phone)}, 
                @{nameof(employee.Email)}, 
                @{nameof(employee.ApplyingDate)}, 
                @{nameof(employee.Created_At)}, 
                @{nameof(employee.Updated_At)})";


            int userId = db.ExecuteScalar<int>(sqlQuery, employee);

            return employee;
        }

    }
}
