﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.MainMenuComponent.Components.CashiersWorkplaceComponent
{
    public class CashiersWorkplaceVM : IComponent //MainMenu -> CashiersWorkplaceVM
    {
        public AppControl AppControl { get; }
        public MainMenuVM MainMenuVM { get; }

        public UserControl UserControl { get; }

        public void Run() => MainMenuVM.CurrentView = UserControl;

        public CashiersWorkplaceVM(AppControl appControl, MainMenuVM mainMenuVM)
        {
            AppControl = appControl;
            MainMenuVM = mainMenuVM;
            UserControl = new CashiersWorkplaceUC(this);
        }
    }
}
