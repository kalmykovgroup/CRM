using KTSFClassLibrary.Product_;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.MainMenuComponent.Components.WarehousePageComponent.Components.DecommissionedProductsPageComponent
{
    //Списанные товары
     public class DecommissionedProductsPageVM : IComponent //MainMenuVM -> WarehousePageVM -> DecommissionedProductsPageVM
    {
        public AppControl AppControl { get; }

        public DecommissionedProductsPageUC? DecommissionedProductsPageUC { get; private set; }

        public ObservableCollection<Product> Products { get; } = new();

        public UserControl Build => DecommissionedProductsPageUC ?? Create();

        public UserControl Create()
        {
            DecommissionedProductsPageUC = new DecommissionedProductsPageUC(this);
            ProductsLoad();
            return DecommissionedProductsPageUC;
        }

        public DecommissionedProductsPageVM(AppControl appControl)
        {
            AppControl = appControl;
        }

        public async void ProductsLoad()
        {
            List<Product> list = await AppControl.Server.GetDecommissionedProducts();

            foreach (Product product in list)
            {
                Products.Add(product);
            }
        }
    }
}
