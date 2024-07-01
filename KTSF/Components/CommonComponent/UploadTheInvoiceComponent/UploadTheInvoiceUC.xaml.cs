using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KTSF.Components.CommonComponent.UploadTheInvoiceComponent
{
    /// <summary>
    /// Логика взаимодействия для UploadTheInvoiceUC.xaml
    /// </summary>
    public partial class UploadTheInvoiceUC : UserControl
    {
        public UploadTheInvoiceVM UploadTheInvoiceVM { get; }
        public UploadTheInvoiceUC(UploadTheInvoiceVM uploadTheInvoiceVM)
        {
            InitializeComponent();
            UploadTheInvoiceVM = uploadTheInvoiceVM;
            DataContext = UploadTheInvoiceVM;
        }
    }
}
