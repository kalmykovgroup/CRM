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
        public ObservableCollection<User> Users { get; } = new ObservableCollection<User>();
        public ObservableCollection<User> FiredUsers { get; } = new ObservableCollection<User>();
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
            List<User> users = await AppControl.Server.GetUsers();

            foreach (User user in users) {
                Users.Add(user);
            }

            List<User> firedUsers = await AppControl.Server.GetFiredUsers();

            foreach (User user in firedUsers)
            {
                FiredUsers.Add(user);
            }
        }      

        [RelayCommand]
        public void AddNewUser()
        {
            User user = new User();
            AddNewStaffWindow userWindow = new AddNewStaffWindow(user);

            if (userWindow.ShowDialog() == true)
            {
                Users.Add(user); // тестовая версия

                // в реале -> запрос на сервер, для сохранения в БД
            }
        }

        [RelayCommand]
        public void EditUser(object sender)
        {
            User user = (User)sender;

            List<User> copyUsers = new List<User> ();

            foreach (User us in Users)
            {
                copyUsers.Add(
                    new User() {Id = us.Id, Name = us.Name, Surname = us.Surname, Patronymic = us.Patronymic,
                                PassportSeries = us.PassportSeries, PassportNumber = us.PassportNumber,
                                InnNumber = us.InnNumber, Snils = us.Snils, Position = us.Position, Address = us.Address,
                                PhoneNumber = us.PhoneNumber, Email = us.Email, ApplyingDate = us.ApplyingDate,
                                IsFired = us.IsFired});
            }

            EditStaffWindow userWindow = new EditStaffWindow(user); // передавать копию??
            if (userWindow.ShowDialog() == true)
            {
                copyUsers.Clear();
                copyUsers = Users.ToList();
                Users.Clear();
                foreach (User copyUser in copyUsers)
                {
                    Users.Add(copyUser);
                }

                AppControl.Server.UpdateUser(user);

                // в реале -> запрос на сервер, для сохранения в БД
                // если User.LayoffDate != null -> перемещать в другую таблицу ??
            }
            else
            {
                Users.Clear();
                foreach (User copyUser in copyUsers)
                {
                    Users.Add(copyUser);
                }
            }
        }

        [RelayCommand]
        public void DeleteUser(object sender)
        {
            User user = (User)sender;           
            user.IsFired = true;
            user.LayoffDate = DateTime.Now;

            Users.Remove(user);
            FiredUsers.Add(user);

            // на сервер -> удаление Юзера
            // с сервера -> список активных изеров
            // с сервера -> список уволенных изеров
            AppControl.Server?.DeleteUser(user);
        }

      

    }
}
