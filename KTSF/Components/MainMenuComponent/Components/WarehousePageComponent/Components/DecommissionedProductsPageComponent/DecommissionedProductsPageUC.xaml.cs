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

namespace KTSF.Components.MainMenuComponent.Components.WarehousePageComponent.Components.DecommissionedProductsPageComponent
{
    /// <summary>
    /// Логика взаимодействия для DecommissionedProductsPageUC.xaml
    /// </summary>
    public partial class DecommissionedProductsPageUC : UserControl
    {
        public DecommissionedProductsPageVM DecommissionedProductsPageVM { get; }
        public DecommissionedProductsPageUC(DecommissionedProductsPageVM decommissionedProductsPageVM)
        {
            InitializeComponent();
            DecommissionedProductsPageVM = decommissionedProductsPageVM;
            DataContext = DecommissionedProductsPageVM;
        }
    }
}
