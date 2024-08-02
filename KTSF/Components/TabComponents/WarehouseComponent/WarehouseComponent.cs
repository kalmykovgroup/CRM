using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KTSF.Core.Product_;
using KTSF.ViewModel; 
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

    public class PaginateBtn
    {
        public int Page { get; }

        public PaginateBtn(int page)
        {
            Page = page;
        }

        public override string ToString() => $"{Page}";
    }

    public partial class WarehouseComponent : TabComponent //Склад
    {

        public ObservableCollection<Product> Products { get; } = [];
        public ObservableCollection<PaginateBtn> PaginationButtons { get; } = [];

        [ObservableProperty] private int countPages;
        [ObservableProperty] private PaginateBtn currentPage = null!;

        private int CountCenterButtons { get; } = 4;

        [ObservableProperty] private PaginateBtn beginBtn = null!; 

        [ObservableProperty] private PaginateBtn? secondBtn = null!;
        [ObservableProperty] private PaginateBtn? penultimateBtn = null;
        [ObservableProperty] private PaginateBtn? endBtn = null;


        [ObservableProperty] private bool leftEllipsis = false;
        [ObservableProperty] private bool rightEllipsis = false;


        public int[] arrNumbersPage =  [];

        public WarehouseComponent(UserControlVM binding, AppControl appControl) : base(binding, appControl)
        {

        }

        public override async void ComponentLoaded()
        {
            IsLoad = "Загрузка";
        
            (int countPages, List<Product> products) = await AppControl.Server.GetProducts();

            CountPages = countPages;

            foreach (Product product in products)
            {
                Products.Add(product);
            }

            BeginBtn = new PaginateBtn(1);
            SecondBtn = countPages > 1 ? new PaginateBtn(2) : null;
            PenultimateBtn = countPages > 2 ? new PaginateBtn(countPages - 1 > 3 ? countPages - 1 : 3) : null;
            EndBtn = countPages > 3 ? new PaginateBtn(countPages) : null;
            
 
            if(countPages > 4)
            { 
                for (int i = 3, j = 0; i < countPages - 1 && j < CountCenterButtons; i++, j++)
                {
                    PaginationButtons.Add(new PaginateBtn(i));
                }
            }
       
            CurrentPage = BeginBtn;

            Is();

            IsLoad = null;
        }

        [RelayCommand]
        public void PaginateClick(object? parametr)
        {
            if(parametr == null) throw new ArgumentNullException(nameof(parametr));
            PaginateBtn navBtn = (PaginateBtn)parametr;

            CurrentPage = navBtn;

            bool flag = SecondBtn != null  && SecondBtn.Page + 1 != navBtn.Page && SecondBtn.Page + 1 !< navBtn.Page;


            if (CountPages > 4 + CountCenterButtons && flag)
            {
                PaginationButtons.Clear();
                
                int j = CurrentPage.Page - CountCenterButtons / 2;

                for (int i = 0; i < CountCenterButtons; i++, j++)
                {
                    if(CurrentPage.Page == j)
                    {
                        PaginationButtons.Add(CurrentPage);
                        continue;
                    }
                    PaginationButtons.Add(new PaginateBtn(j));
                }

                Is();

            } 
 
           // MessageBox.Show($"{navBtn}");
        }

        private void Is()
        {
            LeftEllipsis = SecondBtn != null && PaginationButtons.Count > 0 && SecondBtn.Page + 1 != PaginationButtons[0].Page;
            RightEllipsis = PenultimateBtn != null && PaginationButtons.Count > 0 && PenultimateBtn.Page - 1 != PaginationButtons.Last().Page;

        }


        /*   public int Pages()
           {
               return countProdutc / countPage;
           }*/

        [RelayCommand]
        public async void NextPage(object? parametr)
        {
        /*    if (Build is null)
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
            if (countProdutc / countPage == CurrentPage)
            {
                nextBtn.IsEnabled = false;
            }

            IsLoad = "Загрузка";
            KeyValuePair<int, List<Product>> list = await AppControl.Server.GetProducts(CurrentPage, countPage);
            foreach (Product product in list.Value)
            {
                Products.Add(product);
            }
            IsLoad = null;*/
        }

       [RelayCommand]
         public async void BackPage(object? parametr)
        {
        //    if (Build is null)
        //    {
        //        throw new ArgumentNullException(nameof(Build));
        //    }
        //    Products.Clear();
        //    CurrentPage--;
        //    Button nextBtn = (Button)((WarehouseUC)Build).FindName("nextPage");
        //    nextBtn.IsEnabled = true;
        //    Button backBtn = (Button)((WarehouseUC)Build).FindName("backPage");
        //    if (CurrentPage == 0)
        //        backBtn.IsEnabled = false;

        //    IsLoad = "Загрузка";
        //    List<Product> list = await AppControl.Server.GetProducts(CurrentPage, countPage);
        //    foreach (Product product in list)
        //    {
        //        Products.Add(product);
        //    }
        //    IsLoad = null;
         }


        public override UserControl Initial() => new WarehouseUC(this);

       
    }
}
