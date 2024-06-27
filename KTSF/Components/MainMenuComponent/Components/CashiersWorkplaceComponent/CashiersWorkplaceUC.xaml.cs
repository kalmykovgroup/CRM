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

namespace KTSF.Components.MainMenuComponent.Components.CashiersWorkplaceComponent
{
    /// <summary>
    /// Логика взаимодействия для CashiersWorkplaceUC.xaml
    /// </summary>
    public partial class CashiersWorkplaceUC : UserControl //MainMenu -> Рабочее место кассира
    {
        public CashiersWorkplaceVM CashiersWorkplaceVM { get; }
        public CashiersWorkplaceUC(CashiersWorkplaceVM cashiersWorkplaceVM)
        {
            CashiersWorkplaceVM = cashiersWorkplaceVM;
            DataContext = cashiersWorkplaceVM;
            InitializeComponent();
        }
    }
}
