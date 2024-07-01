using KTSF.Components.MainMenuComponent.Components.AdministrationComponent.Components.UsersPageComponents.Components.AddUserComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KTSF.Components.MainMenuComponent.Components.AdministrationComponent.Components.UsersPageComponents.Components.EditUserComponent
{
    /// <summary>
    /// Логика взаимодействия для EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        public EditUserVM EditUserVM { get; }
        public EditUserWindow(EditUserVM editUserVM)
        {
            InitializeComponent();
            EditUserVM = editUserVM;
            DataContext = EditUserVM;
        }
    }
}
