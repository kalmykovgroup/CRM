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
            CashiersWorkplaceComponent = cashiersWorkplaceComponent;
            DataContext = CashiersWorkplaceComponent;

            InitializeComponent();
          
        }

        private void textBox_KeyDown (object sender, KeyEventArgs e) => CashiersWorkplaceComponent.textBox_KeyDown(sender, e);

        private void TextBoxPrice_TextChanged (object sender, TextChangedEventArgs e) => CashiersWorkplaceComponent.TextBoxPrice_TextChanged (sender, e);
        
        private void TextBoxCount_TextChanged (object sender, TextChangedEventArgs e) => CashiersWorkplaceComponent.TextBoxCount_TextChanged (sender, e);

        private void UIElement_OnPreviewTextInput(object sender, TextCompositionEventArgs e) =>
            CashiersWorkplaceComponent.UIElement_OnPreviewTextInput(sender, e);

        private void UIElement_OnPreviewKeyDown(object sender, KeyEventArgs e) =>
            CashiersWorkplaceComponent.UIElement_OnPreviewKeyDown(sender, e);

        private void TextBoxCashOrCard_TextChanged(object sender, TextChangedEventArgs e) =>
            CashiersWorkplaceComponent.TextBoxCashOrCard_TextChanged(sender, e);
    }
}
