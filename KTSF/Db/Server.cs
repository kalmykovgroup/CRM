
using KTSFClassLibrary;
using KTSFClassLibrary.Product_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<(bool result, string? error, MainUser mainUser)> Authorization(MainUser mainUser)
        {
            await Task.Delay(0);

            if (true)
            {
                return (true, null, new MainUser()
                {
                    Username = "Tester",
                    Password = "Tester",
                    Email = "Admin@mail.ru",
                    Name = "Name",
                    Surname = "Surname",
                    Patronimyc = "Patronimyc"
                });
            }
            else
            {
                return (false, "Логин или пароль не подходят", mainUser);
            }

           
        }

        public async Task<bool> LoadData()
        {        
            await Task.Delay(0);

            return true;
        }


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
        
        public async Task<List<User>> GetUsers() //Получить список всех пользователей
        {
            await Task.Delay(1000);

            return new List<User> {
                new User() { Name = "Кассир 1", Id = 1 },
                new User() { Name = "Кассир 2", Id = 2 },
                new User() { Name = "Кассир 3", Id = 3 },
            };

        }

        //Нужно определить где будет отслеживатся информация о том каие поля мы меняем
        public async Task<(bool result, string? message)> UpdateUser(User user)
        {
            await Task.Delay(1000);

            return (result: true, message: null);
        }

        //По факту пользователь станет не активным
        public async Task<(bool result, string? message)> DeleteUser(User user)
        {
            await Task.Delay(1000); 

            return (result: true, message: null);
        }

        public async Task<bool> GetUserStatistics(User user) //Загрузка статистических данных о пользователи
        {
            await Task.Delay(1000);

            return true;
        }


        #endregion



    }
}
