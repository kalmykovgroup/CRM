using KTSF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.CommonComponents.CashiersWorkplaceComponent
{
    public partial class CashiersWorkplaceComponent : Component
    {
        public CashiersWorkplaceComponent(UserControlVM binding, AppControl appControl) : base(binding, appControl)
        {
        }

        public override Component FactoryMethod(UserControlVM binding, AppControl appControl, object? data = null)
         => new CashiersWorkplaceComponent(binding, appControl);

        public override UserControl Initial() => new CashiersWorkplaceUC(this);
    }
}
