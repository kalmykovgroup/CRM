using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using KTSFClassLibrary.Product_;

namespace KTSF.Components.CommonComponent.SearchComponent
{
     public partial class SearchVM : ObservableObject, IComponent
    {
        public AppControl AppControl { get; }

        private SearchUC? searchUC;
        public SearchUC? SearchUC { get {
                if (searchUC == null) Create();
                return searchUC;
            } private set {
                searchUC = value;
            }
        }

        [ObservableProperty] public string search = String.Empty;

        public UserControl Build => SearchUC ?? Create();

        public UserControl Create()
        {
            SearchUC = new SearchUC(this);
            return SearchUC;
        }

        public SearchVM(AppControl appControl)
        {
            AppControl = appControl;
        }

        public Action<Product>? SearchAction;

        [RelayCommand] public void SearchClick()
        {
            Product product = new Product()
            {
                Name = "Test product"
            };

            SearchAction?.Invoke(product);
        }
    }
}
