using CommunityToolkit.Mvvm.ComponentModel;
using KTSF.Components.ActivationComponent.Commands; 
using KTSF.Components.LoadComponent;
using KTSF.Components.SignInComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.ActivationComponent
{
    public partial class ActivationVM : ObservableObject, IComponent
    {
        
        public UserControl UserControl { get; }

        public ActivationUC ActivationUC { get; }
                 
        public ActivationCommands ActivationCommands { get; }

        public AppControl AppControl { get; }

        public ActivationVM(AppControl appControl)
        {
            AppControl = appControl;

            ActivationCommands = new ActivationCommands(this);

            ActivationUC = new ActivationUC(this);
            UserControl = ActivationUC;
        }
         

        public void Run() => AppControl.UserControl = UserControl;
           
    }
}
