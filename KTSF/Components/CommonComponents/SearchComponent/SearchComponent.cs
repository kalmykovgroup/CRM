using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KTSF.Components.SignInPageComponent.Components.AuthFormComponent;
using KTSF.ViewModel;
using KTSF.Core.Product_;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KTSF.Components.CommonComponents.SearchComponent
{
    public partial class SearchComponent : Component
    {
        public SearchComponent(UserControlVM binding, AppControl appControl) : base(binding, appControl)
        {
        }

    
        public override UserControl Initial() => new SearchUC(this);

     
        [ObservableProperty] public bool isVisibilityList = false;

        public ObservableCollection<Product> ListSearchedProduct { get; } = new ObservableCollection<Product>();

        [ObservableProperty] public string search = String.Empty;
         

        public Action<Product>? SearchAction;

        [RelayCommand]
        public async Task SearchClick()
        {
            List<Product> newListProduct = await AppControl.Server.SearchProducts(Search);
            if (newListProduct.Count > 0)
            {
                IsVisibilityList = true;
            }
            foreach (Product product in newListProduct)
            {
                ListSearchedProduct.Add(product);
            }
        }

        public void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = ((TextBox)sender).Text;
            if (text.Count() > 2)
            {

            }
        }

        [RelayCommand]
        public void ProductClick(object? parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }

            Product product = (Product)parameter;

            MessageBox.Show(product.Name);
        }

    }
}
