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

        public AdministrationUC? AdministrationUC { get; private set; }

        public UserControl Build => AdministrationUC != null ? AdministrationUC : Create();

        public UserControl Create()
        {
            AdministrationUC = new AdministrationUC(this);
            return AdministrationUC;
        }

        public AdministrationVM(AppControl appControl)
        {
            AppControl = appControl;        
        }
    }
}
