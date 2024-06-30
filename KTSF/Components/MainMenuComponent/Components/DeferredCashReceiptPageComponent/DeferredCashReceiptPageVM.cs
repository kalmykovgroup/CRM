using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.MainMenuComponent.Components.DeferredCashReceiptPageComponent
{
    //Отложенные чеки
    public class DeferredCashReceiptPageVM : IComponent //MainMenuVM 
    {
        public AppControl AppControl { get; }

        public DeferredCashReceiptPageUC? DeferredCashReceiptPageUC { get; private set; }

        public UserControl Build => DeferredCashReceiptPageUC ?? Create();

        public UserControl Create()
        {
            DeferredCashReceiptPageUC = new DeferredCashReceiptPageUC(this);

            return DeferredCashReceiptPageUC;
        }

        public DeferredCashReceiptPageVM(AppControl appControl)
        {
            AppControl = appControl;
        }
    }
}
