using CommunityToolkit.Mvvm.Input;
using KTSF.Components.Window.SignInPageComponent;
using KTSF.ViewModel;
using KTSF.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.CommonComponents.SignInFormComponent
{
    public partial class SignInFormComponent : Component
    {
        public User User { get; set; }
         
        public SignInFormComponent(User user, UserControlVM binding, AppControl appControl): base(binding, appControl) {
            User = user;
        }



        public override UserControl Initial() =>  new SignInFormUC(this);

 

        #region Commands

        public Action<object?>? SignInClickAction;

        [RelayCommand]
        public void SignInClick(object? parameter) => SignInClickAction?.Invoke(parameter);



        #endregion
    }
}
