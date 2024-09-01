 
using CommunityToolkit.Mvvm.ComponentModel;
using KTSF.Db; 
using KTSF.ViewModel; 
using KTSF.Components;  
using System.Configuration;
using System.Windows; 
using KTSF.Core.Language; 
using KTSF.Components.Windows.SignInUserWinComponent;
using KTSF.Components.Windows.MainMenuComponent;
using KTSF.Components.Windows.CompanyWinComponent;

using Object = KTSF.Core.App.Object;
using KTSF.Core.Object;
using KTSF.Core.App;
using KTSF.Components.Windows.SignInEmployeeWinComponent;
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

        [ObservableProperty] private string? isLoad;

        public Company? SelectedCompany { get; set; }
        public Object? SelectedObject { get; set; } 

        public LanguageControl LanguageControl { get; } = new();

        //Главное окно в котором отображаеться UserControl
        public MainWindow MainWindow { get; }

        //Текущее отображаемое окно
        public UserControlVM CurrentFrame { get; }

        private User? user;
        public User? User { get => user; set {

                Server.SetUserJwtToken(value?.JwtToken);

                user = value;

            }
        }

        private Employee? employee;
        public Employee? Employee
        {
            get => employee; set
            {

                Server.SetUserJwtToken(value?.JwtToken);

                employee = value;

            }
        }

        public Component SignInUserWinComponent { get; private set; }
        public Component SignInEmployeeWinComponent { get; private set; }
        public CompanyComponent CompanyComponent { get; private set; }
        public Component MainMenuComponent { get; private set; }
        
        public Server Server { get; }

        public AppControl(MainWindow mainWindow)
        { 
            MainWindow = mainWindow;

            Server = new Server(this);

            CurrentFrame = new UserControlVM();
             
            SignInUserWinComponent = new SignInUserWinComponent(CurrentFrame, this);
            SignInEmployeeWinComponent = new SignInEmployeeWinComponent(CurrentFrame, this);
            MainMenuComponent = new MainMenuWinComponent(CurrentFrame, this);
            CompanyComponent = new CompanyComponent(CurrentFrame, this);

            SignInUserWinComponent.Show();
        }

    



       



    }
}
