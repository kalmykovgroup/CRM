using CommunityToolkit.Mvvm.Input;
using KTSF.Components.CommonComponents.SignInFormComponent;
using KTSF.ViewModel;
using KTSFClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.SignInPageComponent.Components.AuthFormComponent
{
    public partial class AuthFormComponent : Component
    {

        public AuthFormComponent(UserControlVM binding, AppControl appControl) : base(binding, appControl){}
 
        public override UserControl Initial() => new AuthFormUC(this);

        #region Commands

        public Action<object?>? AuthClickAction;

        [RelayCommand]
        public void AuthClick(object? parameter) => AuthClickAction?.Invoke(parameter);

        #endregion
    }
}
