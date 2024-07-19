using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KTSF.Components.CommonComponents.SearchComponent;
using KTSF.ViewModel;
using KTSFClassLibrary;
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

        [ObservableProperty]
        public bool isLoaded = false;
      
      

        public StaffComponent(UserControlVM binding, AppControl appControl) : base(binding, appControl)
        {
            SearchComponent = new SearchComponent(binding, appControl);
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
            List<Employee> users = await AppControl.Server.GetUsers();

            foreach (Employee user in users) {
                Employees.Add(user);
            }
        }      

        [RelayCommand]
        public void AddNewUser()
        {
            Employee user = new Employee();
            AddNewStaffWindow userWindow = new AddNewStaffWindow(user);

            if (userWindow.ShowDialog() == true)
            {
                Employees.Add(user); // тестовая версия

                // в реале -> запрос на сервер, для сохранения в БД
            }
        }

        [RelayCommand]
        public void EditUser(object sender)
        {
            Employee user = (Employee)sender;           
            
            int index = Employees.IndexOf(user);

            EditStaffWindow userWindow = new EditStaffWindow(user);
            if (userWindow.ShowDialog() == true)
            {
                Employees.RemoveAt(index);
                Employees.Add(user);         
                
                AppControl.Server.UpdateUser(user); 

                // в реале -> запрос на сервер, для сохранения в БД
                // если Employee.LayoffDate != null -> перемещать в другую таблицу ??
            }
        }

        [RelayCommand]
        public void DeleteUser(object sender)
        {
            Employee user = (Employee)sender;

            MessageBox.Show("Delete");
            MessageBox.Show(user.Surname);

            AppControl.Server?.DeleteUser(user);
        }

      

    }
}
