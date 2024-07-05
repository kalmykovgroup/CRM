using KTSF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.CommonComponents.SearchComponent
{
    public partial class SearchComponent : Component
    {
        public SearchComponent(UserControlVM binding, AppControl appControl) : base(binding, appControl)
        {
        }

        public override Component FactoryMethod(UserControlVM binding, AppControl appControl, object? data = null)
         => new SearchComponent(binding, AppControl);

        public override UserControl Initial() => new SearchUC(this);
         
    }
}
