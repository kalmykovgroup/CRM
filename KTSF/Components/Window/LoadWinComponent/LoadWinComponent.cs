using CommunityToolkit.Mvvm.ComponentModel;
using KTSF.Components.TabComponents.CashiersWorkplaceComponent;
using KTSF.Components.Window.LoadComponent;
using KTSF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KTSF.Components.Window.LoadComponent
{
    public partial class LoadWinComponent : Component
    {


        public override UserControl Initial() => new LoadWinUC(this);


        public LoadWinComponent(UserControlVM binding, AppControl appControl) : base(binding, appControl)
        {

        } 

        //Авто запуск после инициализации окна
        public override async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            IsLoad = "Подключение к интернету";

            await AppControl.Server.Connect();

            IsLoad = "Загрузка данных";

            await AppControl.Server.LoadData();

            IsLoad = null;


            AppControl.SignInComponent.Show();
        }


    }
}
