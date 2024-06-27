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
        public AdministrationVM AdministrationVM { get; } //Админ панель
        public CashiersWorkplaceVM CashiersWorkplaceVM { get; } //Рабочее место кассира
        public WarehouseVM WarehouseVM { get; } //Склад

        public AppControl AppControl { get; }
        public UserControl UserControl { get; }

        [ObservableProperty]
        public UserControl currentView; 

        public MainMenuVM(AppControl appControl)
        {
            AppControl = appControl;
            UserControl = new MainMenuUC(this);

            AdministrationVM = new AdministrationVM(AppControl, this);
            CashiersWorkplaceVM = new CashiersWorkplaceVM(AppControl, this);
            WarehouseVM = new WarehouseVM(AppControl, this);

            CurrentView = CashiersWorkplaceVM.UserControl; //Клик меню по умолчанию
        }

        public void Run() => AppControl.UserControl = UserControl;


        public void NavCashiersWorkplaceVM() => CashiersWorkplaceVM.Run();
        public void NavAdministrationVM() => AdministrationVM.Run();
        public void NavWarehouseVM() => WarehouseVM.Run();


        #region

        [RelayCommand]
        public void CashiersWorkplaceClick(object? parametr) => NavCashiersWorkplaceVM();
        
       
        [RelayCommand]
        public void AdministrationVMClick(object? parametr) => NavAdministrationVM();

        [RelayCommand]
        public void WarehouseVMClick(object? parametr) => NavWarehouseVM();
        

        #endregion
    }
}
