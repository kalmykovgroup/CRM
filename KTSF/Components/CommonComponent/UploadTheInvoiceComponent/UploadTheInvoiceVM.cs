using KTSF.Components.MainMenuComponent.Components.WarehousePageComponent.Components.ProductsPageComponent;
using KTSFClassLibrary.Product_;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KTSF.Components.CommonComponent.UploadTheInvoiceComponent
{
    public class UploadTheInvoiceVM : IComponent  
    {
        public AppControl AppControl { get; }

        public UploadTheInvoiceUC? UploadTheInvoiceUC { get; private set; }

        public UserControl Build => UploadTheInvoiceUC ?? Create();
         
        public UserControl Create()
        {
            UploadTheInvoiceUC = new UploadTheInvoiceUC(this); 
            return UploadTheInvoiceUC;
        }

        public UploadTheInvoiceVM(AppControl appControl)
        {
            AppControl = appControl;
        }

        public void Run()
        {
            MessageBox.Show("UploadTheInvoiceVM");
        }
    }
}
