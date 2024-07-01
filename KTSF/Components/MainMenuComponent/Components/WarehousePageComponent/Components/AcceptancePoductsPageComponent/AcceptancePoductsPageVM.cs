using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KTSF.Components.CommonComponent.AddProductComponent;
using KTSF.Components.CommonComponent.UploadTheInvoiceComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KTSF.Components.MainMenuComponent.Components.WarehousePageComponent.Components.AcceptancePoductsPageComponent
{
    //Поступление товаров
    public partial class AcceptancePoductsPageVM : ObservableObject, IComponent //MainMenuVM -> WarehousePageVM -> AcceptancePoductsPageVM
    {
        public AppControl AppControl { get; }

        public AcceptancePoductsPageUC? AcceptancePoductsPageUC { get; private set; }

        public UserControl Build => AcceptancePoductsPageUC ?? Create();

        public AddProductVM? AddProductVM { get; private set; }
        public UploadTheInvoiceVM? UploadTheInvoiceVM { get; private set; }

        public UserControl Create()
        {
            AcceptancePoductsPageUC = new AcceptancePoductsPageUC(this);

            return AcceptancePoductsPageUC;
        }

        public AcceptancePoductsPageVM(AppControl appControl)
        {
            AppControl = appControl;
        }

        #region Commands

        [RelayCommand] 
        public void AddProductClick(object? parametr)
        {
            AddProductVM = new AddProductVM(AppControl);
            AddProductVM.Run(); 
        }

        [RelayCommand] 
        public void UploadTheInvoiceClick(object? parametr)
        {
            UploadTheInvoiceVM = new UploadTheInvoiceVM(AppControl);
            UploadTheInvoiceVM.Run(); 
        }

        #endregion
    }
}
