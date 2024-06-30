using KTSF.Components.MainMenuComponent.Components.AdministrationComponent.Components.UsersPageComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.MainMenuComponent.Components.CashReceiptPageComponent
{
    public class CashReceiptPageVM : IComponent //MainMenuVM 
    {
        public AppControl AppControl { get; }

        public CashReceiptPageUC? CashReceiptPageUC { get; private set; }

        public UserControl Build => CashReceiptPageUC ?? Create();

        public UserControl Create()
        {
            CashReceiptPageUC = new CashReceiptPageUC(this);

            return CashReceiptPageUC;
        }

        public CashReceiptPageVM(AppControl appControl)
        {
            AppControl = appControl;
        }
    }
}
