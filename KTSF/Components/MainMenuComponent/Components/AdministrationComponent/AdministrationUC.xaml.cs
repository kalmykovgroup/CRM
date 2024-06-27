using KTSF.Components.MainMenuComponent.Components.CashiersWorkplaceComponent;
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

namespace KTSF.Components.MainMenuComponent.Components.AdministrationComponent
{
    /// <summary>
    /// Логика взаимодействия для AdministrationUC.xaml
    /// </summary>
    public partial class AdministrationUC : UserControl//MainMenuVM -> AdministrationVM
    {
        public AdministrationVM AdministrationVM { get; }
        public AdministrationUC(AdministrationVM administrationVM)
        {
            AdministrationVM = administrationVM;
            DataContext = administrationVM;
            InitializeComponent();
        }
    }
}
