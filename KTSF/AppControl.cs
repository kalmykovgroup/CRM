using KTSFClassLibrary;
using CommunityToolkit.Mvvm.ComponentModel;  
using KTSF.Components.LoadComponent;
using KTSF.Components.MainMenuComponent;
using KTSF.Components.SignInComponent;
using KTSF.Server_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF
{
    public partial class AppControl : ObservableObject
    {
        //Отображение прогресса загрузки (Передать строку состояния или null для завершения)
        [ObservableProperty] string? isLoad = null;

        //Главное окно в котором отображаеться UserControl
        public MainWindow MainWindow { get; }

        //Текущее отображаемое окно
        [ObservableProperty] public UserControl? userControl;

        //компоненты
        public LoadVM LoadVM { get; }
        public SignInVM SignInVM { get; }
        public MainMenuVM MainMenuVM { get; }

        public Server Server { get; }

        public AppControl(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
            Server = new Server(this);
            //Создаем компоненты

            LoadVM = new LoadVM(this);
            SignInVM = new SignInVM(this);
            MainMenuVM = new MainMenuVM(this);

            //Запускаем первую страницу
            NavLoad();
        }


        //Навигация

        public void NavLoad() { //Первое окно для соединения с сервером
            UserControl = LoadVM.Build;
            LoadVM.Run();
        } 
        public void NavSignIn() => UserControl = SignInVM.Build; //После соединения с сервером переходим в окно входа
        public void NavMainMenuVM() => UserControl = MainMenuVM.Build; //Главное окно в котором находятся все компоненты работы с п

    }
}
