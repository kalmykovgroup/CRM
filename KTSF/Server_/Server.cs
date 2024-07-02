
using KTSFClassLibrary;
using KTSFClassLibrary.Product_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Server_
{
    public class Server 
    {
        AppControl AppControl {  get; }

        public Server(AppControl appControl) { 
            AppControl = appControl;
        }



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
