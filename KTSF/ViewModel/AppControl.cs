using KTSFClassLibrary;
using CommunityToolkit.Mvvm.ComponentModel;
using KTSF.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using KTSF.ViewModel;
using System.IO;
using KTSF.Components;
using KTSF.Components.LoadPageComponent;
using KTSF.Components.SignInPageComponent;
using KTSF.Components.MainMenuComponent;
using static KTSF.ViewModel.RegisterComponents;
using System.Configuration;
using System.Windows;
using System.Text.Json;
using System.Text.Json.Nodes;
using KTSFClassLibrary.Language;
using Microsoft.Win32;

namespace KTSF
{

    public partial class AppControl : ObservableObject
    {
        public static string CompanyName { get; } = String.Empty;
        public static string ProgramName { get; } = String.Empty; 
 
        static AppControl()
        {
                   
            try 
            {

                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0 || appSettings.Get("company_name") is null || appSettings.Get("program_name") is null)
                {
                    throw new ConfigurationErrorsException();
                }

                CompanyName = appSettings.Get("company_name")!;
                ProgramName = appSettings.Get("program_name")!; 
  
 
            }
            catch (ConfigurationErrorsException)
            {
                string message = "Настройте файл конфигурации! `App.config`";
                MessageBox.Show(message);
                throw new ArgumentNullException(message);
            }
        } 

        public Languages Languages { get; } = new();

        //Главное окно в котором отображаеться UserControl
        public MainWindow MainWindow { get; }

        //Текущее отображаемое окно
        public UserControlVM CurrentFrame { get; }

        public MainUser MainUser { get; set; } = new MainUser();
        public User User { get; set; } = new User();

        public Component LoadPageComponent { get; private set; }
        public Component SignInPageComponent { get; private set; }
        public Component MainMenuComponent { get; private set; }
        
        public Server Server { get; }

        public AppControl(MainWindow mainWindow)
        { 
            MainWindow = mainWindow;

            Server = new Server(this);

            CurrentFrame = new UserControlVM();

            LoadPageComponent = new LoadPageComponent(CurrentFrame, this);
            SignInPageComponent = new SignInPageComponent(CurrentFrame, this);
            MainMenuComponent = new MainMenuComponent(CurrentFrame, this);

            LoadPageComponent.Register();
            SignInPageComponent.Register();
            MainMenuComponent.Register();

            LoadPageComponent.Show();
        }





    }
}
