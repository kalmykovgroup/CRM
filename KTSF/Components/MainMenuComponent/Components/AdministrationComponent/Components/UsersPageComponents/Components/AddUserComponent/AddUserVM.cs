using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KTSFClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Components.MainMenuComponent.Components.AdministrationComponent.Components.UsersPageComponents.Components.AddUserComponent
{
    public partial class AddUserVM : ObservableObject
    {
        public AppControl AppControl { get; }

        public AddUserWindow? AddUserWindow { get; private set; }

        private User? User { get; set; }


        public AddUserVM(AppControl appControl)
        {
            AppControl = appControl;
        }

        public bool Run(out User user)
        {
            User = new User();
            user = User;

            AddUserWindow = new AddUserWindow(this);

            return AddUserWindow.ShowDialog() == true;
          
        }

        #region Commands

        [RelayCommand]
        public void SaveUserClick()
        {
            (AddUserWindow ?? throw new ArgumentNullException()).DialogResult = true;
        }
        [RelayCommand]
        public void CancelClick()
        {
            (AddUserWindow ?? throw new ArgumentNullException()).DialogResult = false;
        }
        #endregion
    }
}
