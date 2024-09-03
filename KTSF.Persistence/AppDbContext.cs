 
using KTSF.Core.App;
using KTSF.Core.Object.Receipt_;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Object = KTSF.Core.App.Object;

namespace KTSF.Persistence
{
    public class AppDbContext : DbContext
    {

        public static string ConnectionString { get; set; } = String.Empty;

        public DbSet<Object> Objects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }

        #region Product

        public AppDbContext()
        { 
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(GetUsersDefault());
            modelBuilder.Entity<Company>().HasData(GetCompaniesDefault());
            modelBuilder.Entity<Object>().HasData(GetObjectsDefault());
        }

        private User[] GetUsersDefault()
        {
            return [
                new User()
                {
                Id = 1,
                Email = "1@mail.ru",
                PhoneNumber = "+7111111111",
                PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword("1"),
                Name = "tester",
                Surname = "testerov",
                Patronymic = "testerovich",
                }];
        }

        private Company[] GetCompaniesDefault()
        {
            return [
                new Company()
                {
                    Id = 1,
                    UserId = 1,
                    Name = "My company name",
                    CompanyStatus = CompanyStatus.Active,
                },
            ];
        }

        private Object[] GetObjectsDefault()
        {  

            return [
                new Object()
                {
                    Id = 1,
                    CompanyId = 1,
                    ObjectStatus = ObjectStatus.Active,
                    Name = "Продуктовый на Арбате",
                    Address = "ул. Новый Арбат, 15",
                    DatabaseName = "111"
                }
            ];
        }


    }
}
