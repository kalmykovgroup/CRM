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
            //Пропускаем Вход
            AppControl.MainMenuComponent.Show();
            return;
            //Если есть логин и пароль, то пробуем войти
            //Сдесь идет запрос на сервер
            if (false)
            {
                //Получили данные из реестра
                string login = "tester";
                string password = "tester";


                IsLoad = "Авторизация...";

                (bool result, string? error, MainUser mainUser) = await AppControl.Server.Authorization(AppControl.MainUser);  //Сделали запрос на вход 

                IsLoad = null;

                //Если удалось войти
                if (result)
                {
                    SuccessAuthorization(mainUser);
                }

            }

            //Если не удалось войти
            //Пробуем авторизоваться

            SignInFormComponent = new SignInFormComponent(FormContainer, AppControl); //Создали форму
            SignInFormComponent.SignInClickAction = SignInClickAction; //Подписались на кнопку войти
            SignInFormComponent.Show(); //Отобразили форму на экране
        }

        public void Authentication()
        {
            AuthFormComponent = new AuthFormComponent(FormContainer, AppControl);
            AuthFormComponent.AuthClickAction += AuthClickAction;
            AuthFormComponent.Show();
        }

        public void SuccessAuthorization(MainUser mainUser)
        {
            //Сохраняем данные о пользователи
            AppControl.MainUser = mainUser;

            Authentication(); //Пробуем аунтетифицироваться 
            return;
        }

        #region Commands

        public async void SignInClickAction(object? parametr)
        {
            //Сдесь данные уже проваледированны самой формой
            //Поэтому делаем сразу запрос на сервер

            IsLoad = "Авторизация...";

            //Сделали запрос на вход 
            (bool result, string? error, MainUser mainUser) = await AppControl.Server.Authorization(AppControl.MainUser);

            IsLoad = null;

            //Если удалось войти
            if (result)
            {
                SuccessAuthorization(mainUser);
            }
            else
            {
                //Вывод ошибки входа
                MessageBox.Show("Не удалось войти");
            }

        }

        public void AuthClickAction(object? parametr)
        {
            AppControl.MainMenuComponent.Show();
        }

        #endregion



 

    }
}
