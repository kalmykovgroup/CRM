using KTSF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.TabComponents.MoneyComponent
{
    public class MoneyComponent : TabComponent //Деньги
    {
        public MoneyComponent(UserControlVM binding, AppControl appControl, string iconPath) : base (binding, appControl, iconPath)
        {
        }

        public override UserControl Initial() => new MoneyUC(this);
    }
}
