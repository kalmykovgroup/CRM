using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.MainMenuComponent.Components.WarehousePageComponent.Components.AcceptancePoductsPageComponent
{
    //Поступление товаров
    public class AcceptancePoductsPageVM : IComponent //MainMenuVM -> WarehousePageVM -> AcceptancePoductsPageVM
    {
        public AppControl AppControl { get; }

        public AcceptancePoductsPageUC? AcceptancePoductsPageUC { get; private set; }

        public UserControl Build => AcceptancePoductsPageUC ?? Create();

        public UserControl Create()
        {
            AcceptancePoductsPageUC = new AcceptancePoductsPageUC(this);

            return AcceptancePoductsPageUC;
        }

        public AcceptancePoductsPageVM(AppControl appControl)
        {
            AppControl = appControl;
        }
    }
}
