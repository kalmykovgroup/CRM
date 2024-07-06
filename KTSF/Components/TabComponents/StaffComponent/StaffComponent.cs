﻿using KTSF.ViewModel;
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
    public class StaffComponent : TabComponent
    {
        public ObservableCollection<User> Users { get; } = new();

        public StaffComponent(UserControlVM binding, AppControl appControl) : base(binding, appControl)
        {
        }

        public override UserControl Initial() => new StaffUC(this);

        //public override async void UserControl_Loaded(object sender, RoutedEventArgs e)
        //{
        //    IsLoad = "Загрузка пользователей";
        //    await Task.Delay(2000);
        //    IsLoad = null;
        //}      

        public async override  void ComponentLoaded()
        {
            IsLoad = "Загрузка пользователей";
           
            _ = await GetUserList();

            IsLoad = null;
        }

        public async Task<bool> GetUserList()
        {
            List<User> users = await AppControl.Server.GetUsers();
            foreach (User user in users)
            {
                Users.Add(user);
            }         
            
            return true;
        }

    }
}
