
using KTSF.Components.SignInPageComponent.Components.AuthFormComponent;
using KTSF.Core;
using KTSF.Core.ABAC;
using KTSF.Core.Product_;
using KTSF.Dto.Product_;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KTSF.Db
{
    public class Server 
    {
        AppControl AppControl {  get; }

        public static HttpClient httpClient = new()
        {
            BaseAddress = new Uri("https://localhost:7286")
        };


        public static JsonSerializerOptions options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            //Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic ),
            WriteIndented = true
        };

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



        private async Task<T?> Request<T>(string url) where T : class
        {
            try
            {
                T? products = await httpClient.GetFromJsonAsync<T>(url);
                return products;
            }
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode == HttpStatusCode.Unauthorized)
                {                   
                    // обработка не авторизованных 
                }
                else
                {
                    MessageBox.Show("The server is not responding");                    
                }
            }
            return null;
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


        #region Product

        //Поиск товаров
        public async Task<List<Product>?> SearchProducts(string text) // возвращает максимум 20 товаров
        {
            /*
            using HttpResponseMessage response = await httpClient.GetAsync($"Product/SearchProduct?name={text}");

            if(response.StatusCode == HttpStatusCode.OK)
            {
                List<Product>? products = await httpClient.GetFromJsonAsync<List<Product>>($"Product/SearchProduct?name={text}");

                return products;
            }

            return null;
            */

            List<Product>? products = await Request<List<Product>>($"Product/SearchProduct?name={text}");
            return products;
        }

        public async Task<List<Product>?> GetProducts(int page)
        {
            /*
            try
            {
                products = await httpClient.GetFromJsonAsync<List<Product>>($"Product/GetProducts?page={page}");
                return products;
            }
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode == HttpStatusCode.Unauthorized)
                {
                    // обработка не авторизованных 
                }
                else
                {
                    // обработка серверных ошибок
                }
            }
            */

            List<Product>? products = await Request<List<Product>>($"Product/GetProducts?page={page}");
            return products;          
        }

        // первая страница продуктов и общее количество продуктов
        public async Task<FirstPage?> GetFirstPage(int page = 1)
        {
            /*
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

            page--; // че это значит?? зачем??

            int limmit = 3; // должен быть фиксированный ???

            int countPage = (int)Math.Ceiling((double)products.Count / limmit); // приходит с сервера ???

            if (page > countPage || page < 0) throw new ArgumentException();

            List<Product> resultProducts = [];

            for (int i = page * limmit; i < (page * limmit + limmit) && i < products.Count; i++)
            {
                resultProducts.Add(products[i]);
            }

            return (countPage, resultProducts);
            */

            FirstPage? firstPage = await Request<FirstPage>($"Product/GetFirstPage");
            return firstPage;
        }

        // ????? WTF  Откуда их брать?
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
        public async Task<ProductDTO?> GetProductFullInfo(int id)
        {
            /*
            using HttpResponseMessage response = await httpClient.GetAsync($"Product/GetAllInformation?id={id}");

            if(response.StatusCode == HttpStatusCode.OK)
            {
                //var tt = await response.Content.ReadAsStringAsync();
                //var product = JsonSerializer.Deserialize<ProductDTO>(tt);

                ProductDTO? product = await httpClient.GetFromJsonAsync<ProductDTO>($"Product/GetAllInformation?id={id}");

                return product;
            }

            return null;
            */

            ProductDTO? product = await Request<ProductDTO>($"Product/GetProductFullInfo?id={id}");
            return product;
        }

        #endregion

        // нужна таблица с чеками ???
        // если да -  нужно 2 метода (получение первой страницы чеков  и их количество) , (получение конкретной страницы с чеками)
        // сохранение чеков
        // получение полной информации о чеке

        #region Employee

        public async Task<List<Employee>?> GetEmployees() //Получить список всех сотрудников
        {
            /*
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
            */

            List<Employee>? employees = await Request<List<Employee>>("Employee/all");
            return employees;
        }     

        
        public async Task<(bool result, string? message, Employee copyEmployee)> UpdateEmployee(Employee employee)
        {   
            string tmp = JsonSerializer.Serialize(employee, options); 
            
            HttpContent content = new StringContent(tmp);
            content.Headers.Remove("Content-Type");
            content.Headers.Add("Content-Type", "application/json; charset=utf-8");            

            using var response = await httpClient.PostAsJsonAsync("Employee/update", tmp);

            response.EnsureSuccessStatusCode();

            Employee? person = await response.Content.ReadFromJsonAsync<Employee>();

            return (result: true, message: null, employee);
        }


        public async Task<Employee> CreateEmployee(Employee employee)
        {
            string tmp = JsonSerializer.Serialize(employee, options);

            HttpContent content = new StringContent(tmp);
            content.Headers.Remove("Content-Type");
            content.Headers.Add("Content-Type", "application/json; charset=utf-8");

            using var response = await httpClient.PostAsJsonAsync("Employee/insert", tmp);

            response.EnsureSuccessStatusCode();

           Employee person = await response.Content.ReadFromJsonAsync<Employee>();

            return person;
        }


        //Загрузка статистических данных о пользователи
        public async Task<bool> GetUserStatistics(Employee user) 
        {
            await Task.Delay(1000);

            return true;
        }


        // поиск по ФАМИЛИИ или ИМЕНИ
        public async Task<List<Employee>?> GetBySurname(string name)
        {
            List<Employee>? employees =
                await Request<List<Employee>>($"Employee/GetBySurname?name={name}");

            return employees;
        }

        #endregion

        #region Appointment

        public async Task<List<Appointment>?> GetAllAppointment()
        {
            List<Appointment>? appointments = await Request<List<Appointment>>("Appointment/all");
            return appointments;
        }

        public async Task<Appointment> GetAppointmentById(int id)
        {
            Appointment? appointment = await Request<Appointment>($"Appointment/{id}");
            return appointment;
        }

        #endregion

        #region EmployeeStatus

        public async Task<List<EmployeeStatus>> GetAllEmployeeStatus()
        {
            List<EmployeeStatus>? employeeStatuses = await Request<List<EmployeeStatus>>("EmployeeStatus/all");
            return employeeStatuses;
        }

        public async Task<EmployeeStatus> GetEmployeeStatusById(int id)
        {
            EmployeeStatus? employeeStatus = await Request<EmployeeStatus>($"EmployeeStatus/{id}");
            return employeeStatus;
        }

        #endregion

        #region ASetOfRules

        public async Task<List<ASetOfRules>> GetAllASetOfRules()
        {
            List<ASetOfRules> aSetOfRules = await Request<List<ASetOfRules>>("ASetOfRules/all");
            return aSetOfRules;
        }

        public async Task<ASetOfRules> GetASetOfRulesById(int id)
        {
            ASetOfRules aSetOfRule = await Request<ASetOfRules>($"ASetOfRules/{id}");
            return aSetOfRule;
        }

        #endregion



    }
}
