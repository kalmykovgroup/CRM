using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.CommonComponent.TemplateProductComponent
{
    public class TemplateProductVM : IComponent
    {
        public AppControl AppControl { get; }

        public TemplateProductUC? TemplateProductUC { get; private set; }

        public UserControl Build => TemplateProductUC ?? Create();

        public UserControl Create()
        {
            TemplateProductUC = new TemplateProductUC(this);

            return TemplateProductUC;
        }

        public TemplateProductVM(AppControl appControl)
        {
            AppControl = appControl;
        }
    }
}
