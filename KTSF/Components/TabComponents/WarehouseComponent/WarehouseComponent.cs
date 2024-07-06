using KTSF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.TabComponents.WarehouseComponent
{
    public class WarehouseComponent : TabComponent //Склад
    {
        public WarehouseComponent(UserControlVM binding, AppControl appControl) : base(binding, appControl)
        {
        }

        public override UserControl Initial() => new WarehouseUC(this);
    }
}
