using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.MainMenuComponent.Components.CashiersWorkplaceComponent
{
    public class CashiersWorkplaceVM : IComponent //MainMenu -> Рабочее место кассира
    {
        public AppControl AppControl { get; }

        public UserControl UserControl { get; }

        public void Run() => AppControl.UserControl = UserControl;

        public CashiersWorkplaceVM(AppControl appControl)
        {
            AppControl = appControl;
            UserControl = new CashiersWorkplaceUC(this);
        }
    }
}
