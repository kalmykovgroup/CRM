using KTSF.Components.MainMenuComponent.Components.CashiersWorkplaceComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.MainMenuComponent.Components.WarehouseComponent
{
    public class WarehouseVM : IComponent //MainMenu -> WarehouseVM
    {
        public AppControl AppControl { get; }
        public MainMenuVM MainMenuVM { get; }

        public UserControl UserControl { get; }

        public void Run() => MainMenuVM.CurrentView = UserControl;

        public WarehouseVM(AppControl appControl, MainMenuVM mainMenuVM)
        {
            AppControl = appControl;
            MainMenuVM = mainMenuVM;
            UserControl = new WarehouseUC(this);
        }
    }
}
