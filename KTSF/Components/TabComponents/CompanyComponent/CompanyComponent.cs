using KTSF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.TabComponents.CompanyComponent
{
    public class CompanyComponent : TabComponent
    {
        public CompanyComponent(UserControlVM binding, AppControl appControl, string iconPath) : base(binding, appControl, iconPath)
        {
        }

        public override UserControl Initial() => new CompanyUC(this);
    }
}
