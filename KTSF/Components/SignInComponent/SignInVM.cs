using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Navigation; 
using System.Windows;
using KTSFClassLibrary;

namespace KTSF.Components.SignInComponent
{
    public partial class SignInVM : IComponent
    {
        public AppControl AppControl { get; }

        public SignIn SignIn { get; private set; }

        public SignInUC? SignInUC { get; private set; }

        public UserControl Build => SignInUC ?? Create();

        private UserControl Create()
        {

            SignInUC = new SignInUC(this);
            return SignInUC;
        }


        public SignInVM(AppControl appControl)
        {
            AppControl = appControl;

            SignIn = new SignIn(new User());


        }
 

        #region Commands

        [RelayCommand]
        public void SignInClick(object? parameter)
        {
            AppControl.NavMainMenuVM();
        }

        public void Run() => throw new NotImplementedException();
        



        #endregion

    }
}
