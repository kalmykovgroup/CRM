using KTSF.Components.MainMenuComponent.Components.WarehousePageComponent.Components.DecommissionedProductsPageComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.MainMenuComponent.Components.WarehousePageComponent.Components.ProductsPageComponent
{
    //Номенклатуры
     public class ProductsPageVM : IComponent //MainMenuVM -> WarehousePageVM -> ProductsPageVM
    {
        public AppControl AppControl { get; }

        public ProductsPageUC? ProductsPageUC { get; private set; }

        public UserControl Build => ProductsPageUC ?? Create();

        public UserControl Create()
        {
            ProductsPageUC = new ProductsPageUC(this);

            return ProductsPageUC;
        }

        public ProductsPageVM(AppControl appControl)
        {
            AppControl = appControl;
        }
    }
}
