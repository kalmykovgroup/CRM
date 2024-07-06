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

namespace KTSF.Components.TabComponents.MoneyComponent
{
    /// <summary>
    /// Логика взаимодействия для MoneyUC.xaml
    /// </summary>
    public partial class MoneyUC : UserControl
    {
        public MoneyUC(MoneyComponent MoneyComponent)
        {
            InitializeComponent();
            DataContext = MoneyComponent;
        }
    }
}
