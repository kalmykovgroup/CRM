using CommunityToolkit.Mvvm.Input;
using KTSF.ViewModel;
using KTSFClassLibrary.Product_;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace KTSF.Components.TabComponents.WarehouseComponent
{
    public partial class WarehouseComponent : TabComponent //Склад
    {
        public WarehouseComponent(UserControlVM binding, AppControl appControl) : base(binding, appControl)
        {
        }

        public ObservableCollection<Product> Products { get; private set; }
        public static int countPage = 1;
        public int page = 0;
        public int allItems = 0; // количество продуктов
        public int[] arrNumbersPage =  [];

        public override async void ComponentLoaded()
        {
            IsLoad = "Загрузка";
            Products = new();
            KeyValuePair <int, List<Product>> list = await AppControl.Server.GetProducts(page, countPage);

            allItems = list.Key;
            foreach (Product product in list.Value)
            Products.Add(product);

            if (allItems / countPage >= 5)
                arrNumbersPage = [1, 2, 3, 4, 5];
            else
            {
                for (int i = 0; i < allItems / countPage; i++)
                    arrNumbersPage[i] = i + 1;
            }
            //Обязательно нужго округление числа
            if (Build is null)
                return;

            Grid pagination = (Grid)((WarehouseUC)Build).FindName("Pagination");
            for (int i = 0; i < arrNumbersPage.Length + 4; i++)
            {
                ColumnDefinition column = new();
                pagination.ColumnDefinitions.Add(column);
                Button button = new();
                pagination.Children.Add(button);
                button.SetValue(Grid.ColumnProperty, i);
                if (i == 0)
                {
                    button.Content = "Назад";
                    button.Name = "backPage";
                }
                else if (i == 6)
                    button.Content = "...";
                else if (i == 7)
                    button.Content = (allItems / countPage).ToString();
                else if (i == 8)
                {
                    button.Content = "Вперед";
                    button.SetValue(WarehouseUC.NameProperty, "nextPage");
                    //button.Name = "nextPage";
                    button.Command = NextPageCommand;
                }
                else
                    button.Content = arrNumbersPage[i - 1].ToString();
            }


            IsLoad = null;
        }


        public int Pages()
        {
            return allItems / countPage;
        }

        [RelayCommand]
        public async void NextPage(object? parametr)
        {
            if (Build is null)
            {
                throw new ArgumentNullException(nameof(Build));
            }
            Products.Clear();
            Button nextBtn = (Button)((WarehouseUC)Build).FindName("nextPage");
            Button backBtn = (Button)((WarehouseUC)Build).FindName("backPage");
            if (nextBtn is null)
            {
                MessageBox.Show("Ой");
                return;
            }
            backBtn.IsEnabled = true;
            if (allItems / countPage == page)
            {
                nextBtn.IsEnabled = false;
            }

            IsLoad = "Загрузка";
            KeyValuePair<int, List<Product>> list = await AppControl.Server.GetProducts(page, countPage);
            foreach (Product product in list.Value)
            {
                Products.Add(product);
            }
            IsLoad = null;
        }

        //[RelayCommand]
        //public async void BackPage(object? parametr)
        //{
        //    if (Build is null)
        //    {
        //        throw new ArgumentNullException(nameof(Build));
        //    }
        //    Products.Clear();
        //    page--;
        //    Button nextBtn = (Button)((WarehouseUC)Build).FindName("nextPage");
        //    nextBtn.IsEnabled = true;
        //    Button backBtn = (Button)((WarehouseUC)Build).FindName("backPage");
        //    if (page == 0)
        //        backBtn.IsEnabled = false;

        //    IsLoad = "Загрузка";
        //    List<Product> list = await AppControl.Server.GetProducts(page, countPage);
        //    foreach (Product product in list)
        //    {
        //        Products.Add(product);
        //    }
        //    IsLoad = null;
        //}


        public override UserControl Initial() => new WarehouseUC(this);
    }
}
