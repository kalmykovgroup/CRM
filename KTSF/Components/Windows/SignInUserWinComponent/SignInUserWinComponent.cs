using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Navigation;
using System.Windows;
 
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Data; 
using KTSF.ViewModel;  
using System.Configuration;
using Microsoft.Win32;
using KTSF.Dto.Auth;
using CSharpFunctionalExtensions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using KTSF.Components.Windows.CompanyWinComponent;
using KTSF.Components.Windows.SignInUserWinComponent.Views;
using System.Runtime.CompilerServices;
using KTSF.Core.App;
using KTSF.Configurations_;
using System.Net;

namespace KTSF.Components.Windows.SignInUserWinComponent
{
    public partial class SignInUserWinComponent : Component
    { 

        public LoginUserRequest LoginUserRequest { get; } = new LoginUserRequest("1@mail.ru", "1");


       [ObservableProperty] private SignInFormUC? signInFormUC;

        public override UserControl Initial() => new SignInUserWinUC(this);


        public SignInUserWinComponent(UserControlVM binding, AppControl appControl) : base(binding, appControl) { }


        public override void UserControl_Loaded(object sender, RoutedEventArgs e) => Authorization();

        private async void Authorization()
        {
             
         
            if (AppControl.Server.AnonymJwtToken != null)
            {
                AppControl.SignInEmployeeWinComponent.Show();
           
                return;
            } 

            //Отобразить форму ввода логина и пароля
            SignInFormUC = new SignInFormUC(this);
        
        }




     /*   public void GenerateAuthQRCode()
        {
       

            //Здесь сотрудник вводит свой код для входа
            AuthFormComponent = new AuthFormComponent(FormContainer, AppControl);
            AuthFormComponent.AuthSuccess += AuthSuccess;
            AuthFormComponent.Show();

        }*/

        #region Commands

    

        [RelayCommand]
        public async Task SignInClick()
        {
            //Здесь данные уже проваледированны самой формой
            //Поэтому делаем сразу запрос на сервер
             

            IsLoad = "Авторизация...";

            //Сделали запрос на вход 
            Result<User, (string? Message, HttpStatusCode)> result = await AppControl.Server.Authorization(LoginUserRequest);

            IsLoad = null;

            //Если удалось войти
            if (result.IsSuccess)
            {   
                //Вызываем функцию отрабатывания после успешной авторизации как главного пользователя
                SuccessAuthorization(result.Value);
            }
            else
            { 
                MessageBox.Show($"${result.Error.Message}");
            } 

        }/*

        public void AuthSuccess(Employee employee)
        {
            AppControl.Employee = employee;
            AppControl.MainMenuComponent.Show();
        }   
      */

        #endregion

        //Попадаем после успешной авторизации
        public void SuccessAuthorization(User user)
        {
            //сохраняем пользователя 
            AppControl.User = user;

            //переходим в компонент выбора компании и объекта
            AppControl.CompanyComponent.Show();       
        }






    }
}
