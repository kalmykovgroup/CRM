using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KTSF.Components.MainMenuComponent.Components.AdministrationComponent;
using KTSF.Components.MainMenuComponent.Components.CashiersWorkplaceComponent;
using KTSF.Components.MainMenuComponent.Components.CashReceiptPageComponent;
using KTSF.Components.MainMenuComponent.Components.DeferredCashReceiptPageComponent;
using KTSF.Components.MainMenuComponent.Components.WarehousePageComponent;
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
        #region Navigate

        public CashiersWorkplaceVM? CashiersWorkplaceVM { get; private set; } //Рабочее место кассира      
        public CashReceiptPageVM? CashReceiptPageVM { get; private set; } //Чеки
        public DeferredCashReceiptPageVM? DeferredCashReceiptPageVM { get; private set; } //Чеки
        public WarehousePageVM? WarehouseVM { get; private set; } //Склад
        public AdministrationVM? AdministrationVM { get; private set; } //Админ панель

        #endregion

        public AppControl AppControl { get; }
        public MainMenuUC? MainMenuUC { get; private set; }
   

        [ObservableProperty]
        public UserControl? currentFrame; 

        public MainMenuVM(AppControl appControl)
        {
            AppControl = appControl;                  
        }

        public UserControl Build => MainMenuUC ?? Create(); 

        private UserControl Create()
        {
           

            AdministrationVM = new AdministrationVM(AppControl);
            CashiersWorkplaceVM = new CashiersWorkplaceVM(AppControl);
            WarehouseVM = new WarehousePageVM(AppControl);
            CashReceiptPageVM = new CashReceiptPageVM(AppControl);
            DeferredCashReceiptPageVM = new DeferredCashReceiptPageVM(AppControl);

            MainMenuUC = new MainMenuUC(this);

            CurrentFrame = AdministrationVM.Build; //Клик меню по умолчанию

            return MainMenuUC;
        } 

        #region Commands

        [RelayCommand] //Рабочее место кассира
        public void CashiersWorkplacePageClick(object? parametr) => CurrentFrame = CashiersWorkplaceVM?.Build;
               
        [RelayCommand] //Админ панель
        public void AdministrationPageClick(object? parametr) => CurrentFrame = AdministrationVM?.Build;

        [RelayCommand] //Склад
        public void WarehousePageClick(object? parametr) => CurrentFrame = WarehouseVM?.Build;
        
        [RelayCommand] //Чеки
        public void CashReceiptPageClick(object? parametr) => CurrentFrame = CashReceiptPageVM?.Build;
          
        [RelayCommand] //Отложенные Чеки
        public void DeferredCashReceiptPageClick(object? parametr) => CurrentFrame = DeferredCashReceiptPageVM?.Build;


        #endregion
    }
}
