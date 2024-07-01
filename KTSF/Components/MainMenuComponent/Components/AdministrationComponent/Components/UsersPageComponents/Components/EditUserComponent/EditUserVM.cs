using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KTSF.Components.MainMenuComponent.Components.AdministrationComponent.Components.UsersPageComponents.Components.AddUserComponent;
using KTSFClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Components.MainMenuComponent.Components.AdministrationComponent.Components.UsersPageComponents.Components.EditUserComponent
{
    public partial class EditUserVM : ObservableObject
    {
        public AppControl AppControl { get; }

        public EditUserWindow? EditUserWindow { get; private set; }

        private User? User { get; set; }


        public EditUserVM(AppControl appControl)
        {
            AppControl = appControl;
        }

        public bool Run(User user)
        {
            User = user;

            EditUserWindow = new EditUserWindow(this);

            return EditUserWindow.ShowDialog() == true;          
        }

        #region Commands

        [RelayCommand]
        public void SaveUserClick()
        {
            (EditUserWindow ?? throw new ArgumentNullException()).DialogResult = true;
        }
        [RelayCommand]
        public void CancelClick()
        {
            (EditUserWindow ?? throw new ArgumentNullException()).DialogResult = false;
        }
        #endregion
    }
}
