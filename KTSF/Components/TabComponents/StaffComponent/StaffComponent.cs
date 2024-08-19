using CommunityToolkit.Mvvm.ComponentModel;
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

namespace KTSF.Components.TabComponents.StaffComponent
{    
    public partial class StaffComponent : TabComponent
    {
        public ObservableCollection<Employee> Employees { get; } = new ObservableCollection<Employee>(); 

        public Component SearchComponent { get; }
        public Component SearchComponentFired { get; }

        [ObservableProperty]
        public bool isLoaded = false;      
      

        public StaffComponent(UserControlVM binding, AppControl appControl) : base(binding, appControl)
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
            List<Employee> employees = await AppControl.Server.GetEmployees();

            foreach (Employee employee in employees) {
                Employees.Add(employee);
            }            
        }      

        [RelayCommand]
        public void AddNewEmployee()
        {
            Employee employee = new Employee();
            employee.Appointment = new Appointment();
            AddNewStaffWindow userWindow = new AddNewStaffWindow(employee);

            if (userWindow.ShowDialog() == true)
            {
                employee.Updated_At = DateTime.Now;               

                employee.Created_At = DateTime.Now; // ЭТО ПОЛЕ НУЖНО, ЕСЛИ ЕСТЬ ApplyingDate ???

                Employees.Add(employee); // тестовая версия

                // в реале -> запрос на сервер, для сохранения в БД
            }
        }
         

        [RelayCommand]
        public void EditEmployee(object sender)
        { 
            EditStaffWindow editStaffWindow = new EditStaffWindow(((Employee)sender).Copy(), EditStaffWindowSaveClick); // передавать копию??

            editStaffWindow.ShowDialog();
        
        }

        private async void EditStaffWindowSaveClick(EditStaffWindow editStaffWindow)
        {
            (bool result, string? message, Employee copyEmployee) = await AppControl.Server.UpdateEmployee(editStaffWindow.Employee);

            if (result)
            {
                Employee employee = Employees.First(employee => employee.Id == copyEmployee.Id);

                int i = Employees.IndexOf(employee);

                Employees[i] = copyEmployee; 
                 
                editStaffWindow.DialogResult = true;
            }
            else
            {
                MessageBox.Show(message);
            }
        }


        [RelayCommand]
        public async Task<bool> DeleteUser(object sender)
        {
            Employee employee = (Employee)sender; 
            employee.Updated_At = DateTime.Now;
            employee.LayoffDate = DateTime.Now;

            Employees.Remove(employee); 

            // на сервер -> удаление Юзера
            // с сервера -> список активных изеров
            // с сервера -> список уволенных изеров
          //  await AppControl.Server?.DeleteUser(employee);

            // ждеем ответ

            return true;
        }

      

    }
}
