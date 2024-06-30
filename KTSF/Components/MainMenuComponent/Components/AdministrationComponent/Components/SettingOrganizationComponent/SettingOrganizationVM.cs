using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.MainMenuComponent.Components.AdministrationComponent.Components.SettingOrganizationComponent
{
    public class SettingOrganizationVM : IComponent
    {
        public AppControl AppControl {  get; }

        public SettingOrganizationUC? SettingOrganizationUC { get; private set; }

        public UserControl Build => SettingOrganizationUC != null ? SettingOrganizationUC : Create();

        private UserControl Create()
        {
            SettingOrganizationUC = new SettingOrganizationUC();
            return SettingOrganizationUC;
        }

        public SettingOrganizationVM(AppControl appControl)
        {
            AppControl = appControl;
        }
    }
}
