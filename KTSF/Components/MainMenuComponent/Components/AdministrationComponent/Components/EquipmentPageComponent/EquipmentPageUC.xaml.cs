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

namespace KTSF.Components.MainMenuComponent.Components.AdministrationComponent.Components.EquipmentPageComponent
{
    /// <summary>
    /// Логика взаимодействия для EquipmentPageUC.xaml
    /// </summary>
    public partial class EquipmentPageUC : UserControl
    {
        public EquipmentPageVM EquipmentPageVM { get; }

        public EquipmentPageUC(EquipmentPageVM equipmentPageVM)
        {
            InitializeComponent();
            EquipmentPageVM = equipmentPageVM;
            DataContext = equipmentPageVM;
        }
    }
}
