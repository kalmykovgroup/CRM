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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KTSF.Components.MainMenuComponent.Components.AdministrationComponent.Components.UsersPageComponents
{
    /// <summary>
    /// Логика взаимодействия для UsersPageUC.xaml
    /// </summary>
    public partial class UsersPageUC : UserControl
    {
        public UsersPageVM UsersVM { get; }

        public UsersPageUC(UsersPageVM usersVM)
        {
            UsersVM = usersVM;
            DataContext = usersVM;
            InitializeComponent();
        }
    }
}
