 
using KTSF.Core.App;
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

        private PaymentMethod[] GetPaymentMethodsDefault()
        {
            return [
                new PaymentMethod() { Id = 1, Name = "Нет", },
                new PaymentMethod() { Id = 2, Name = "Наличные", },
                new PaymentMethod() { Id = 3, Name = "Карта", },
                new PaymentMethod() { Id = 4, Name = "Смешанный", },
            ];
        }

        private PaymentInfo[] GetPaymentInfosDefault()
        {
            PaymentMethod[] PaymentMethods = GetPaymentMethodsDefault();
            return [
                new PaymentInfo()
                {
                    Id = 1,
                    TotalSum = 2859.0,
                    CashAmount = 0,
                    CardAmount = 2859.0,
                    AmountPaid = 2859.0,
                    PaymentMethodId = 3
                },
                new PaymentInfo()
                {
                    Id = 2,
                    TotalSum = 176268.0,
                    CashAmount = 100000,
                    CardAmount = 76268,
                    AmountPaid = 176268.0,
                    PaymentMethodId = 4
                },
                new PaymentInfo()
                {
                    Id = 3,
                    TotalSum = 36500,
                    CashAmount = 36500,
                    CardAmount = 0,
                    AmountPaid = 36500,
                    PaymentMethodId = 2
                },
                new PaymentInfo()
                {
                    Id = 4,
                    TotalSum = 6490.0,
                    CashAmount = 0,
                    CardAmount = 6490.0,
                    AmountPaid = 6490.0,
                    PaymentMethodId = 3
                }];
        }

        private Receipt[] GetReceiptsDefault()
        {
            PaymentInfo[] PaymentInfos = GetPaymentInfosDefault();
            return [
                new Receipt()
                {
                    Id = 1,
                    Discount = 0,
                    CreatedDate = DateTime.Now,
                    PaymentInfoId = 1,
                },
                new Receipt()
                {
                    Id = 2,
                    Discount = 0,
                    CreatedDate = DateTime.Now,
                    PaymentInfoId = 2,
                },
                new Receipt()
                {
                    Id = 3,
                    Discount = 0,
                    CreatedDate = DateTime.Now,
                    PaymentInfoId = 3,
                },
                new Receipt()
                {
                    Id = 4,
                    Discount = 0,
                    CreatedDate = DateTime.Now,
                    PaymentInfoId = 4,
                }];
        }

        private BuyProduct[] GetBuyProductsDefault()
        {

            return [
                new BuyProduct()
                {
                    Id = 1,
                    Price = 450.0,
                    Count = 1,
                    TotalSumProduct = 450.0,
                    Discount = 0,
                    ProductId = 1,
                    ReceiptId = 1
                },
                new BuyProduct()
                {
                    Id = 2,
                    Price = 2409.0,
                    Count = 1,
                    TotalSumProduct = 2409.0,
                    Discount = 0,
                    ProductId = 2,
                    ReceiptId = 1
                },
                new BuyProduct()
                {
                    Id = 3,
                    Price = 176268.0,
                    Count = 1,
                    TotalSumProduct = 176268.0,
                    Discount = 0,
                    ProductId = 6,
                    ReceiptId = 2
                },
                new BuyProduct()
                {
                    Id = 4,
                    Price = 25800.0,
                    Count = 1,
                    TotalSumProduct = 25800.0,
                    Discount = 0,
                    ProductId = 16,
                    ReceiptId = 3
                },
                new BuyProduct()
                {
                    Id = 5,
                    Price = 10700.0,
                    Count = 1,
                    TotalSumProduct = 10700.0,
                    Discount = 0,
                    ProductId = 17,
                    ReceiptId = 3
                },
                new BuyProduct()
                {
                    Id = 6,
                    Price = 6490.0,
                    Count = 1,
                    TotalSumProduct = 6490.0,
                    Discount = 0,
                    ProductId = 22,
                    ReceiptId = 4
                }];
        }

    }
}
