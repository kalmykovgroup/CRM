using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KTSF.Components.CommonComponent.TemplateProductComponent
{
    /// <summary>
    /// Логика взаимодействия для TemplateProductUC.xaml
    /// </summary>
    public partial class TemplateProductUC : UserControl
    {
        public TemplateProductVM TemplateProductVM { get; }

        public TemplateProductUC(TemplateProductVM templateProductVM)
        {
            InitializeComponent();
            TemplateProductVM = templateProductVM;
            DataContext = TemplateProductVM;
        }
    }
}
