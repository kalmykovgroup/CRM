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
using System.Windows.Shapes;

namespace KTSF.Components.CommonComponents.EmployeeSearchComponent
{   

    public partial class EmployeeSearchUC : UserControl
    {
        public EmployeeSearchComponent EmployeeSearchComponent { get; }

        public EmployeeSearchUC(EmployeeSearchComponent employeeSearchComponent)
        {
            InitializeComponent();
            EmployeeSearchComponent = employeeSearchComponent;
            this.DataContext = EmployeeSearchComponent;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) => EmployeeSearchComponent.TextBox_TextChanged(sender, e);
    }
}
