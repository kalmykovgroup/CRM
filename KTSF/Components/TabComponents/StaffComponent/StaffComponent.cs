using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KTSF.Components.CommonComponents.SearchComponent;
using KTSF.ViewModel;  
using System.Collections.ObjectModel; 
using System.Windows;
using System.Windows.Controls;
using KTSF.Dto.Employee_;
using KTSF.Core.Object;
using KTSF.Core.Object.ABAC;
using System.Net;
using CSharpFunctionalExtensions;


namespace KTSF.Components.TabComponents.StaffComponent
{    
    public partial class StaffComponent : TabComponent
    {
        public ObservableCollection<Employee> Employees { get; } = [];
        public ObservableCollection<Employee> FiredEmployees { get; } = [];
        public ObservableCollection<Employee> QualifyingEmployees { get; } = [];
        public ObservableCollection<Employee> NotEmployedEmployees { get; } = [];               

        public EmployeeVM EmployeeVM { get; } = new EmployeeVM();         

        public Component SearchComponent { get; }
        public Component SearchComponentFired { get; }

        [ObservableProperty]
        public bool isLoaded = false;      
      

        public StaffComponent(UserControlVM binding, AppControl appControl, string iconPath) : base(binding, appControl, iconPath)
        {
            SearchComponent = new SearchComponent(binding, appControl);
            SearchComponentFired = new SearchComponent(binding, appControl);
        }

        public override UserControl Initial() => new StaffUC(this);

        public async override void ComponentLoaded()
        {           
            IsLoad = "Загрузка пользователей";

            await Load();

            IsLoad = null;
            IsLoaded = true;
        }

        

        public async Task Load()
        {
            CreateEmployeeLists();

            Result< List<Appointment>, (string? Message, HttpStatusCode)> resultAppointment = await AppControl.Server.GetAllAppointment();


            if (resultAppointment.IsFailure)
            {
                //MessageBox.Show(resultAppointment.Error.Message);
                AppControl.MessageInfoComponent.MessageShow("Ошибка", resultAppointment.Error.Message);
                return;
            }

            foreach(Appointment appointment in resultAppointment.Value)
            {
                EmployeeVM.Appointments.Add(appointment);
                //Appointments.Add(appointment);
            }

            Result<List<EmployeeStatus>, (string? Message, HttpStatusCode)> resultEmployeeStatus = await AppControl.Server.GetAllEmployeeStatus();

            if (resultEmployeeStatus.IsFailure)
            {
                //MessageBox.Show(resultEmployeeStatus.Error.Message);
                AppControl.MessageInfoComponent.MessageShow("Ошибка", resultAppointment.Error.Message);
                return;
            }

            foreach (EmployeeStatus employeeStatus in resultEmployeeStatus.Value)
            {
                EmployeeVM.EmployeeStatuses.Add(employeeStatus);
                //EmployeeStatuses.Add(employeeStatus);
            }


            Result<List<ASetOfRules>, (string? Message, HttpStatusCode)> resultASetOfRules = await AppControl.Server.GetAllASetOfRules();

            if (resultASetOfRules.IsFailure)
            {
                //MessageBox.Show(resultASetOfRules.Error.Message);
                AppControl.MessageInfoComponent.MessageShow("Ошибка", resultAppointment.Error.Message);
                return;
            }

            foreach (ASetOfRules aSetOfRule in resultASetOfRules.Value)
            {
                EmployeeVM.ASetOfRules.Add(aSetOfRule);
                //ASetOfRules.Add(aSetOfRule);
            }
        }
     

        [RelayCommand]
        public async void AddNewEmployee()
        {
            EmployeeVM.Employee = new Employee();

            AddNewStaffWindow userWindow = new AddNewStaffWindow(EmployeeVM, AppControl);

            if (userWindow.ShowDialog() == true)
            {
                Employee employee = await AppControl.Server.CreateEmployee(EmployeeVM.Employee);

                CreateEmployeeLists();
            }
        }
         

        [RelayCommand]
        public void EditEmployee(object sender)
        {
            EmployeeVM.Employee = ((Employee)sender).Copy();            
             
            EmployeeVM.Employee.Appointment = EmployeeVM.Appointments
                        .Where(app => app.Name == EmployeeVM.Employee.Appointment.Name)
                        .First();

            EmployeeVM.Employee.EmployeeStatus = EmployeeVM.EmployeeStatuses
                        .Where(empl => empl.Name == EmployeeVM.Employee.EmployeeStatus.Name)
                        .First();

            EmployeeVM.Employee.ASetOfRules = EmployeeVM.ASetOfRules
                        .Where(aset => aset.Name == EmployeeVM.Employee.ASetOfRules.Name)
                        .First();

            EditStaffWindow editStaffWindow = new EditStaffWindow(EmployeeVM,EditStaffWindowSaveClick, AppControl); // передавать копию??

            editStaffWindow.ShowDialog();
        
        }

        private async void EditStaffWindowSaveClick(EditStaffWindow editStaffWindow)
        {
            editStaffWindow.EmployeeVM.Employee.Updated_At = DateTime.Now;

            if (editStaffWindow.EmployeeVM.Employee.EmployeeStatus.Name == "Уволен")
            {
                editStaffWindow.EmployeeVM.Employee.LayoffDate = DateTime.Now;
            }

            (bool result, string? message, Employee copyEmployee) = await AppControl.Server.UpdateEmployee(editStaffWindow.EmployeeVM.Employee);

            if (result)
            {   
                CreateEmployeeLists();

                editStaffWindow.DialogResult = true;
            }
            else
            {
                //MessageBox.Show(message);
                AppControl.MessageInfoComponent.MessageShow("Ошибка", message);
            }
        }     


        private async void CreateEmployeeLists()
        {
            Result<List<Employee>, (string? Message, HttpStatusCode)> result = await AppControl.Server.GetEmployees();

            if (result.IsFailure)
            {
                //MessageBox.Show(result.Error.Message);
                AppControl.MessageInfoComponent.MessageShow("Ошибка", result.Error.Message);
                return;
            }
             

            Employees.Clear();
            FiredEmployees.Clear();
            QualifyingEmployees.Clear();
            NotEmployedEmployees.Clear();

            foreach (Employee employee in result.Value)
            {

                if (employee.EmployeeStatus.Name == "Трудоустроен") // работает
                {
                    Employees.Add(employee);
                }
                else if (employee.EmployeeStatus.Name == "Уволен") // уволен
                {
                    FiredEmployees.Add(employee);
                }
                else if (employee.EmployeeStatus.Name == "На испытательном сроке")
                {
                    QualifyingEmployees.Add(employee);
                }
                else if (employee.EmployeeStatus.Name == "Не трудоустроен")
                {
                    NotEmployedEmployees.Add(employee);
                }
            }
        }


    }
}
