
using CommunityToolkit.Mvvm.ComponentModel;
using KTSF.Components.CommonComponents.SearchComponent;
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

        public override UserControl Initial() => new CashiersWorkplaceUC(this);

        public Component SearchComponent { get; } 

        public CashiersWorkplaceComponent(UserControlVM binding, AppControl appControl) : base(binding, appControl)
        {
            SearchComponent = new SearchComponent(binding, appControl); 
        }





    }
}
