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

        public WarehouseUC? WarehouseUC { get; private set; }

        public UserControl Build => WarehouseUC != null ? WarehouseUC : Create();

        private UserControl Create()
        {
            WarehouseUC = new WarehouseUC(this);
            return WarehouseUC;
        }
         

        public WarehouseVM(AppControl appControl)
        {
            AppControl = appControl;
           
        }
    }
}
