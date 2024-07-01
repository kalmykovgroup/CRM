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
using System.Collections.ObjectModel;

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

        [ObservableProperty] public bool isVisibilityList = false;

        public ObservableCollection<Product> ListSearchedProduct { get; } = new ObservableCollection<Product>();

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

        [RelayCommand] public async void SearchClick()
        {
            List<Product> newListProduct = await AppControl.Server.SearchProducts (Search);
            if(newListProduct.Count > 0) {
                IsVisibilityList = true;
            }
            foreach (Product product in newListProduct) {
                ListSearchedProduct.Add (product);
            }
        }

        public void TextBox_TextChanged (object sender, TextChangedEventArgs e) {
            string text = ((TextBox) sender).Text;
            if (text.Count () > 2) {
                
            }
        }

        [RelayCommand] public void ProductClick (object? parameter) {
            if (parameter == null) {
                throw new ArgumentNullException(nameof(parameter));
            }

            Product product = (Product) parameter;

            MessageBox.Show (product.Name);
        }
    }
}
