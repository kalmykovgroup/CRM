using KTSF.Components.MainMenuComponent.Components.AdministrationComponent;
using KTSF.Components.MainMenuComponent.Components.CashiersWorkplaceComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.MainMenuComponent
{
    public class MainMenuVM : IComponent
    {
        public AdministrationVM AdministrationVM { get; } //Админ панель
        public CashiersWorkplaceVM CashiersWorkplaceVM { get; } //Рабочее место кассира

        public AppControl AppControl { get; } 
        public UserControl UserControl { get; } 

        public MainMenuVM(AppControl appControl)
        {
            AppControl = appControl;
            UserControl = new MainMenuUC(this);

            AdministrationVM = new AdministrationVM(AppControl, this);

        }

        public void Run() => AppControl.UserControl = UserControl;
    }
}
