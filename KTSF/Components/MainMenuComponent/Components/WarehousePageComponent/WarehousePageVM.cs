using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KTSF.Components.MainMenuComponent.Components.CashiersWorkplaceComponent;
using KTSF.Components.MainMenuComponent.Components.WarehousePageComponent.Components.AcceptancePoductsPageComponent;
using KTSF.Components.MainMenuComponent.Components.WarehousePageComponent.Components.DecommissionedProductsPageComponent;
using KTSF.Components.MainMenuComponent.Components.WarehousePageComponent.Components.ProductsPageComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.MainMenuComponent.Components.WarehousePageComponent
{
    //Склад
    public partial class WarehousePageVM : ObservableObject, IComponent //MainMenu -> WarehousePageVM
    {
        public AppControl AppControl { get; }

        public WarehousePageUC? WarehouseUC { get; private set; }

        public UserControl Build => WarehouseUC != null ? WarehouseUC : Create();

        #region Navigate

        public AcceptancePoductsPageVM? AcceptancePoductsPageVM { get; private set; } //Поступление товаров на склад
        public DecommissionedProductsPageVM? DecommissionedProductsPageVM { get; private set; } //Списанные товары
        public ProductsPageVM? ProductsPageVM { get; private set; } //Номенклатуры

        #endregion

        [ObservableProperty] private UserControl? currentFrame;

        private UserControl Create()
        {
            AcceptancePoductsPageVM = new AcceptancePoductsPageVM(AppControl);
            DecommissionedProductsPageVM = new DecommissionedProductsPageVM(AppControl);
            ProductsPageVM = new ProductsPageVM(AppControl);

            WarehouseUC = new WarehousePageUC(this);
            return WarehouseUC;
        }
         

        public WarehousePageVM(AppControl appControl)
        {
            AppControl = appControl;        
        }

        #region Commands

        //Поступление товаров на склад
        [RelayCommand] public void AcceptancePoductsPageNav(object? parametr)
        {
            CurrentFrame = AcceptancePoductsPageVM?.Build;
        }
        //Списанные товары
        [RelayCommand] public void DecommissionedProductsPageNav(object? parametr) => CurrentFrame = DecommissionedProductsPageVM?.Build;
         
        //Номенклатуры
        [RelayCommand] public void ProductsPageVMNav(object? parametr) => CurrentFrame = ProductsPageVM?.Build;
       

        #endregion

    }
}
