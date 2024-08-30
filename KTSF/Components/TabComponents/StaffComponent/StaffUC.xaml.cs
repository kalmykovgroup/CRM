using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace KTSF.Components.TabComponents.StaffComponent
{
    public partial class StaffUC : UserControl
    {

        public StaffUC(StaffComponent StaffComponent)
        {
            InitializeComponent();
            DataContext = StaffComponent;
        }

        //private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e) =>
        //    StaffComponent.Selector_OnSelectionChanged(sender, e);
    }
}
