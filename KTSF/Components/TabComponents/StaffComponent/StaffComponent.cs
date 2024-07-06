using KTSF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KTSF.Components.TabComponents.StaffComponent
{
    public class StaffComponent : TabComponent
    {
        public StaffComponent(UserControlVM binding, AppControl appControl) : base(binding, appControl)
        {
        }

        public override UserControl Initial() => new StaffUC(this);

        public override async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            IsLoad = "Загрузка пользователей";

            await Task.Delay(2000);

            IsLoad = null;

        }


       
    }
}
