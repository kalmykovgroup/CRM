using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.MainMenuComponent.Components.CashiersWorkplaceComponent
{
    public class CashiersWorkplaceVM : IComponent //MainMenu -> CashiersWorkplaceVM
    {
        public AppControl AppControl { get; }

        public CashiersWorkplaceUC? CashiersWorkplaceUC { get; private set; }

        public UserControl Build => CashiersWorkplaceUC != null ? CashiersWorkplaceUC : Create();

        public UserControl Create()
        {
            CashiersWorkplaceUC = new CashiersWorkplaceUC(this);
            return CashiersWorkplaceUC;
        }

        public CashiersWorkplaceVM(AppControl appControl)
        {
            AppControl = appControl;
        }
    }
}
