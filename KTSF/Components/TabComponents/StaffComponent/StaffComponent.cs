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
            
            int index = Users.IndexOf(user);

            EditStaffWindow userWindow = new EditStaffWindow(user);
            if (userWindow.ShowDialog() == true)
            {
                Users.RemoveAt(index);
                Users.Add(user);         
                
                AppControl.Server.UpdateUser(user); 

                // в реале -> запрос на сервер, для сохранения в БД
                // если User.LayoffDate != null -> перемещать в другую таблицу ??
            }
        }

        [RelayCommand]
        public void DeleteUser(object sender)
        {
            User user = (User)sender;

            MessageBox.Show("Delete");
            MessageBox.Show(user.Surname);

            AppControl.Server?.DeleteUser(user);
        }

      

    }
}
