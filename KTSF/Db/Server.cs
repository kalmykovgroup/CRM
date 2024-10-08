﻿
using CSharpFunctionalExtensions;
using CSharpFunctionalExtensions.ValueTasks;
using KTSF.Configurations_;
using KTSF.Core.App;
using KTSF.Core.Object;
using KTSF.Core.Object.ABAC;
using KTSF.Core.Object.Product_;
using KTSF.Dto.Auth;
using KTSF.Dto.Company_; 
using KTSF.Dto.Employee_;
using KTSF.Dto.Object_;
using KTSF.Dto.Product_;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.WebSockets;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using KTSF.Components.TabComponents.CashiersWorkplaceComponent;
using KTSF.Contracts.CashiersWorkplace;
using KTSF.Core.Receipt_;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KTSF.Db
{
    public class Server
    {
        public string EmptyDataMessage { get; set; } = "The data returned is empty";
        public string UnauthorizedMessage { get; set; } = "401 unauthorized";
        public string InternetConnectionMessage { get; set; } = "Internet connection...";
        public string TokenNotFoundMessage { get; set; } = "There is no authorization token, re-login is required.";
        public string ServerErrorMessage { get; set; } = "Error on the server! Code {0}. We are already solving this problem.";
         

        public static string DomainName { get; set; } = "localhost:7286";

        public Uri BaseUri { get; set; } = new Uri($"https://{DomainName}");
        public Uri WebSockerUrl { get; set; } = new Uri($"wss://{DomainName}/Employee-SignIn");

        AppControl AppControl { get; }

        public HttpClient httpClient { get; }

        public void SetUserJwtToken(string? token)
        {
            AuthUserJwtToken = token != null ? new(Configurations.AuthSchemeName, token) : null;
        }
        
        public void SetEmployeeJwtToken(string? token)
        {
            AuthEmployeeJwtToken = token != null ? new(Configurations.AuthSchemeName, token) : null;
        }

        public void SetAnonymJwtToken(string? token)
        {
            AnonymJwtToken = token != null ? new(Configurations.AuthSchemeName, token) : null;
        }

        private AuthenticationHeaderValue? AuthUserJwtToken { get; set; }

        private AuthenticationHeaderValue? AuthEmployeeJwtToken { get; set; }

        public AuthenticationHeaderValue? AnonymJwtToken { get; private set; }


        public static JsonSerializerOptions options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            //Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic ),
            WriteIndented = true
        };

        public Server(AppControl appControl)
        {

            string? token = Regedit.GetValue(Configurations.AnonymJwtToken);


            if (token is not null)
            {

               AnonymJwtToken = new AuthenticationHeaderValue(Configurations.AuthSchemeName, token);
               
            }

            AppControl = appControl;
            httpClient = new()
            {
                BaseAddress = BaseUri
            };

            httpClient.DefaultRequestHeaders
              .Accept
              .Add(new MediaTypeWithQualityHeaderValue("application/json"));



        }

        public async Task<bool> Connect()
        {
            await Task.Delay(0);
            return true;
        }


        private async Task<Result<T2, (string? Message, HttpStatusCode)>> Post<T1, T2>(string url, T1 data, AuthenticationHeaderValue? authClient = null)
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
        //Возвращаем список доступным компаний, объектов и список пользователей на этих объектах

        public async Task<Result<User, (string? Message, HttpStatusCode)>> Authorization(LoginUserRequest loginUserRequest)
        {
            //Здесь мы передаем объект заглушку для того что-бы метод не ругался что нет jwt токена
            //Сервере этот токен просить не будет.
            Result<LoginUserResponse, (string? Message, HttpStatusCode)> result =  
                await Post<LoginUserRequest, LoginUserResponse>($"auth/login", loginUserRequest, new(Configurations.AuthSchemeName, ""));

            if (result.IsSuccess)
            {
                if (result.Value.IsSuccess)
                {
                    if (result.Value.User is not null)
                    {
                        return Result.Success<User, (string? Message, HttpStatusCode)>(result.Value.User);
                    } 
                 
                }

                return Result.Failure<User, (string? Message, HttpStatusCode)>((result.Value.Error, HttpStatusCode.OK));
            }
            
            return Result.Failure<User, (string? Message, HttpStatusCode)>(result.Error);
            
        }

        public async Task<Result<List<Company>, (string? Message, HttpStatusCode)>> LoadCompanies()
        {
            Result<CompanyAllResponse, (string? Message , HttpStatusCode)> result = await Get<CompanyAllResponse>($"Company/all", AuthUserJwtToken);

            if (result.IsSuccess)
            {
                if(result.Value is not null)
                {
                    if(result.Value.Companies != null)
                    {
                        return Result.Success<List<Company>, (string? Message, HttpStatusCode)> (result.Value.Companies);
                    }
                    else
                    {
                        return Result.Failure<List<Company>, (string? Message, HttpStatusCode)>((result.Value.Error, HttpStatusCode.OK));
                    }
                   
                }
                else
                {
                    return Result.Failure<List<Company>, (string? Message, HttpStatusCode)>((EmptyDataMessage, HttpStatusCode.OK));
                }
   
            }

            return Result.Failure<List<Company>, (string? Message, HttpStatusCode)>(result.Error);
        }
   

        public async Task RunWebSocketClientAuthEmployee(
            Action<string> SuccessGenerateBarCode,
            Action<string?, HttpStatusCode> FailureGenerateBarCode,
            Action<Employee> SuccessAuthEmployee,
            Action<string?, HttpStatusCode> FailureAuthEmployee)
        {

        #if DEBUG
            Result<Employee, (string? Message, HttpStatusCode)> result = await Get<Employee>($"auth/debug-get-employee");

            SuccessAuthEmployee.Invoke(result.Value);
            return;
        #endif


            if (AnonymJwtToken is null)
            {
                FailureGenerateBarCode.Invoke("AnonymJwtToken is null", HttpStatusCode.OK);
                return;
            }

          

            byte[] buffer = new byte[4 * 1024];

            while (true)
            {

                ClientWebSocket webSocket = new ClientWebSocket();

                try
                {
                    webSocket.Options.SetRequestHeader("Authorization", $"{AnonymJwtToken.Scheme} {AnonymJwtToken.Parameter}");

        //Поиск товаров
        public async Task<List<Product>?> SearchProducts(string text) // возвращает максимум 20 товаров
        {
            List<Product>? products = await Request<List<Product>>($"Product/SearchProduct?name={text}");
            return products;
        }

        public async Task<List<Product>?> GetProducts(int page)
        {
            List<Product>? products = await Request<List<Product>>($"Product/GetProducts?page={page}");
            return products;          
        }

        #endregion


        public async Task<Result<ObjectSelectResponse, (string? Message, HttpStatusCode)>> SelectObject(ObjectSelectRequest objectSelectRequest)
        {
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
            ProductDTO? product = await Request<ProductDTO>($"Product/GetProductFullInfo?id={id}");
            return product;
        }

        #endregion

        #region Receipt

        public bool SaveReceipt(ReceiptVM receiptVm)
        {
            var receipt = ConvertReceipt(receiptVm);
            
            return true;
        }

        private Receipt ConvertReceipt(ReceiptVM receiptVm)
        {
            var receipt = new Receipt();
            receipt.BuyProducts = ConvertBuyProducts(receiptVm.BuyProducts);
            
            receipt.ReceiptPaymentInfo = new PaymentInfo();
            receipt.ReceiptPaymentInfo.TotalSum = receiptVm.ReceiptPaymentInfo.TotalSum;
            receipt.ReceiptPaymentInfo.CashAmount = receiptVm.ReceiptPaymentInfo.CashAmount;
            receipt.ReceiptPaymentInfo.CardAmount = receiptVm.ReceiptPaymentInfo.CardAmount;
            receipt.ReceiptPaymentInfo.AmountPaid = receiptVm.ReceiptPaymentInfo.AmountPaid;
            receipt.ReceiptPaymentInfo.PaymentMethodId = (int)receiptVm.ReceiptPaymentInfo.PaymentMethod;

            receipt.Discount = receiptVm.Discount;
            return receipt;
        }

        private List<BuyProduct> ConvertBuyProducts(ObservableCollection<BuyProductVM> buyProductsVm)
        {
            List<BuyProduct> buyProducts = new List<BuyProduct>();
            foreach (var buyProductVm in buyProductsVm)
            {
                BuyProduct newBuyProduct = new BuyProduct();
                newBuyProduct.Product = buyProductVm.Product;
                newBuyProduct.ProductId = buyProductVm.Product.Id;
                newBuyProduct.Price = buyProductVm.Price;
                newBuyProduct.Count = buyProductVm.Count;
                newBuyProduct.TotalSumProduct = buyProductVm.TotalSumProduct;
                newBuyProduct.Discount = buyProductVm.Discount;
                
                buyProducts.Add(newBuyProduct);
            }

            return buyProducts;
        }

        #endregion
        // нужна таблица с чеками ???
        // если да -  нужно 2 метода (получение первой страницы чеков  и их количество) , (получение конкретной страницы с чеками)
        // сохранение чеков
        // получение полной информации о чеке

        #region Employee

        public async Task<List<Employee>?> GetEmployees() //Получить список всех сотрудников
        {
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


        // ????? WTF  Откуда их брать?
        //Загрузка статистических данных о пользователи
        public async Task<bool> GetUserStatistics(Employee user)
        {
            await Task.Delay(1000);

            return true;
        }


        // поиск по ФАМИЛИИ или ИМЕНИ
        public async Task<Result<List<Employee>, (string? Message, HttpStatusCode)>> GetBySurname(string name)
        {
            List<Employee>? employees =
                await Request<List<Employee>>($"Employee/GetBySurname?name={name}");

            return employees;
        }

        public async Task<List<Employee>?> SearchEmployee(string searchElement, string status)
        {
            List<Employee>? employees = new List<Employee>();
            return employees;
        }

        #endregion

        #region Appointment

        public async Task<Result<List<Appointment>, (string? Message, HttpStatusCode)>> GetAllAppointment()
        {
            return await Get<List<Appointment>>("Appointment/all");
           
        }

        public async Task<Result<Appointment, (string? Message, HttpStatusCode)>> GetAppointmentById(int id)
        {
           return await Get<Appointment>($"Appointment/{id}");
         
        }

        #endregion

        #region EmployeeStatus

        public async Task<Result<List<EmployeeStatus>, (string? Message, HttpStatusCode)>> GetAllEmployeeStatus()
        {
            return await Get<List<EmployeeStatus>>("EmployeeStatus/all");
           
        }

        public async Task<Result<EmployeeStatus, (string? Message, HttpStatusCode)>> GetEmployeeStatusById(int id)
        {
            return await Get<EmployeeStatus>($"EmployeeStatus/{id}");
           
        }

        #endregion

        #region ASetOfRules

        public async Task<List<ASetOfRules>?> GetAllASetOfRules()
        {
            List<ASetOfRules>? aSetOfRules = await Request<List<ASetOfRules>>("ASetOfRules/all");
            return aSetOfRules;
        }

        public async Task<ASetOfRules?> GetASetOfRulesById(int id)
        {
            ASetOfRules? aSetOfRule = await Request<ASetOfRules>($"ASetOfRules/{id}");
            return aSetOfRule;
        }

        #endregion



    }
}
