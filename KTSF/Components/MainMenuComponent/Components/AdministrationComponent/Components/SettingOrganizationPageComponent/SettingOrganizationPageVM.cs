using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.MainMenuComponent.Components.AdministrationComponent.Components.SettingOrganizationPageComponent
{
    public class SettingOrganizationPageVM : IComponent //MainMenuVM -> AdministrationVM -> SettingOrganizationPageVM
    {
        public AppControl AppControl {  get; }

        public SettingOrganizationPageUC? SettingOrganizationUC { get; private set; }

        public UserControl Build => SettingOrganizationUC != null ? SettingOrganizationUC : Create();

        private UserControl Create()
        {
            SettingOrganizationUC = new SettingOrganizationPageUC();
            return SettingOrganizationUC;
        }

        public SettingOrganizationPageVM(AppControl appControl)
        {
            AppControl = appControl;
        }
    }
}
