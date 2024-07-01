using KTSF.Components.CommonComponent.SearchComponent;
using KTSFClassLibrary.Product_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.CommonComponent.ProductComponent
{
    public class ProductVM : IComponent
    {
        public Product Product { get; }

        private ProductUC? productUC;

        public AppControl AppControl { get; }

        public ProductUC? ProductUC
        {
            get
            {
                if (productUC == null) Create();
                return productUC;
            }
            private set
            {
                productUC = value;
            }
        }

        public UserControl Build => ProductUC ?? Create();

        public UserControl Create()
        {
            ProductUC = new ProductUC(this);
            return ProductUC;
        }

        public ProductVM(Product product, AppControl appControl)
        {
            Product = product;
            AppControl = appControl;
        }

         
    }
}
