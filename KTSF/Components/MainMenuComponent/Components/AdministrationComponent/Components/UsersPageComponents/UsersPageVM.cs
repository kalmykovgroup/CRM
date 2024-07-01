using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KTSF.Components.MainMenuComponent.Components.AdministrationComponent.Components.StatisticsPageComponent;
using KTSF.Components.MainMenuComponent.Components.AdministrationComponent.Components.UsersPageComponents.Components.AddUserComponent;
using KTSF.Components.MainMenuComponent.Components.AdministrationComponent.Components.UsersPageComponents.Components.EditUserComponent;
using KTSFClassLibrary;
using KTSFClassLibrary.Product_;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KTSF.Components.MainMenuComponent.Components.AdministrationComponent.Components.UsersPageComponents
{
    public partial class UsersPageVM : ObservableObject, IComponent //MainMenuVM -> AdministrationVM -> UsersPageVM
    {
        public AppControl AppControl { get; }

        public UsersPageUC? UsersUC { get; private set; }

        [ObservableProperty] private string? isLoad;

        public AddUserVM? AddUserVM { get; private set; }
        public EditUserVM? EditUserVM { get; private set; }

        public ObservableCollection<User> Users { get; } = new();

        public UserControl Build => UsersUC ?? Create();

        public UserControl Create()
        {
            AddUserVM = new AddUserVM(AppControl);
            EditUserVM = new EditUserVM(AppControl);

            UsersUC = new UsersPageUC(this);
            UsersLoad();
            return UsersUC;
        }

        public UsersPageVM(AppControl appControl)
        {
            AppControl = appControl;
        }

        public async void UsersLoad()
        {
            IsLoad = "";

            List<User> list = await AppControl.Server.GetUsers();

            foreach (User user in list)
            {
                Users.Add(user);
            }

            IsLoad = null;
        }
        #region

        [RelayCommand] public void AddUserClick(object? parametr)
        { 
            if (AddUserVM?.Run(out User user) == true) 
            {
                //Пользователь успешно создан в базе и вернулся нам
                //Далее его нужно добавить в массив пользователей 
            }
        }
        
        [RelayCommand] public void EditUserClick(object? parametr)
        {
            if (parametr is null) throw new ArgumentNullException(nameof(User));
             
            User user = (User)parametr;

            EditUserVM?.Run(user); //Запустить окно редактирования
        }
        
        [RelayCommand] public async void DeleteUserClick(object? parametr)
        {
            if (parametr is null) throw new ArgumentNullException(nameof(User));

            User user = (User)parametr;

            IsLoad = "";

            (bool result, string? message) = await AppControl.Server.DeleteUser(user);

            IsLoad = null;
            if (result)
            {
                Users.Remove(user);
            }
            else
            {
                MessageBox.Show(message);
            } 
        }

        #endregion
    }
}
