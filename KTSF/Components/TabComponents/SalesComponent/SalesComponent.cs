using KTSF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.TabComponents.SalesComponent
{
    public class SalesComponent : TabComponent
    {
        public SalesComponent(UserControlVM binding, AppControl appControl, string iconPath) : base (binding, appControl, iconPath)
        {
        }

        public override UserControl Initial() => new SalesUC(this);
    }
}
