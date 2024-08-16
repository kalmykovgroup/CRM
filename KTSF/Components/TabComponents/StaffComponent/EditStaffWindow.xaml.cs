using KTSF.Core;
using KTSF.Core.ABAC;
using KTSF.Dto.Employee_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KTSF
{
    /// <summary>
    /// Логика взаимодействия для EditStaffWindow.xaml
    /// </summary>
    public partial class EditStaffWindow : Window
    {
        public EmployeeVM EmployeeVM { get; }

        //public List<Appointment> Appointment { get; } = [];
        //public List<EmployeeStatus> EmployeeStatuses { get; } = [];
        //public List<ASetOfRules> ASetOfRules { get; } = [];

        private Action<EditStaffWindow> Action { get; }

        private Regex nameRegex = new(@"[A-ZА-Я]{1}[a-zа-я]+"); // имя фамилия отчество
        private Regex passportSeriesRegex = new(@"\d{4}");
        private Regex passportNumberRegex = new(@"\d{6}");
        private Regex innNumberRegex = new(@"\d{12}");
        private Regex snilsRegex = new(@"\d{11}");
        private Regex phoneNumberRegex = new(@"(\+7|8)[\(\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[)\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)");
        private Regex emailRegex = new(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*\.\w{2,3}$");

        

        public EditStaffWindow(EmployeeVM employeeVM,Action<EditStaffWindow> action)
        {
            InitializeComponent();

            this.EmployeeVM = employeeVM;       
            this.Action = action;

            this.DataContext = EmployeeVM;            
        }

        private void saveButtonButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeVM.Employee.Updated_At = DateTime.Now;
            Action.Invoke(this);
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void positionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Appointment appointment = (Appointment)positionComboBox.SelectedItem;
            EmployeeVM.Employee.AppointmentId = appointment.Id;
            EmployeeVM.Employee.Appointment = appointment;
        }

        private void statusComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EmployeeStatus employeeStatus = (EmployeeStatus)statusComboBox.SelectedItem;
            EmployeeVM.Employee.EmployeeStatusId = employeeStatus.Id;
            EmployeeVM.Employee.EmployeeStatus = employeeStatus;
        }

        private void permissionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ASetOfRules setOfRules = (ASetOfRules)permissionComboBox.SelectedItem;
            EmployeeVM.Employee.ASetOfRulesId = setOfRules.Id;
            EmployeeVM.Employee.ASetOfRules = setOfRules;
        }
    }
}
