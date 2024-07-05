using KTSF.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.MainMenuComponent
{
    public partial class MainMenuComponent : Component
    {
        #region Navigate

        ObservableCollection<Component> Components { get; } = new();

        #endregion

        public MainMenuComponent(UserControlVM binding, AppControl appControl) : base(binding, appControl)
        {
        }

        public override Component FactoryMethod(UserControlVM binding, AppControl appControl, object? data)
         => new MainMenuComponent(binding, appControl);

        public override UserControl Initial() => new MainMenuUC(this);
    }
}
