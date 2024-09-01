
using KTSF.Core.Object;
using KTSF.Core.Object.ABAC;
using KTSF.Dto.Employee_;
using System.ComponentModel;
using System.Windows;
using Component = KTSF.Components.Component;

namespace KTSF
{
    public partial class AddNewStaffWindow : Window, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        private dynamic? property;

        public dynamic? Property
        {
            get => property;
            set
            {
                property = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Property)));                
            }
        }



        public EmployeeVM EmployeeVM { get; set; }

        public AddNewStaffWindow(EmployeeVM employeeVM, AppControl appControl)
        {
            InitializeComponent();            
            this.EmployeeVM = employeeVM;

            Component.LoadLanguage(this.GetType(), appControl, (_property) => { Property = _property; });

            this.DataContext = this;
           
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
