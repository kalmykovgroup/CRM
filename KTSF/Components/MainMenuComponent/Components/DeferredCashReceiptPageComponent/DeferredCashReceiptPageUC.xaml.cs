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

namespace KTSF.Components.MainMenuComponent.Components.DeferredCashReceiptPageComponent
{
    /// <summary>
    /// Логика взаимодействия для DeferredCashReceiptPageUC.xaml
    /// </summary>
    public partial class DeferredCashReceiptPageUC : UserControl //Отложенные чеки
    {
        public DeferredCashReceiptPageVM DeferredCashReceiptPageVM { get; }
        public DeferredCashReceiptPageUC(DeferredCashReceiptPageVM deferredCashReceiptPageVM)
        {
            InitializeComponent();
            DeferredCashReceiptPageVM = deferredCashReceiptPageVM;
            DataContext = DeferredCashReceiptPageVM;
        }
    }
}
