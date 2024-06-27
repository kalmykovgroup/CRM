using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Navigation; 
using System.Windows;

namespace KTSF.Components.SignInComponent
{
    public partial class SignInVM : IComponent
    {
        public AppControl AppControl { get; }

        public SignIn SignIn { get; } 
         

        public UserControl UserControl { get; }

        public SignInVM(SignIn signIn, AppControl appControl)
        {
            SignIn = signIn;

            AppControl = appControl; 
            UserControl = new SignInUC(this);
        }

      
        public void Run()
        { 
            AppControl.UserControl = UserControl;
        }

        #region Commands

        [RelayCommand]
        public void SignInClick(object? parameter)
        {
            AppControl.NavMainMenuVM();
        }

        #endregion

    }
}
