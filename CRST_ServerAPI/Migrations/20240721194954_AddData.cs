using CRST_ServerAPI.Data;
using KTSFClassLibrary;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using Dapper;
using Object = KTSFClassLibrary.Object;

#nullable disable

namespace CRST_ServerAPI.Migrations
{
/// <inheritdoc />
public partial class AddData : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        using IDbConnection db = new MySqlConnection(AppDbContext.ConnectionString);

        db.Open();

        using var tran = db.BeginTransaction();

        try
        {


            User user = new User()
            {
                Email = "kalmykov@mail.ru",
                Phone = "+79260128187",
                Password = "tester",
                AccessToken = "bgUYGBvkuybjkyGJGVjhyvbjyuBKYJ",
                Name = "Ivan",
                Surname = "Kalmykov",
                Patronymic = "Alexeevich",
            };

            string sqlQuery = $@"insert into {GetTableName(typeof(User))}
               ({nameof(User.Email)}, 
                {nameof(User.Phone)},  
                {nameof(User.Password)}, 
                {nameof(User.AccessToken)}, 
                {nameof(User.Name)}, 
                {nameof(User.Surname)}, 
                {nameof(User.Patronymic)})
               values (
               @{nameof(User.Email)}, 
               @{nameof(User.Phone)},  
               @{nameof(User.Password)}, 
               @{nameof(User.AccessToken)}, 
               @{nameof(User.Name)}, 
               @{nameof(User.Surname)}, 
               @{nameof(User.Patronymic)}); select LAST_INSERT_ID();";


            int userId = db.ExecuteScalar<int>(sqlQuery, user);



            sqlQuery = $@"insert into {GetTableName(typeof(Company))}
               ({nameof(Company.UserId)}, 
                {nameof(Company.Name)})
               values(
               @{nameof(Company.UserId)}, 
               @{nameof(Company.Name)}); select LAST_INSERT_ID();";


            int companyId = db.ExecuteScalar<int>(sqlQuery, new Company() { Name = "Kalmykov Group", UserId = userId });



            sqlQuery = $@"insert into {GetTableName(typeof(Object))}
               ({nameof(Object.CompanyId)}, 
                {nameof(Object.Address)},
                {nameof(Object.Name)})
               values (
                @{nameof(Object.CompanyId)}, 
                @{nameof(Object.Address)},
                @{nameof(Object.Name)}); select LAST_INSERT_ID();";

            int objectId = db.ExecuteScalar<int>(sqlQuery, new Object() { Name = "Продуктовый на Арбате", Address = "ул. Новый Арбат, 15", CompanyId = companyId });

            sqlQuery = $@"insert into {GetTableName(typeof(Appointment))}
               ({nameof(Appointment.Name)}, 
                {nameof(Appointment.Description)} )
               values(
                @{nameof(Appointment.Name)}, 
                @{nameof(Appointment.Description)}); select LAST_INSERT_ID();";

            int AppointmentId1 = db.ExecuteScalar<int>(sqlQuery, new Appointment() { Name = "Администратор", Description = "" });
            int AppointmentId2 = db.ExecuteScalar<int>(sqlQuery, new Appointment() { Name = "Старший кассир", Description = "" });
            int AppointmentId3 = db.ExecuteScalar<int>(sqlQuery, new Appointment() { Name = "Кассир", Description = "" });
            int AppointmentId4 = db.ExecuteScalar<int>(sqlQuery, new Appointment() { Name = "Кассир Евгений", Description = "Установленные дополнительные права доступа на изменение цены для товаров" });
            int AppointmentId5 = db.ExecuteScalar<int>(sqlQuery, new Appointment() { Name = "Бугалтер", Description = "" });

            sqlQuery = $@"insert into {GetTableName(typeof(Employee))} 
               ({nameof(Employee.ObjectId)}, 
                {nameof(Employee.AppointmentId)},
                {nameof(Employee.AccessToken)},
                {nameof(Employee.Name)},
                {nameof(Employee.Surname)},
                {nameof(Employee.Patronymic)},
                {nameof(Employee.PassportSeries)},
                {nameof(Employee.PassportNumber)},
                {nameof(Employee.Tin)},
                {nameof(Employee.Snils)},
                {nameof(Employee.Address)},
                {nameof(Employee.Phone)},
                {nameof(Employee.Email)},
                {nameof(Employee.ApplyingDate)},
                {nameof(Employee.Created_At)},
                {nameof(Employee.Updated_At)})
               values (
                @{nameof(Employee.ObjectId)}, 
                @{nameof(Employee.AppointmentId)}, 
                @{nameof(Employee.AccessToken)}, 
                @{nameof(Employee.Name)}, 
                @{nameof(Employee.Surname)}, 
                @{nameof(Employee.Patronymic)}, 
                @{nameof(Employee.PassportSeries)}, 
                @{nameof(Employee.PassportNumber)}, 
                @{nameof(Employee.Tin)}, 
                @{nameof(Employee.Snils)}, 
                @{nameof(Employee.Address)}, 
                @{nameof(Employee.Phone)}, 
                @{nameof(Employee.Email)}, 
                @{nameof(Employee.ApplyingDate)}, 
                @{nameof(Employee.Created_At)}, 
                @{nameof(Employee.Updated_At)})";

            Employee employee1 = new Employee()
            {
                ObjectId = objectId,
                AppointmentId = AppointmentId1,
                AccessToken = "lkvbmekjlgnwieufhwyueigf",
                Name = "Иван",
                Surname = "Калмыков",
                Patronymic = "Алексеевич",
                PassportSeries = "1234",
                PassportNumber = "123456",
                Tin = "12345678901",
                Snils = "123456789012",
                Address = "Красная прощать 4",
                Phone = "+79260128187",
                Email = "admin@mail.ru",
                ApplyingDate = DateTime.Now,
                Created_At = DateTime.Now,
                Updated_At = DateTime.Now,

            };

            db.Execute(sqlQuery, employee1);


            Employee employee2 = new Employee()
            {
                ObjectId = objectId,
                AppointmentId = AppointmentId2,
                AccessToken = "weifubsudyvbwirugniewrug",
                Name = "Артур",
                Surname = "Соколов",
                Patronymic = "Игоревич",
                PassportSeries = "1234",
                PassportNumber = "123456",
                Tin = "12345678901",
                Snils = "123456789012",
                Address = "Арбатская 6",
                Phone = "+79260125434",
                Email = "admin2@mail.ru",
                ApplyingDate = DateTime.Now,
                Created_At = DateTime.Now,
                Updated_At = DateTime.Now,

            };

            db.Execute(sqlQuery, employee2);

            Employee employee3 = new Employee()
            {
                ObjectId = objectId,
                AppointmentId = AppointmentId3,
                AccessToken = "aslkgfoiaerjglisermhl",
                Name = "Александр",
                Surname = "Трунин",
                Patronymic = "Владимирович",
                PassportSeries = "1234",
                PassportNumber = "123456",
                Tin = "12345678901",
                Snils = "123456789012",
                Address = "Шевченко 4",
                Phone = "+79267654356",
                Email = "admin3@mail.ru",
                ApplyingDate = DateTime.Now,
                Created_At = DateTime.Now,
                Updated_At = DateTime.Now,

            };

            db.Execute(sqlQuery, employee3);

            Employee employee4 = new Employee()
            {
                ObjectId = objectId,
                AppointmentId = AppointmentId4,
                AccessToken = "lvjerwkhnfwaeljkmg",
                Name = "Алексей",
                Surname = "Федосов",
                Patronymic = "Александрович",
                PassportSeries = "1234",
                PassportNumber = "123456",
                Tin = "12345678901",
                Snils = "123456789012",
                Address = "Ново Павловка 16/3",
                Phone = "+79266455553",
                Email = "admin4@mail.ru",
                ApplyingDate = DateTime.Now,
                Created_At = DateTime.Now,
                Updated_At = DateTime.Now,

            };

            db.Execute(sqlQuery, employee4);


            Employee employee5 = new Employee()
            {
                ObjectId = objectId,
                AppointmentId = AppointmentId5,
                AccessToken = "jkhsabefkwiauenfgoauiwjrf",
                Name = "Ансар",
                Surname = "Агадуллин",
                Patronymic = "Нуруллович",
                PassportSeries = "1234",
                PassportNumber = "123456",
                Tin = "12345678901",
                Snils = "123456789012",
                Address = "Дальний восток 13/3",
                Phone = "+79266726545",
                Email = "admin5@mail.ru",
                ApplyingDate = DateTime.Now,
                Created_At = DateTime.Now,
                Updated_At = DateTime.Now,

            };

            db.Execute(sqlQuery, employee5);

            tran.Commit();

        }
        catch
        {
            tran.Rollback();
        }



    }

    private string GetTableName(Type type)
    {
        foreach (Attribute attribute in Attribute.GetCustomAttributes(type))
        {
            if (attribute is TableAttribute tableAttribute)
            {
                return tableAttribute.Name;
            }
        }
        throw new Exception("Not table attribute");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {

    }
}
}

     