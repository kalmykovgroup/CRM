using CommunityToolkit.Mvvm.ComponentModel;
using KTSF.Components.MainMenuComponent.Components.WarehousePageComponent.Components.DecommissionedProductsPageComponent;
using KTSFClassLibrary.Product_;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.MainMenuComponent.Components.WarehousePageComponent.Components.ProductsPageComponent
{
    //Номенклатуры
     public partial class ProductsPageVM : ObservableObject, IComponent //MainMenuVM -> WarehousePageVM -> ProductsPageVM
    {
        public AppControl AppControl { get; }

        public ProductsPageUC? ProductsPageUC { get; private set; }

        [ObservableProperty] private string? isLoad;

        public UserControl Build => ProductsPageUC ?? Create();

        public ObservableCollection<Product> Products { get; } = new(); 

        public async void ProductsLoad()
        {
            IsLoad = "";

            List <Product> list = await AppControl.Server.GetProducts(0, 0);

            foreach(Product product in list)
            {
                Products.Add(product);
            }

            IsLoad = null;
        }

        public UserControl Create()
        {
            ProductsPageUC = new ProductsPageUC(this);
            ProductsLoad();
            return ProductsPageUC;
        }

        public ProductsPageVM(AppControl appControl)
        {
            AppControl = appControl;
        }
    }
}
