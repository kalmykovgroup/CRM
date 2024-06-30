using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.MainMenuComponent.Components.AdministrationComponent.Components.StatisticsPageComponent
{
    public class StatisticsPageVM : IComponent //MainMenuVM -> AdministrationVM -> StatisticsPageVM
    {
        public AppControl AppControl { get; }

        public StatisticsPageUC? StatisticsUC { get; private set; }

        public UserControl Build => StatisticsUC ?? Create();

        public UserControl Create()
        {
            StatisticsUC = new StatisticsPageUC(this);

            return StatisticsUC;
        }

        public StatisticsPageVM(AppControl appControl)
        {
            AppControl = appControl;
        }
    }
}
