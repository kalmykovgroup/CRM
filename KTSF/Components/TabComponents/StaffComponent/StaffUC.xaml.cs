using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using KTSF.Components.CommonComponents.EmployeeSearchComponent;


namespace KTSF.Components.TabComponents.StaffComponent
{
    public partial class StaffUC : UserControl
    {        
        public StaffComponent StaffComponent { get; }
        public StaffUC(StaffComponent staffComponent)
        {
            InitializeComponent();
            DataContext = StaffComponent;           
        }       
            StaffComponent = staffComponent;
            DataContext = StaffComponent;
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e) =>
            StaffComponent.Selector_OnSelectionChanged(sender, e);
    }
}
