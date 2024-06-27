using KTSF.Components.MainMenuComponent.Components.CashiersWorkplaceComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.MainMenuComponent.Components.AdministrationComponent
{
    public class AdministrationVM : IComponent //MainMenuVM -> AdministrationVM
    {
        public AppControl AppControl { get; }
        public MainMenuVM MainMenuVM { get; }

        public UserControl UserControl { get; }

        public void Run() => AppControl.UserControl = UserControl;

        public AdministrationVM(AppControl appControl, MainMenuVM mainMenuVM)
        {
            AppControl = appControl;
            MainMenuVM = mainMenuVM;

            UserControl = new AdministrationUC(this);
        }
    }
}
