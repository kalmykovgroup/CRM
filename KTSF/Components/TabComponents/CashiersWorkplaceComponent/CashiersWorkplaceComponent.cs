 
using KTSF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.TabComponents.CashiersWorkplaceComponent
{
    public class CashiersWorkplaceComponent : TabComponent
    {
        public CashiersWorkplaceComponent(UserControlVM binding, AppControl appControl) : base(binding, appControl)
        {

        }


        public override UserControl Initial() => new CashiersWorkplaceUC(this);
    }
}
