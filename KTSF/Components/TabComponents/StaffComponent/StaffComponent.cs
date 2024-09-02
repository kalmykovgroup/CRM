﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KTSF.Components.CommonComponents.SearchComponent;
using KTSF.ViewModel;
using KTSF.Core;
using KTSF.Core.ABAC;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using CSharpFunctionalExtensions;
using KTSF.Dto.Employee_;

namespace KTSF.Components.TabComponents.StaffComponent
{    
    public partial class StaffComponent : TabComponent
    {
        public ObservableCollection<Employee> AllEmployees { get; } = [];
        public ObservableCollection<Employee> Employees { get; } = [];
        public ObservableCollection<Employee> FiredEmployees { get; } = [];
        public ObservableCollection<Employee> QualifyingEmployees { get; } = [];
        public ObservableCollection<Employee> NotEmployedEmployees { get; } = [];
        public ObservableCollection<Employee> SerchedEmployees { get; set; } = [];

        //public List<Appointment> Appointments { get; } = [];
        //public List<EmployeeStatus> EmployeeStatuses { get; } = [];
        //public List<ASetOfRules> ASetOfRules { get; } = [];
        
        private TabItem SelectedTabItem { get; set; }
        
        public EmployeeVM EmployeeVM { get; } = new EmployeeVM();
        
        [ObservableProperty]
        public bool isLoaded = false;      
      

        public StaffComponent(UserControlVM binding, AppControl appControl, string iconPath) : base(binding, appControl, iconPath)
        {
        }

        private void SearchedEmployeeList(ObservableCollection<Employee> serchedList)
        {
            if (serchedList.Count == 0)
            {
                switch (SelectedTabItem.Tag)
                {
                    case "Трудоустроен":
                    {
                        var itemsControl = ((Grid)SelectedTabItem.Content).FindName("EmployeesItemsControl") as ItemsControl;
                        itemsControl.ItemsSource = Employees;
                        break;
                    }
                    case "Уволен":
                    {
                        ((ItemsControl)SelectedTabItem.Content).ItemsSource = FiredEmployees;
                        break;
                    }
                    case "На испытательном сроке":
                    {
                        ((ItemsControl)SelectedTabItem.Content).ItemsSource = QualifyingEmployees;
                        break;
                    }
                    case "Не трудоустроен":
                    {
                        ((ItemsControl)SelectedTabItem.Content).ItemsSource = NotEmployedEmployees;
                        break;
                    }
                }
            }
            else
            {
                SerchedEmployees = serchedList;
                var itemsControl = ((Grid)SelectedTabItem.Content).FindName("EmployeesItemsControl") as ItemsControl;
                itemsControl.ItemsSource = SerchedEmployees;
            }
            
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

            List<Appointment>? appointments = await AppControl.Server.GetAllAppointment();

            if (appointments == null)
                return;

            foreach(Appointment appointment in appointments)
            {
                EmployeeVM.Appointments.Add(appointment);
                //Appointments.Add(appointment);
            }

            List<EmployeeStatus> employeeStatuses = await AppControl.Server.GetAllEmployeeStatus();
            foreach (EmployeeStatus employeeStatus in employeeStatuses)
            {
                EmployeeVM.EmployeeStatuses.Add(employeeStatus);
                //EmployeeStatuses.Add(employeeStatus);
            }

            List<ASetOfRules> aSetOfRules = await AppControl.Server.GetAllASetOfRules();
            foreach (ASetOfRules aSetOfRule in aSetOfRules)
            {
                EmployeeVM.ASetOfRules.Add(aSetOfRule);
                //ASetOfRules.Add(aSetOfRule);
            }
        }

        // ?????????????????????????
        //[RelayCommand]
        //public async Task<bool> DeleteUser(object sender)
        //{
        //    Employee employee = (Employee)sender;
        //    employee.Updated_At = DateTime.Now;
        //    employee.LayoffDate = DateTime.Now;

        //    Employees.Remove(employee);

        //    return true;
        //}
        
        [RelayCommand]
        public async void AddNewEmployee()
        {
            EmployeeVM.Employee = new Employee();

            AddNewStaffWindow userWindow = new AddNewStaffWindow(EmployeeVM);

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

            EditStaffWindow editStaffWindow = new EditStaffWindow(EmployeeVM,             
                EditStaffWindowSaveClick); // передавать копию??

            editStaffWindow.ShowDialog();
        
        }

        private async void EditStaffWindowSaveClick(EditStaffWindow editStaffWindow)
        {
            editStaffWindow.EmployeeVM.Employee.Updated_At = DateTime.Now;

            (bool result, string? message, Employee copyEmployee) = await AppControl.Server.UpdateEmployee(editStaffWindow.EmployeeVM.Employee);

            if (result)
            {   
                CreateEmployeeLists();

                editStaffWindow.DialogResult = true;
            }
            else
            {
                MessageBox.Show(message);
            }
        }     


        private async void CreateEmployeeLists()
        {
            List<Employee>? employees = await AppControl.Server.GetEmployees();
            
            AllEmployees.Clear();
            Employees.Clear();
            FiredEmployees.Clear();
            QualifyingEmployees.Clear();
            NotEmployedEmployees.Clear();

            if (employees == null)
                return;
            
            foreach (Employee employee in employees)
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
                
                AllEmployees.Add(employee);
            }
        }


    }
}
