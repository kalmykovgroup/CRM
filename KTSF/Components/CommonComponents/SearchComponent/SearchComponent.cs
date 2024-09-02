using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input; 
using KTSF.ViewModel;
using KTSF.Core.Object.Product_;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CSharpFunctionalExtensions;
using System.Net;

namespace KTSF.Components.CommonComponents.SearchComponent
{
    public partial class SearchComponent : Component
    {
        public SearchComponent(UserControlVM binding, AppControl appControl) : base(binding, appControl) {           
        }

    
        public override UserControl Initial() => new SearchUC(this);

     
        [ObservableProperty] public bool isVisibilityList = false;

        public ObservableCollection<Product> ListSearchedProduct { get; } = new ObservableCollection<Product>();

        [ObservableProperty] public string search = "";

        public Product SelectedProduct = new Product();

        public Action<Product>? SearchAction;

        [RelayCommand]
        public async Task SearchClick()
        { 
        }

        public async void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = ((TextBox)sender).Text;

            if (text.Count() > 2)
            {
                ListSearchedProduct.Clear ();
                List<Product>? newListProduct = await AppControl.Server.SearchProducts(text);

                if (newListProduct == null)
                    return;
                else
                    IsVisibilityList = true;

                foreach (Product product in newListProduct) {
                    ListSearchedProduct.Add (product);
                }
               
            }
        }

        [RelayCommand]
        public void ProductClick(object? parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }

            SearchAction?.Invoke((Product)parameter);
            ListSearchedProduct.Clear ();
            IsVisibilityList = false;
            Search = "";
        }

    }
}
