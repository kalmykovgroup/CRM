
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
using KTSF.ViewModel;
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
using KTSF.Components;
using KTSF.Components.TabComponents.CashiersWorkplaceComponent;
using KTSF.Components.TabComponents.SalesComponent;
using KTSF.Components.TabComponents.WarehouseComponent;
using KTSF.Contracts.CashiersWorkplace;
using static System.Runtime.InteropServices.JavaScript.JSType;
using KTSF.Core.Object.Receipt_;
using KTSF.Dto.Receipt_;
using Type = System.Type;

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
            return await Request<T1, T2>(HttpMethod.Post, url, data, authClient ?? AuthEmployeeJwtToken);
        }

        private async Task<Result<T2, (string? Message, HttpStatusCode)>> Get<T1, T2>(string url, T1 data, AuthenticationHeaderValue? authClient = null)
        {
            return await Request<T1, T2>(HttpMethod.Get, url, data, authClient ?? AuthEmployeeJwtToken);  
        }

        private async Task<Result<T1, (string? Message, HttpStatusCode)>> Get<T1>(string url, AuthenticationHeaderValue? authClient = null)
        {
            return await Request<T1, T1>(HttpMethod.Get, url, default, authClient ?? AuthEmployeeJwtToken); //По умолчанию пытаемся входить как employee
        }
        

        private async Task<Result<T2, (string? Message, HttpStatusCode)>> Request<T1, T2>(HttpMethod method, string url, T1? data, AuthenticationHeaderValue? authClient)
        { 

            if (authClient is null)
            {
                Result.Failure<T2>(TokenNotFoundMessage);
            }

            HttpContent? content = null;

            if (data != null)
            {
                content = JsonContent.Create<T1>(data);
            }

            do
            {
                try
                {
                    HttpRequestMessage httpRequestMessage = new HttpRequestMessage(method, url);

                    httpRequestMessage.Content = content;

                    httpRequestMessage.Headers.Authorization = authClient;

                    httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await httpClient.SendAsync(httpRequestMessage);
                     

                    AppControl.IsLoad = null;

                    if (response.StatusCode == HttpStatusCode.OK)
                    {

                        T2? result = await response.Content.ReadFromJsonAsync<T2>();

                        if (result != null)
                        {
                            return Result.Success<T2, (string? Message, HttpStatusCode)>(result);
                        }
                        else
                        {
                            return Result.Failure<T2, (string? Message, HttpStatusCode)>((EmptyDataMessage, response.StatusCode));
                            // обработка ошибки получения данных
                        }
                    }
                    else if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        Result.Failure<T2, (string? Message, HttpStatusCode)>((UnauthorizedMessage, response.StatusCode));

                        return Result.Failure<T2, (string? Message, HttpStatusCode)>((UnauthorizedMessage, response.StatusCode));
                        // обработка не авторизованных 
                    }
                    else
                    {
                        return Result.Failure<T2, (string? Message, HttpStatusCode)>((System.String.Format(ServerErrorMessage, response.StatusCode), response.StatusCode));
                        // обработка серверных ошибок
                    }

                }
                catch (HttpRequestException)
                {
                    AppControl.IsLoad = InternetConnectionMessage;
                    continue;
                }
                 
            } while (true);
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

                    await webSocket.ConnectAsync(WebSockerUrl, CancellationToken.None);

                    AppControl.IsLoad = null;

                    var receiveResult = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);


                    //Если соединение не закрыто
                    if (!receiveResult.CloseStatus.HasValue)
                    {
                        string QRCode = Encoding.UTF8.GetString(buffer, 0, receiveResult.Count);

                        SuccessGenerateBarCode.Invoke(QRCode);

                        receiveResult = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                        string jsonEmployee = Encoding.UTF8.GetString(buffer, 0, receiveResult.Count);
                        Employee? employee = JsonSerializer.Deserialize<Employee>(jsonEmployee, options);

                        if (employee != null)
                        {
                            SuccessAuthEmployee.Invoke(employee);
                        }
                        else
                        {
                            FailureAuthEmployee.Invoke("Не удалось выполнить вход", HttpStatusCode.OK);
                        }

                        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, null, CancellationToken.None);

                    }




                }
                catch (WebSocketException)
                {
                    AppControl.IsLoad = InternetConnectionMessage;
                    continue;
                }
                catch (HttpRequestException)
                {
                    AppControl.IsLoad = InternetConnectionMessage;
                    continue;
                }
            }
        }

           
            
        //Поиск товаров
        public async Task<Result<List<Product>, (string? message, HttpStatusCode)>> SearchProducts(string text) // возвращает максимум 20 товаров
        {
            Result<List<Product>, (string? message, HttpStatusCode)> result = await Get<List<Product>>($"Product/SearchProduct?name={text}");

            return result;                    
        }

        public async Task<Result<List<Product>, (string? message, HttpStatusCode)>> GetProducts(int page)
        {
            return await Get<List<Product>>($"Product/GetProducts?page={page}"); 
        }

        #endregion


        public async Task<Result<ObjectSelectResponse, (string? Message, HttpStatusCode)>> SelectObject(ObjectSelectRequest objectSelectRequest)
        {
            return await Post<ObjectSelectRequest, ObjectSelectResponse>("auth/select-object", objectSelectRequest, AuthUserJwtToken);
        }


        #region Product

       
 

        // первая страница продуктов и общее количество продуктов
        public async Task<Result<FirstPage<Product>, (string? Message, HttpStatusCode)>> GetFirstPageProduct(int page = 1)
        {            
            return await Get<FirstPage<Product>>($"Product/GetFirstPage"); 
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
        public async Task<Result<ProductDTO, (string? error, HttpStatusCode)>> GetProductFullInfo(int id)
        {
            return await Get<ProductDTO>($"Product/GetProductFullInfo?id={id}"); 
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

        public async Task<Result<FirstPage<Receipt>, (string? Message, HttpStatusCode)>> GetFirstPageReceipt(int page = 1)
        {
            return await Get<FirstPage<Receipt>>($"Receipt/GetFirstPage");
        }
        
        public async Task<Result<List<Receipt>, (string? message, HttpStatusCode)>> GetReceipts(int page)
        {
            return await Get<List<Receipt>>($"Receipt/GetReceipts?page={page}");      
        }
        
        //Получить подробную информацию о товаре
        public async Task<Result<ReceiptDTO, (string? error, HttpStatusCode)>> GetReceiptFullInfo(int id)
        {
            return await Get<ReceiptDTO>($"Receipt/GetReceiptFullInfo?id={id}"); 
        }
        
        #endregion
         

        #region Employee

        public async Task<Result<List<Employee>, (string? Message, HttpStatusCode)>> GetEmployees() //Получить список всех сотрудников
        { 
            return await Get<List<Employee>>("Employee/all");
            
        }


        public async Task<(bool result, string? message, Employee copyEmployee)> UpdateEmployee(Employee employee)
        {
            //Result < Employee, (string? Message, HttpStatusCode)> result = await Post<Employee, Employee>("Employee/update", employee, AuthEmployeeJwtToken);


            string tmp = JsonSerializer.Serialize(employee, options);

            HttpContent content = new StringContent(tmp);
            content.Headers.Remove("Content-Type");
            content.Headers.Add("Content-Type", "application/json; charset=utf-8");

            using var response = await httpClient.PostAsJsonAsync("Employee/update", tmp);

            response.EnsureSuccessStatusCode();

            Employee? person = await response.Content.ReadFromJsonAsync<Employee>();

            return (result: true, message: null, person);
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
       


        // поиск по ФАМИЛИИ или ИМЕНИ
        public async Task<Result<List<Employee>, (string? Message, HttpStatusCode HttpStatusCode)>> GetBySurname(string name)
        {
            return await Get<List<Employee>>($"Employee/GetBySurname?name={name}");
             
        }

        public async Task<Result<List<Employee>, (string? Message, HttpStatusCode HttpStatusCode)>> SearchEmployee(string searchElement, string status)
        {
             
            return await Get<string, List<Employee>>("Employee/GetBySurname", searchElement);    
                
        }

        #endregion

        #region Appointment

        public async Task<Result<List<Appointment>, (string? Message, HttpStatusCode HttpStatusCode)>> GetAllAppointment()
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

        public async Task<Result<List<ASetOfRules>, (string? Message, HttpStatusCode)>> GetAllASetOfRules()
        {
            return  await Get<List<ASetOfRules>>("ASetOfRules/all"); 
        }

        public async Task<Result<ASetOfRules, (string? Message, HttpStatusCode)>> GetASetOfRulesById(int id)
        {
            return await Get<ASetOfRules>($"ASetOfRules/{id}"); 
        }

        #endregion

        public async Task<Result<FirstPage<object>, (string? Message, HttpStatusCode)>> GetFirstPage(IPaganatable paganatable, int page = 1)
        {
            if (paganatable is SalesComponent)
            {
                Result<FirstPage<Receipt>,(string? Message, HttpStatusCode)> result = await GetFirstPageReceipt();
                return result.Map(value => value.ToObjectList());
            } 
            else if (paganatable is WarehouseComponent)
            {
                var result = await GetFirstPageProduct();
                return result.Map(value => value.ToObjectList());
            }
            else
            {
                return Result.Failure<FirstPage<object>, (string? Message, HttpStatusCode)>(("Неподдерживаемый тип", HttpStatusCode.BadRequest));
            }
        }
        
        public async Task<Result<List<object>, (string? message, HttpStatusCode)>> GetElements(IPaganatable paganatable, int page)
        {
            if (paganatable is SalesComponent)
            {
                var result = await GetReceipts(page);
                return result.Map(value => value.Cast<object>().ToList());
            }
            else if (paganatable is WarehouseComponent)
            {
                var result = await GetProducts(page);
                return result.Map(value => value.Cast<object>().ToList());
            }
            else
            {
                return Result.Failure<List<object>, (string? Message, HttpStatusCode)>(("Неподдерживаемый тип", HttpStatusCode.BadRequest));
            }
        }
        
    }
}
