using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KTSFClassLibrary.Product_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls; 

namespace KTSF.Components.CommonComponent.AddProductComponent
{
    public partial class AddProductVM : ObservableObject
    {
        public AppControl AppControl { get; }

        public AddProductWindow? AddProductWindow { get; private set; }
         
        private Product? Product { get; set; }


        public AddProductVM(AppControl appControl)
        {
            AppControl = appControl;
        }

        public Product? Run()
        {
            AddProductWindow = new AddProductWindow(this);

            if (AddProductWindow.ShowDialog() == true) {
                return Product;
            }

            return null;
        }

        #region Commands

        [RelayCommand] public void SaveProductClick()
        {
            (AddProductWindow ?? throw new ArgumentNullException()).DialogResult = true;
        }
        [RelayCommand] public void CancelClick()
        {
            (AddProductWindow ?? throw new ArgumentNullException()).DialogResult = false;
        }
        #endregion
    }
}
