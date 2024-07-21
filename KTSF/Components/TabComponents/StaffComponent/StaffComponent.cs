using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KTSF.Components.CommonComponents.SearchComponent;
using KTSF.ViewModel;
using KTSFClassLibrary;
using KTSFClassLibrary.ABAC;
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
        public ObservableCollection<Employee> FiredEmployees { get; } = new ObservableCollection<Employee>();

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
            List<Employee> users = await AppControl.Server.GetUsers();

            foreach (Employee user in users) {
                Employees.Add(user);
            }

            List<Employee> firedUsers = await AppControl.Server.GetFiredUsers();

            foreach (Employee user in firedUsers)
            {
                FiredEmployees.Add(user);
            }
        }      

        [RelayCommand]
        public void AddNewUser()
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
        public void EditUser(object sender)
        {
            Employee employee = (Employee)sender;

            List<Employee> copyEmployees = new List<Employee> ();

            foreach (Employee us in Employees)
            {
                copyEmployees.Add(
                    new Employee()
                    {
                        Id = us.Id,
                        Name = us.Name,
                        Surname = us.Surname,
                        Patronymic = us.Patronymic,
                        PassportSeries = us.PassportSeries,
                        PassportNumber = us.PassportNumber,
                        Tin = us.Tin,
                        Snils = us.Snils,
                        Appointment = us.Appointment,
                        Address = us.Address,
                        Phone = us.Phone,
                        Email = us.Email,
                        ApplyingDate = us.ApplyingDate,
                        IsFired = us.IsFired,
                        Updated_At = us.Updated_At
                    });
            }

            EditStaffWindow userWindow = new EditStaffWindow(employee); // передавать копию??

            if (userWindow.ShowDialog() == true)
            {
                employee.Updated_At = DateTime.Now;

                copyEmployees.Clear();
                copyEmployees = Employees.ToList();
                Employees.Clear();
                foreach (Employee copyEmp in copyEmployees)
                {
                    Employees.Add(copyEmp);
                }

                AppControl.Server.UpdateUser(employee);

                // в реале -> запрос на сервер, для сохранения в БД
                // если Employee.LayoffDate != null -> перемещать в другую таблицу ??
            }
            else
            {
                Employees.Clear();
                foreach (Employee copyEmp in copyEmployees)
                {
                    Employees.Add(copyEmp);
                }
            }
        }

        [RelayCommand]
        public async Task<bool> DeleteUser(object sender)
        {
            Employee employee = (Employee)sender;
            employee.IsFired = true;
            employee.Updated_At = DateTime.Now;
            employee.LayoffDate = DateTime.Now;

            Employees.Remove(employee);
            FiredEmployees.Add(employee);

            // на сервер -> удаление Юзера
            // с сервера -> список активных изеров
            // с сервера -> список уволенных изеров
            await AppControl.Server?.DeleteUser(employee);

            // ждеем ответ

            return true;
        }

      

    }
}
