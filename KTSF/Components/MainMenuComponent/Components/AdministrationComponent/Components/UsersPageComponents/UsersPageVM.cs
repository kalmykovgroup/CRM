using KTSF.Components.MainMenuComponent.Components.AdministrationComponent.Components.StatisticsPageComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.MainMenuComponent.Components.AdministrationComponent.Components.UsersPageComponents
{
    public class UsersPageVM : IComponent //MainMenuVM -> AdministrationVM -> UsersPageVM
    {
        public AppControl AppControl { get; }

        public UsersPageUC? UsersUC { get; private set; }

        public UserControl Build => UsersUC ?? Create();

        public UserControl Create()
        {
            UsersUC = new UsersPageUC(this);

            return UsersUC;
        }

        public UsersPageVM(AppControl appControl)
        {
            AppControl = appControl;
        }
    }
}
