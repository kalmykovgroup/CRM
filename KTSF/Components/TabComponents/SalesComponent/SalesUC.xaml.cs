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

namespace KTSF.Components.TabComponents.SalesComponent
{
    /// <summary>
    /// Логика взаимодействия для SalesUC.xaml
    /// </summary>
    public partial class SalesUC : UserControl
    {
        
        public SalesComponent SalesComponent { get; }
        public SalesUC(SalesComponent salesComponent)
        {
            InitializeComponent();
            SalesComponent = salesComponent;
            DataContext = SalesComponent;
        }
    }
}
