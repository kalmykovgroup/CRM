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
        public ObservableCollection<User> Users { get; } = new ObservableCollection<User>();

        public StaffComponent(UserControlVM binding, AppControl appControl) : base(binding, appControl)
        {
        }

        public override UserControl Initial() => new StaffUC(this);

        public async override void ComponentLoaded()
        {
            IsLoad = "Загрузка пользователей";

            await Load();

            IsLoad = null;
        }

        public async Task Load()
        {
            List<User> users = await AppControl.Server.GetUsers(); 

            foreach (User user in users) {
                Users.Add(user);
            }
             
        }



    }
}
