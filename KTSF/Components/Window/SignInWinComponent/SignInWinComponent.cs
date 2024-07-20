using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Navigation;
using System.Windows;
using KTSFClassLibrary;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Data;
using KTSF.Components.Window.LoadComponent;
using KTSF.ViewModel;
using KTSF.Components.CommonComponents.SignInFormComponent;
using KTSF.Components.SignInPageComponent.Components.AuthFormComponent;
using KTSF.Components.SignInPageComponent;
using System.Configuration;
using Microsoft.Win32;

namespace KTSF.Components.Window.SignInPageComponent
{
    public partial class SignInWinComponent : Component
    {

        public UserControlVM SignInFormFrame { get; } = new();  //Контейнер для SignInForm
        public SignInFormComponent? SignInFormComponent;

        public UserControlVM AuthFormFrame { get; } = new();  //Контейнер для AuthForm
        public AuthFormComponent? AuthFormComponent;

        public UserControlVM FormContainer { get; } = new();

        public override UserControl Initial() => new SignInWinUC(this);


        public SignInWinComponent(UserControlVM binding, AppControl appControl) : base(binding, appControl) { }


        public override void UserControl_Loaded(object sender, RoutedEventArgs e) => Authorization();

        private async void Authorization()
        {
             
            //Получили данные из реестра
            string? token = Regedit.GetValue(nameof(User.AccessToken));

            if (token is not null)
            {
               
                IsLoad = "Авторизация...";

                (bool result, string? error, User? user) = await AppControl.Server.Authorization(token);  //Сделали запрос на вход 

                IsLoad = null;

                //Если удалось войти
                if (result)
                {
                    if(user == null) throw new ArgumentNullException(nameof(user));

                    SuccessAuthorization(user);
                    return;
                }

            }

            //Если не удалось войти
            //Пробуем авторизоваться

             
            SignInFormComponent = new SignInFormComponent(AppControl.User, FormContainer, AppControl); //Создали форму
            SignInFormComponent.SignInClickAction = SignInClickAction; //Подписались на кнопку войти
            SignInFormComponent.Show(); //Отобразили форму на экране
        }

      

        public void SuccessAuthorization(User user)
        { 
            AppControl.User = user;
            Authentication(); //Пробуем аунтетифицироваться           
        }

        public void Authentication()
        {
            //Сдесь сотрудник вводит свой код для входа
            AuthFormComponent = new AuthFormComponent(FormContainer, AppControl);
            AuthFormComponent.AuthSuccess += AuthSuccess;
            AuthFormComponent.Show();

        }

        #region Commands

        public async void SignInClickAction(object? parametr)
        {
            //Сдесь данные уже проваледированны самой формой
            //Поэтому делаем сразу запрос на сервер
             

            IsLoad = "Авторизация...";

            //Сделали запрос на вход 
            (bool result, string? error, User? user) = await AppControl.Server.Authorization(AppControl.User.Username, AppControl.User.Password);

            IsLoad = null;

            //Если удалось войти
            if (result)
            {
                if(user == null) throw new ArgumentNullException(nameof(user));

                //Сохраняем данные в реестр
                Regedit.SetValue(nameof(User.AccessToken), user.AccessToken);

                SuccessAuthorization(user);
            }
            else
            {
                //Здесь нужно отправить данные об ошибки в форму
                //Вывод ошибки входа
                MessageBox.Show($"Не удалось войти:\n${error}");
            }

        }

        public void AuthSuccess(Employee employee)
        {
            AppControl.Employee = employee;
            AppControl.MainMenuComponent.Show();
        }   
      

        #endregion


      



    }
}
