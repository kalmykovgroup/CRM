using KTSF.Components.MainMenuComponent.Components.AdministrationComponent.Components.UsersPageComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.MainMenuComponent.Components.AdministrationComponent.Components.EquipmentPageComponent
{
    public class EquipmentPageVM : IComponent //MainMenuVM -> AdministrationVM -> EquipmentPageVM
    {
        public AppControl AppControl { get; }

        public EquipmentPageUC? EquipmentPageUC { get; private set; }

        public UserControl Build => EquipmentPageUC ?? Create();

        public UserControl Create()
        {
            EquipmentPageUC = new EquipmentPageUC(this);

            return EquipmentPageUC;
        }

        public EquipmentPageVM(AppControl appControl)
        {
            AppControl = appControl;
        }
    }
}
