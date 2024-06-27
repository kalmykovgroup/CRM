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

<<<<<<< HEAD:KTSF/Components/LoadComponent/LoadUC.xaml.cs
namespace KTSF.Components.LoadComponent
{
    /// <summary>
    /// Логика взаимодействия для LoadUC.xaml
    /// </summary>
    public partial class LoadUC : UserControl
    {
        public LoadVM LoadVM { get; }

        public LoadUC(LoadVM loadVM)
        {
            LoadVM = loadVM;
            DataContext = loadVM;
=======
namespace KTSF.Components.MainMenuComponent.Components.WarehouseComponent
{
    /// <summary>
    /// Логика взаимодействия для WarehouseUC.xaml
    /// </summary>
    public partial class WarehouseUC : UserControl
    {
        public WarehouseVM WarehouseVM { get; }
        public WarehouseUC(WarehouseVM warehouseVM)
        {
            WarehouseVM = warehouseVM;
            DataContext = warehouseVM;
>>>>>>> Добавил Главное меню и подключил навигацию:KTSF/Components/MainMenuComponent/Components/WarehouseComponent/WarehouseUC.xaml.cs
            InitializeComponent();


        }
    }
}
