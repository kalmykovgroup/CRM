
using KTSF.Components.SignInPageComponent.Components.AuthFormComponent;
using KTSF.Core;
using KTSF.Core.ABAC;
using KTSF.Core.Product_;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KTSF.Db
{
    public class Server 
    {
        AppControl AppControl {  get; }

        public Server(AppControl appControl) { 
            AppControl = appControl;
        }

        public async Task<bool> Connect()
        {        
            await Task.Delay(0);

            return true;
        }

        //Делаем запрос при для проверки подключения к сети и получению необходимых данных из сервера
        public async Task<bool> LoadData()
        {
            await Task.Delay(0);

            return true;
        }

        #region Авторизация

        //Делаем запрос на авторизацию владельца
        //Возвращаем список доступным компаний, обьектов и список пользователей на этих обьектах

        public async Task<(bool result, string? error, User? user)> Authorization(string Phone, string password)
            {
                await Task.Delay(0);

                if (Phone == "+79260128187" && password == "tester")
                {
                    return (true, null, new User()
                    {
                        Email = "kalmykov@mail.ru",
                        Phone = "+79260128187",
                       // Password = "tester",
                        AccessToken = "test-user-access-token",
                        Name = "Иван",
                        Surname = "Калмыков",
                        Patronymic = "Алексеевич",
                    });
                }
                else
                {
                return (false, $"Логин или пароль не подходят {Phone}:{password}", null);
                }

            }
            public async Task<(bool result, string? error, User? user)> Authorization(string token)
            {
                await Task.Delay(0);

                bool result = true;

                if (result)
                {
                    return (true, null, new User()
                    {
                        Email = "kalmykov@mail.ru",
                        Phone = "+79260128187",
                      //  Password = "tester",
                        AccessToken = "test-user-access-token",
                        Name = "Иван",
                        Surname = "Калмыков",
                        Patronymic = "Алексеевич",
                    });
                }
                else
                {
                    return (false, "token не подходит", null);
                }

            }

           


        public async void Authentication(Action<string> GenerateBarCode, Action<Employee> SetEmployee)
        {
            await Task.Delay(0);


            GenerateBarCode?.Invoke("451VvcKdxp2DIUWArkaP5bPzlj6ZqmwE");

            await Task.Delay(0);

            Employee employee = new Employee()
            {
                ObjectId = 1,
                AppointmentId = 3,
                AccessToken = "test-employee-access-token",
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

            SetEmployee.Invoke(employee);

        }

        #endregion


       

        //Поиск товаров
        public async Task<List<Product>> SearchProducts(string text)
        {
            // Максимальное число поиска товаров не должно превышать 20 товаров
        
            await Task.Delay(1000);

            return new List<Product> {
                new Product() { Name = "Product 1", Id = 1, BuySales = 800 },
                new Product() { Name = "Product 2", Id = 2, BuySales = 750 },
                new Product() { Name = "Product 3", Id = 3, BuySales = 700 },
                new Product() { Name = "Product 4", Id = 4, BuySales = 300 },
                new Product() { Name = "Product 5", Id = 5, BuySales = 450 },
                new Product() { Name = "Product 6", Id = 6, BuySales = 880 },
                new Product() { Name = "Product 7", Id = 7, BuySales = 1000 },
                new Product() { Name = "Product 8", Id = 8, BuySales = 450 },
                new Product() { Name = "Product 9", Id = 9, BuySales = 200 },
                new Product() { Name = "Product 10", Id = 10, BuySales = 620 },
                new Product() { Name = "Product 11", Id = 11, BuySales = 780 },
                new Product() { Name = "Product 12", Id = 12, BuySales = 560 },
                new Product() { Name = "Product 13", Id = 13, BuySales = 780 },
                new Product() { Name = "Product 14", Id = 14, BuySales = 290 },
                new Product() { Name = "Product 15", Id = 15, BuySales = 970 },
                new Product() { Name = "Product 16", Id = 16, BuySales = 1210 },
                new Product() { Name = "Product 17", Id = 17, BuySales = 160 },
                new Product() { Name = "Product 18", Id = 18, BuySales = 850 },
                new Product() { Name = "Product 19", Id = 19, BuySales = 780 },
                new Product() { Name = "Product 20", Id = 20, BuySales = 640 },
            };
        }

        public async Task<(int countPages, List<Product> product)> GetProducts(int page = 1)
        {
            List<Product> products = new List<Product> {
                new Product() { Name = "Product 1", Id = 1 },
                new Product() { Name = "Product 2", Id = 2 },
                new Product() { Name = "Product 3", Id = 3 },
                new Product() { Name = "Product 4", Id = 4 },
                new Product() { Name = "Product 5", Id = 5 },
                new Product() { Name = "Product 6", Id = 6 },
                new Product() { Name = "Product 7", Id = 7 },
                new Product() { Name = "Product 8", Id = 8 },
                new Product() { Name = "Product 9", Id = 9 },
                new Product() { Name = "Product 10", Id = 10 },
                new Product() { Name = "Product 1", Id = 1 },
                new Product() { Name = "Product 2", Id = 2 },
                new Product() { Name = "Product 3", Id = 3 },
                new Product() { Name = "Product 4", Id = 4 },
                new Product() { Name = "Product 5", Id = 5 },
                new Product() { Name = "Product 6", Id = 6 },
                new Product() { Name = "Product 7", Id = 7 },
                new Product() { Name = "Product 8", Id = 8 },
                new Product() { Name = "Product 9", Id = 9 },
                new Product() { Name = "Product 10", Id = 10 },
                new Product() { Name = "Product 1", Id = 1 },
                new Product() { Name = "Product 2", Id = 2 },
                new Product() { Name = "Product 3", Id = 3 },
                new Product() { Name = "Product 4", Id = 4 },
                new Product() { Name = "Product 5", Id = 5 },
                new Product() { Name = "Product 6", Id = 6 },
                new Product() { Name = "Product 7", Id = 7 },
                new Product() { Name = "Product 8", Id = 8 },
                new Product() { Name = "Product 9", Id = 9 },
                new Product() { Name = "Product 10", Id = 10 },
                new Product() { Name = "Product 9", Id = 9 },
                new Product() { Name = "Product 10", Id = 10 },
                new Product() { Name = "Product 9", Id = 9 },
                new Product() { Name = "Product 10", Id = 10 },
                new Product() { Name = "Product 9", Id = 9 },
                new Product() { Name = "Product 10", Id = 10 },
                new Product() { Name = "Product 9", Id = 9 },
                new Product() { Name = "Product 10", Id = 10 },
                new Product() { Name = "Product 9", Id = 9 },
                new Product() { Name = "Product 10", Id = 10 },
                new Product() { Name = "Product 10", Id = 10 },
                new Product() { Name = "Product 9", Id = 9 },
                new Product() { Name = "Product 10", Id = 10 },
                new Product() { Name = "Product 9", Id = 9 },
                new Product() { Name = "Product 10", Id = 10 },
                new Product() { Name = "Product 10", Id = 10 },
                new Product() { Name = "Product 9", Id = 9 },
                new Product() { Name = "Product 10", Id = 10 },
                new Product() { Name = "Product 9", Id = 9 },
                new Product() { Name = "Product 10", Id = 10 },
                new Product() { Name = "Product 10", Id = 10 },
                new Product() { Name = "Product 9", Id = 9 },
                new Product() { Name = "Product 10", Id = 10 },
                new Product() { Name = "Product 9", Id = 9 },
                new Product() { Name = "Product 10", Id = 10 },
            };

            page--;

            int limmit = 3;

            int countPage = (int)Math.Ceiling((double)products.Count / limmit);

            if (page > countPage || page < 0) throw new ArgumentException();

            List<Product> resultProducts = [];

            for (int i = page * limmit; i < (page * limmit + limmit) && i < products.Count; i++) {
                resultProducts.Add(products[i]);
            }

            return (countPage, resultProducts);

        }
 


        //Получить списанные товары
        public async Task<List<Product>> GetDecommissionedProducts()
        { 
            await Task.Delay(1000);

            List<Product> result = new List<Product> {
                new Product() { Name = "Product 11", Id = 11 },
                new Product() { Name = "Product 12", Id = 12 },
                new Product() { Name = "Product 13", Id = 13 }, 
            };             

            return result;
        }

        //Получить подробную информацию о товаре
        public async Task<Product> GetProductFullInfo(int id)
        {
            await Task.Delay(1000);

            return new Product() { Name = "Product 12", Id = 12 };                
        }

      
 

        #region Employee

        public async Task<List<Employee>> GetEmployees() //Получить список всех сотрудников
        {
            await Task.Delay(0);

            return new List<Employee> {
                new Employee()
                {
                    ObjectId = 1,
                    AppointmentId = 1,
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

                },

                  new Employee()
                {
                    ObjectId = 1,
                    AppointmentId = 2,
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

                },
                new Employee()
                {
                    ObjectId = 1,
                    AppointmentId = 3,
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

                }
            };
        }
     

        //Нужно определить где будет отслеживатся информация о том каие поля мы меняем
        public async Task<(bool result, string? message, Employee copyEmployee)> UpdateEmployee(Employee employee)
        {
            await Task.Delay(0);

            return (result: true, message: null, employee);
        }

        

        public async Task<bool> GetUserStatistics(Employee user) //Загрузка статистических данных о пользователи
        {
            await Task.Delay(1000);

            return true;
        }

        #endregion





    }
}
