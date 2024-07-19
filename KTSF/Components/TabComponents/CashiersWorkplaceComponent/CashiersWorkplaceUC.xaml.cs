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

namespace KTSF.Components.TabComponents.CashiersWorkplaceComponent
{
    /// <summary>
    /// Логика взаимодействия для CashiersWorkplaceUC.xaml
    /// </summary>
    public partial class CashiersWorkplaceUC : UserControl
    {
        public CashiersWorkplaceComponent CashiersWorkplaceComponent { get; }
        public CashiersWorkplaceUC(CashiersWorkplaceComponent cashiersWorkplaceComponent)
        {
            InitializeComponent();
            CashiersWorkplaceComponent = cashiersWorkplaceComponent;
            DataContext = CashiersWorkplaceComponent;
        }

        private void textBoxCountProduct_KeyDown (object sender, KeyEventArgs e) => CashiersWorkplaceComponent.textBoxCountProduct_KeyDown(sender, e);

        //private void TextBox_LostFocus (object sender, RoutedEventArgs e) => TextBox_LostFocus(sender, e);
        private void TextBox_LostFocus (object sender, RoutedEventArgs e) {
            CashiersWorkplaceComponent.UpdateTotalSumCheck();
        }
    }
}
