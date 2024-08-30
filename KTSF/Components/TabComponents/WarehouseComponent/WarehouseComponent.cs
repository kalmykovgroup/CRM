using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KTSF.Core.Product_;
using KTSF.Dto.Product_;
using KTSF.ViewModel; 
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
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
        [ObservableProperty] private PaginateBtn? beforeLast = null;

        [ObservableProperty] private PaginateBtn? nextBtn = null;

        [ObservableProperty] private bool leftEllipsis = false;
        [ObservableProperty] private bool rightEllipsis = false;

        [ObservableProperty] private bool isCounterPages = false;

        public int[] arrNumbersPage =  [];

        public WarehouseComponent(UserControlVM binding, AppControl appControl, string iconPath) : base(binding, appControl, iconPath)
        {

        }

        public override async void ComponentLoaded()
        {                        
            IsLoad = "Загрузка";
            
            FirstPage? firstPage = await AppControl.Server.GetFirstPage();

            if(firstPage is null)
            {               
                return;
            }

            CountPages = firstPage.pageCount;

            foreach (Product product in firstPage.Products)
            {
                Products.Add(product);
            }

            BeginBtn = new PaginateBtn(1);
            SecondBtn = countPages > 1 ? new PaginateBtn(2) : null;
            PenultimateBtn = countPages > 2 ? new PaginateBtn(countPages - 1 > 3 ? countPages - 1 : 3) : null;
            BeforeLast = countPages > 1 ? new PaginateBtn(CountPages - 1) : null;
            EndBtn = countPages > 3 ? new PaginateBtn(countPages) : null;


            if (countPages > 4)
            {
                for (int i = 3, j = 0; i < countPages - 1 && j < CountCenterButtons; i++, j++)
                {
                    PaginationButtons.Add(new PaginateBtn(i));
                }
            }

            CurrentPage = BeginBtn;

            if (countPages > CountCenterButtons + 4)
                Is();
            else
                RightEllipsis = false;

            if (countPages == 1)
            {
                IsCounterPages = true;

            }

            IsLoad = null;
        }

        [RelayCommand]
        public async void PaginateClick(object? parametr)
        {
            // for test ... delete it later !!!!!
            //ProductDTO pr = await AppControl.Server.GetProductFullInfo(1);

            if (parametr == null) throw new ArgumentNullException(nameof(parametr));
            PaginateBtn navBtn = (PaginateBtn)parametr;

            bool isMore = navBtn.Page > CurrentPage.Page ? true : false;

            CurrentPage = navBtn;

            if (CurrentPage.Page == CountPages)
            IsCounterPages = true;
            else
                IsCounterPages = false;

            bool flag = BeginBtn != null && SecondBtn != null && BeginBtn.Page <= navBtn.Page && SecondBtn.Page + 1 != navBtn.Page;

            Products.Clear();
            List<Product> products = await AppControl.Server.GetProducts(CurrentPage.Page);

            foreach (Product product in products)
            {
                Products.Add(product);
            }
            if (CountPages > 4 + CountCenterButtons && flag)
            {
                if (CurrentPage.Page == CountPages - 2 || CurrentPage.Page == 3)
                    return;
                else if ((CurrentPage.Page > PaginationButtons[0].Page) && (CurrentPage.Page < PaginationButtons[PaginationButtons.Count - 1].Page))
                {
                    return;
                }
                PaginationButtons.Clear();
                int j= 0;
                if (isMore)
                 j = CurrentPage.Page - CountCenterButtons / 2 <= 2 ? 3 : CurrentPage.Page - CountCenterButtons / 2 - 1;
                else
                    j = CurrentPage.Page - CountCenterButtons / 2 <= 2 ? 3 : CurrentPage.Page - CountCenterButtons / 2;
                if (j > CountPages  - CountCenterButtons)
                    j = CountPages - CountCenterButtons - 1;
              
                for (int i = 0; i < CountCenterButtons; i++, j++)
                {
                    if (j > CountPages)
                        break;
                    else if (CurrentPage.Page == j)
                    {
                        PaginationButtons.Add(CurrentPage);
                        continue;
                    }

                        PaginationButtons.Add(new PaginateBtn(j));                    
                }

                if (countPages > CountCenterButtons + 4)
                    Is();
                else
                    RightEllipsis = false;

            } 
        }

        private void Is()
        {
           LeftEllipsis = SecondBtn != null && PaginationButtons.Count > 0 && SecondBtn.Page + 1 != PaginationButtons[0].Page;
           RightEllipsis = BeforeLast != null && PaginationButtons.Count > 0  && CurrentPage.Page < CountPages - CountCenterButtons /2 - 1;
        }

        [RelayCommand]
        public async void NextPage(object? parametr)
        {            

            if (parametr == null) throw new ArgumentNullException(nameof(parametr));
            PaginateBtn navBtn = new PaginateBtn(CurrentPage.Page + 1);

            CurrentPage = navBtn;
            bool flag = BeginBtn != null && SecondBtn != null && BeginBtn.Page <= navBtn.Page && SecondBtn.Page <= navBtn.Page;

            if (CurrentPage.Page == CountPages)
                IsCounterPages = true;
            else
                IsCounterPages = false;

            Products.Clear();
            List<Product> products = await AppControl.Server.GetProducts(CurrentPage.Page);

            foreach (Product product in products)
            {
                Products.Add(product);
            }
            if (flag)
            {
                if (SecondBtn != null && CurrentPage.Page == SecondBtn.Page)
                {
                    CurrentPage = SecondBtn;
                    return;
                }
                else if (BeforeLast != null && CurrentPage.Page == BeforeLast.Page)
                {
                    CurrentPage = BeforeLast;
                    return;
                }

                else if (EndBtn != null && CurrentPage.Page == EndBtn.Page)
                {
                    CurrentPage = EndBtn;
                    return;
                }
                int j = 3;
                int counter = 0;
                if (countPages > 4 + CountCenterButtons)
                {
                    counter = CountCenterButtons;
                    j = CurrentPage.Page < CountCenterButtons + 2 ? 3 : CurrentPage.Page - CountCenterButtons / 2;
                    if (j >= CountPages - CountCenterButtons)
                        j = CountPages - CountCenterButtons;
                    if (CurrentPage.Page == CountPages - 2)
                    {
                        j = CountPages - CountCenterButtons - 1;
                    }
                }
                else
                {
                    counter = CountPages - 4;
                }
        
                PaginationButtons.Clear();


                    for (int i = 0; i < counter; i++, j++)
                    {
                        if (j > CountPages)
                            break;
                        else if (CurrentPage.Page == j)
                        {
                            PaginationButtons.Add(CurrentPage);
                            continue;
                        }

                        PaginationButtons.Add(new PaginateBtn(j));
                    }

                
             
                if (countPages > CountCenterButtons + 4)
                    Is();
                else
                    RightEllipsis = false;


            }
            
        }

       [RelayCommand]
         public async void BackPage(object? parametr)
        {
            if (parametr == null) throw new ArgumentNullException(nameof(parametr));
            PaginateBtn navBtn = new PaginateBtn(CurrentPage.Page - 1);
            
            CurrentPage = navBtn;
            bool flag = BeginBtn != null && SecondBtn != null && BeginBtn.Page <= navBtn.Page;

            if (CurrentPage.Page == CountPages)
                IsCounterPages = true;
            else
                IsCounterPages = false;

            Products.Clear();
            List<Product> products = await AppControl.Server.GetProducts(CurrentPage.Page);

            foreach (Product product in products)
            {
                Products.Add(product);
            }
            if (flag)
            {
                if (SecondBtn != null && CurrentPage.Page == SecondBtn.Page)
                {
                    CurrentPage = SecondBtn;
                    return;
                }
                else if (BeforeLast != null && CurrentPage.Page == BeforeLast.Page)
                {
                    CurrentPage = BeforeLast;
                    return;
                }

                else if (BeginBtn != null && CurrentPage.Page == BeginBtn.Page)
                {
                    CurrentPage = BeginBtn;
                    return;
                }
                int j = 3;
                int counter = 0;
                if (countPages > 4 + CountCenterButtons)
                {
                    counter = CountCenterButtons;
                    j = CurrentPage.Page < CountCenterButtons + 2 ? 3 : CurrentPage.Page - CountCenterButtons / 2;
                    if (j >= CountPages - CountCenterButtons)
                        j = CountPages - CountCenterButtons;
                    if (CurrentPage.Page == CountPages - 2)
                    {
                        j = CountPages - CountCenterButtons - 1;
                    }
                }
                else
                {
                    counter = CountPages - 4;
                }

                PaginationButtons.Clear();

             
                for (int i = 0; i < CountCenterButtons; i++, j++)
                {
                    if (j > CountPages)
                        break;
                    else if (CurrentPage.Page == j)
                    {
                        PaginationButtons.Add(CurrentPage);
                        continue;
                    }

                    PaginationButtons.Add(new PaginateBtn(j));

                }

                if (countPages > CountCenterButtons + 4)
                    Is();
                else
                    RightEllipsis = false;
            }
        }


        public override UserControl Initial() => new WarehouseUC(this);

       
    }
}
