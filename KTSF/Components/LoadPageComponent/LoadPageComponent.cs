using CommunityToolkit.Mvvm.ComponentModel;
using KTSF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KTSF.Components.LoadPageComponent
{
    public partial class LoadPageComponent : Component
    {

        
        public override UserControl Initial() => new LoadPageUC(this); 
           

        public LoadPageComponent(UserControlVM binding, AppControl appControl):base(binding, appControl) {
                    
        }

        public override Component FactoryMethod(UserControlVM binding, AppControl appControl, object? data = null)
        => new LoadPageComponent(binding, appControl);

        //Авто запуск после инициализации окна
        public override async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            IsLoad = "Подключение к интернету";

            await AppControl.Server.Connect();

            IsLoad = "Загрузка данных";

            await AppControl.Server.LoadData();

            IsLoad = null;


            AppControl.SignInPageComponent.Show();
        }

       
    }
}
