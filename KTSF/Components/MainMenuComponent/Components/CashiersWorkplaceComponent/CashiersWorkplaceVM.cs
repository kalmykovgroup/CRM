using KTSF.Components.CommonComponent.SearchComponent;
using KTSFClassLibrary.Product_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KTSF.Components.MainMenuComponent.Components.CashiersWorkplaceComponent
{
    public class CashiersWorkplaceVM : IComponent //MainMenu -> CashiersWorkplaceVM
    {
        public AppControl AppControl { get; }

        public CashiersWorkplaceUC? CashiersWorkplaceUC { get; private set; }

        public SearchVM? SearchVM { get; private set; }

        public UserControl Build => CashiersWorkplaceUC != null ? CashiersWorkplaceUC : Create();

        public UserControl Create()
        {
            SearchVM = new SearchVM(AppControl); //Создали компонент
            SearchVM.SearchAction += Search; //Подписались на его работу

            CashiersWorkplaceUC = new CashiersWorkplaceUC(this);
            return CashiersWorkplaceUC;
        }

        public CashiersWorkplaceVM(AppControl appControl)
        {
            AppControl = appControl;
        }

        public void Search(Product product) //Функция запуститься когда отработает поиск и будет выбран товар
        {
            MessageBox.Show($"Был выбран {product.Name}");
        }
    }
}
