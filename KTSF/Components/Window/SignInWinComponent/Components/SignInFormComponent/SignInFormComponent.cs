﻿using CommunityToolkit.Mvvm.Input;
using KTSF.Components.Window.SignInPageComponent;
using KTSF.ViewModel;
using KTSFClassLibrary;
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

        public SignInFormComponent(UserControlVM binding, AppControl appControl): base(binding, appControl) {}



        public override UserControl Initial() =>  new SignInFormUC(this);

 

        #region Commands

        public Action<object?>? SignInClickAction;

        [RelayCommand]
        public void SignInClick(object? parameter) => SignInClickAction?.Invoke(parameter);



        #endregion
    }
}
