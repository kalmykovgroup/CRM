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

namespace KTSF.Components.MainMenuComponent.Components.WarehousePageComponent.Components.AcceptancePoductsPageComponent
{
    /// <summary>
    /// Логика взаимодействия для AcceptancePoductsPageUC.xaml
    /// </summary>
    public partial class AcceptancePoductsPageUC : UserControl
    {
        public AcceptancePoductsPageVM AcceptancePoductsPageVM { get; }
        public AcceptancePoductsPageUC(AcceptancePoductsPageVM acceptancePoductsPageVM)
        {
            InitializeComponent();
            AcceptancePoductsPageVM = acceptancePoductsPageVM;
            DataContext = AcceptancePoductsPageVM;
        }
    }
}
