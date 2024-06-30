using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.CommonComponent.SearchComponent
{
     public class SearchVM : IComponent
    {
        public AppControl AppControl { get; }

        public SearchUC? SearchUC { get; private set; }

        public UserControl Build => SearchUC ?? Create();

        public UserControl Create()
        {
            SearchUC = new SearchUC(this);
            return SearchUC;
        }

        public SearchVM(AppControl appControl)
        {
            AppControl = appControl;
        }
    }
}
