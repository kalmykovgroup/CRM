using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KTSF.Components.MainMenuComponent.Components.AdministrationComponent;
using KTSF.Components.MainMenuComponent.Components.CashiersWorkplaceComponent;
using KTSF.Components.MainMenuComponent.Components.WarehouseComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KTSF.Components.MainMenuComponent
{
    public partial class MainMenuVM : ObservableObject, IComponent
    {
        public AdministrationVM? AdministrationVM { get; private set; } //Админ панель
        public CashiersWorkplaceVM? CashiersWorkplaceVM { get; private set; } //Рабочее место кассира
        public WarehouseVM? WarehouseVM { get; private set; } //Склад

        public AppControl AppControl { get; }
        public MainMenuUC? MainMenuUC { get; private set; }
   

        [ObservableProperty]
        public UserControl? currentView; 

        public MainMenuVM(AppControl appControl)
        {
            AppControl = appControl;                  
        }

        public UserControl Build => MainMenuUC ?? Create(); 

        private UserControl Create()
        {
            MainMenuUC = new MainMenuUC(this);

            AdministrationVM = new AdministrationVM(AppControl);
            CashiersWorkplaceVM = new CashiersWorkplaceVM(AppControl);
            WarehouseVM = new WarehouseVM(AppControl);

            CurrentView = CashiersWorkplaceVM.Build; //Клик меню по умолчанию

            return MainMenuUC;
        } 

        #region

        [RelayCommand]
        public void CashiersWorkplaceClick(object? parametr) => CurrentView = CashiersWorkplaceVM?.Build;
               
        [RelayCommand]
        public void AdministrationVMClick(object? parametr) => CurrentView = AdministrationVM?.Build;

        [RelayCommand]
        public void WarehouseVMClick(object? parametr) => CurrentView = WarehouseVM?.Build;


        #endregion
    }
}
