using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace KTSF.Components.TabComponents.StaffComponent
{
    /// <summary>
    /// Логика взаимодействия для StaffUC.xaml
    /// </summary>
    public partial class StaffUC : UserControl
    {        
        public StaffComponent StaffComponent { get; }
        public StaffUC(StaffComponent staffComponent)
        {
            InitializeComponent();
            StaffComponent = staffComponent;
            DataContext = StaffComponent;
        }
    }
}
