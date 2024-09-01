
using KTSF.Core.Object;
using KTSF.Core.Object.ABAC;
using KTSF.Dto.Employee_;
using System.Windows;

namespace KTSF
{
    public partial class AddNewStaffWindow : Window
    {        
        private EmployeeVM EmployeeVM { get; set; }

        public AddNewStaffWindow(EmployeeVM employeeVM)
        {
            InitializeComponent();
            
            this.EmployeeVM = employeeVM;
            DataContext = EmployeeVM;
        }

        private void saveButtonButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeVM.Employee.Created_At = DateTime.Now;
            EmployeeVM.Employee.Updated_At = DateTime.Now;

            EmployeeVM.Employee.Password = "tester"; // жесткий хардкод
            EmployeeVM.Employee.JwtToken = ""; // жесткий хардкод          

            DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {    
            DialogResult = false;
        }

        private void positionComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Appointment appointment = (Appointment)positionComboBox.SelectedItem;
            EmployeeVM.Employee.AppointmentId = appointment.Id;
            EmployeeVM.Employee.Appointment = appointment;
        }

        private void statusComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            EmployeeStatus employeeStatus = (EmployeeStatus)statusComboBox.SelectedItem;
            EmployeeVM.Employee.EmployeeStatusId = employeeStatus.Id;
            EmployeeVM.Employee.EmployeeStatus = employeeStatus;
        }

        private void permissionComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ASetOfRules setOfRules = (ASetOfRules)permissionComboBox.SelectedItem;
            EmployeeVM.Employee.ASetOfRulesId = setOfRules.Id;
            EmployeeVM.Employee.ASetOfRules = setOfRules;
        }
    }
}
