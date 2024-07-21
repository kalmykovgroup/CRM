﻿
using KTSF.Components.SignInPageComponent.Components.AuthFormComponent;
using KTSFClassLibrary;
using KTSFClassLibrary.Product_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

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
                        Email = "Admin@mail.ru",
                        Name = "Name",
                        Surname = "Surname",
                        Patronymic = "Patronymic",
                        AccessToken = "+79260128187"
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

                if (token == "+79260128187")
                {
                    return (true, null, new User()
                    { 
                        Email = "Admin@mail.ru",
                        Phone = "+79260128187",
                        Name = "Name",
                        Surname = "Surname",
                        Patronymic = "Patronymic",
                        AccessToken = "tester"
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
                Name = "Name",
                Surname = "Surname",
                Patronymic = "Patronymic"
            };

            SetEmployee.Invoke(employee);

        }

        #endregion


       

        //Поиск товаров
        public async Task<List<Product>> SearchProducts(string text)
        {
            await Task.Delay(1000);

            return new List<Product> {
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
            };
        }

        //Получить страницу с товарами
        public async Task<List<Product>> GetProducts(int offset, int count)
        { 
            await Task.Delay(1000);

            List <Product> result =  new List<Product> {
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
            }; 

            return result;
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

        #region User
        
        public async Task<List<Employee>> GetUsers() //Получить список всех пользователей
        {
            await Task.Delay(0);            

            return new List<User> {
                new User() { Id = 1 , Name = "Иван" , Surname = "Иванов", 
                             Patronymic = "Иванович", PassportSeries = "1111", PassportNumber = "123456",
                             InnNumber = "0123456789012", Snils = "123-456-789-00", Position = "Кассир",
                             Address = "г.Москва, ул.Тверская..." , PhoneNumber = "8(925)123-45-67",
                             Email = "ivanov@mail.ru", ApplyingDate = new DateTime(2024, 02, 01),
                             IsFired = false},
                new User() { Id = 1 , Name = "Петр" , Surname = "Петров",
                             Patronymic = "Петрович", PassportSeries = "2222", PassportNumber = "123456",
                             InnNumber = "3123456789012", Snils = "123-456-789-55", Position = "Директор",
                             Address = "г.Москва, ул.Болотная..." , PhoneNumber = "8(985)987-65-43",
                             Email = "petrov@mail.ru", ApplyingDate = new DateTime(2024, 02, 01),
                             IsFired = false},
               new User() { Id = 1 , Name = "Федор" , Surname = "Федоров",
                             Patronymic = "Федорович", PassportSeries = "3333", PassportNumber = "123456",
                             InnNumber = "6123456789012", Snils = "123-456-789-99", Position = "Управляющий",
                             Address = "г.Москва, ул.Абрикововая..." , PhoneNumber = "8(919)444-55-66",
                             Email = "fedorov@mail.ru", ApplyingDate = new DateTime(2024, 02, 01),
                             IsFired = false},
            };
        }

        public async Task<List<User>> GetFiredUsers() //Получить список всех пользователей
        {
            await Task.Delay(0);

            return new List<User> {
                new User() { Id = 1 , Name = "Ольга" , Surname = "Ольгова",
                             Patronymic = "Ольговна", PassportSeries = "1111", PassportNumber = "123456",
                             InnNumber = "0123456789012", Snils = "123-456-789-00", Position = "Кассир",
                             Address = "г.Москва, ул.Тверская..." , PhoneNumber = "8(925)123-45-67",
                             Email = "ivanov@mail.ru", ApplyingDate = new DateTime(2024, 02, 01),
                             IsFired = true, LayoffDate = new DateTime(2024, 07, 08)},
                new User() { Id = 1 , Name = "Зинаида" , Surname = "Зинаидова",
                             Patronymic = "Зинаидовна", PassportSeries = "2222", PassportNumber = "123456",
                             InnNumber = "3123456789012", Snils = "123-456-789-55", Position = "Кассир",
                             Address = "г.Москва, ул.Болотная..." , PhoneNumber = "8(985)987-65-43",
                             Email = "petrov@mail.ru", ApplyingDate = new DateTime(2024, 02, 01),
                             IsFired = true, LayoffDate = new DateTime(2024, 07, 08)},
               new User() { Id = 1 , Name = "Екатерина" , Surname = "Екатеринова",
                             Patronymic = "Екатериновна", PassportSeries = "3333", PassportNumber = "123456",
                             InnNumber = "6123456789012", Snils = "123-456-789-99", Position = "Управляющий",
                             Address = "г.Москва, ул.Абрикововая..." , PhoneNumber = "8(919)444-55-66",
                             Email = "fedorov@mail.ru", ApplyingDate = new DateTime(2024, 02, 01),
                             IsFired = false, LayoffDate = new DateTime(2024, 07, 08)},
            };
        }

        //Нужно определить где будет отслеживатся информация о том каие поля мы меняем
        public async Task<(bool result, string? message)> UpdateUser(Employee user)
        {
            await Task.Delay(1000);

            return (result: true, message: null);
        }

        //По факту пользователь станет не активным
        public async Task<(bool result, string? message)> DeleteUser(Employee user)
        {
            await Task.Delay(1000); 

            return (result: true, message: null);
        }

        public async Task<bool> GetUserStatistics(Employee user) //Загрузка статистических данных о пользователи
        {
            await Task.Delay(1000);

            return true;
        }


        #endregion



    }
}
