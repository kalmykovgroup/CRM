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

namespace KTSF.Components.Windows.CompanyWinComponent
{
    /// <summary>
    /// Логика взаимодействия для CompanyComponentUC.xaml
    /// </summary>
    public partial class CompanyComponentUC : UserControl
    {
        public CompanyComponentUC(CompanyComponent CompanyComponent)
        {
            InitializeComponent();
            DataContext = CompanyComponent;
        }
    }
}
