using KTSF.Components.MainMenuComponent.Components.AdministrationComponent.Components.UsersPageComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.MainMenuComponent.Components.AdministrationComponent.Components.ActionsPageComponent
{
    public class ActionsPageVM : IComponent //MainMenuVM -> AdministrationVM -> ActionsPageVM
    {
        public AppControl AppControl { get; }

        public ActionsPageUC? ActionsUC { get; private set; }

        public UserControl Build => ActionsUC ?? Create();

        public UserControl Create()
        {
            ActionsUC = new ActionsPageUC(this);

            return ActionsUC;
        }

        public ActionsPageVM(AppControl appControl)
        {
            AppControl = appControl;
        }
    }
}
