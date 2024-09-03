using KTSF.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CSharpFunctionalExtensions;
using KTSF.Components.TabComponents.WarehouseComponent;
using KTSF.Contracts.CashiersWorkplace;
using KTSF.Core.Object.Product_;
using KTSF.Core.Object.Receipt_;
using KTSF.Dto.Product_;

namespace KTSF.Components.TabComponents.SalesComponent;

    public partial class SalesComponent : TabComponent
    {
        public ObservableCollection<ReceiptVM> Receipts { get; }
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
        public SalesComponent(UserControlVM binding, AppControl appControl, string iconPath) : base (binding, appControl, iconPath) { }
        
        public override async void ComponentLoaded()
        {                        
            IsLoad = "Загрузка";
            
            Result<FirstPage<Receipt>, (string? Message, HttpStatusCode)> result = await AppControl.Server.GetFirstPageReceipt();

            if(result.IsFailure)
            {               
                MessageBox.Show(result.Error.Message);
            }

            CountPages = result.Value.PageCount;

            foreach (Receipt receipt in result.Value.Items)
            {
                ReceiptVM newReceiptVM = new ReceiptVM(receipt);
                Receipts.Add(newReceiptVM);
            }

            BeginBtn = new PaginateBtn(1);
            SecondBtn = CountPages > 1 ? new PaginateBtn(2) : null;
            PenultimateBtn = CountPages > 2 ? new PaginateBtn(CountPages - 1 > 3 ? CountPages - 1 : 3) : null;
            BeforeLast = CountPages > 1 ? new PaginateBtn(CountPages - 1) : null;
            EndBtn = CountPages > 3 ? new PaginateBtn(CountPages) : null;


            if (CountPages > 4)
            {
                for (int i = 3, j = 0; i < CountPages - 1 && j < CountCenterButtons; i++, j++)
                {
                    PaginationButtons.Add(new PaginateBtn(i));
                }
            }

            CurrentPage = BeginBtn;

            if (CountPages > CountCenterButtons + 4)
                Is();
            else
                RightEllipsis = false;

            if (CountPages == 1)
            {
                IsCounterPages = true;

            }

            IsLoad = null;
        }
        
        [RelayCommand]
        public async void PaginateClick(object? parameter)
        {
            // for test ... delete it later !!!!!
            //ProductDTO pr = await AppControl.Server.GetProductFullInfo(1);

            if (parameter == null) throw new ArgumentNullException(nameof(parameter));
            PaginateBtn navBtn = (PaginateBtn)parameter;

            bool isMore = navBtn.Page > CurrentPage.Page ? true : false;

            CurrentPage = navBtn;

            if (CurrentPage.Page == CountPages)
            IsCounterPages = true;
            else
                IsCounterPages = false;

            bool flag = BeginBtn != null && SecondBtn != null && BeginBtn.Page <= navBtn.Page && SecondBtn.Page + 1 != navBtn.Page;

            Receipts.Clear(); 
            //List<Receipt> receipts = await AppControl.Server.GetReceipts(CurrentPage.Page);
            List<Receipt> receipts = new List<Receipt>();

            if (receipts.Count == 0)
            {
                return;
            }

            foreach (Receipt receipt in receipts)
            {
                ReceiptVM newReceiptVm = new ReceiptVM(receipt);
                Receipts.Add(newReceiptVm);
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

                if (CountPages > CountCenterButtons + 4)
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
        public async void NextPage(object? parameter)
        {            

            if (parameter == null) throw new ArgumentNullException(nameof(parameter));
            PaginateBtn navBtn = new PaginateBtn(CurrentPage.Page + 1);

            CurrentPage = navBtn;
            bool flag = BeginBtn != null && SecondBtn != null && BeginBtn.Page <= navBtn.Page && SecondBtn.Page <= navBtn.Page;

            if (CurrentPage.Page == CountPages)
                IsCounterPages = true;
            else
                IsCounterPages = false;

            Receipts.Clear();
            Result<List<Receipt>, (string? Message, HttpStatusCode)> result = await AppControl.Server.GetReceipts(CurrentPage.Page);

            if (result.IsFailure) {
                MessageBox.Show(result.Error.Message);
                return;
            } 
            
            foreach (Receipt receipt in result.Value)
            {
                ReceiptVM newReceiptVm = new ReceiptVM(receipt);
                Receipts.Add(newReceiptVm);
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
                if (CountPages > 4 + CountCenterButtons)
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

                
             
                if (CountPages > CountCenterButtons + 4)
                    Is();
                else
                    RightEllipsis = false;


            }
            
        }

       [RelayCommand]
         public async void BackPage(object? parameter)
        {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));
            PaginateBtn navBtn = new PaginateBtn(CurrentPage.Page - 1);
            
            CurrentPage = navBtn;
            bool flag = BeginBtn != null && SecondBtn != null && BeginBtn.Page <= navBtn.Page;

            if (CurrentPage.Page == CountPages)
                IsCounterPages = true;
            else
                IsCounterPages = false;

            Receipts.Clear();
            Result<List<Receipt>, (string? Message, HttpStatusCode)> result = await AppControl.Server.GetReceipts(CurrentPage.Page);

            if (result.IsFailure) {
                MessageBox.Show(result.Error.Message);
                return;
            } 
            
            foreach (Receipt receipt in result.Value)
            {
                ReceiptVM newReceiptVm = new ReceiptVM(receipt);
                Receipts.Add(newReceiptVm);
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
                if (CountPages > 4 + CountCenterButtons)
                {
                    j = CurrentPage.Page < CountCenterButtons + 2 ? 3 : CurrentPage.Page - CountCenterButtons / 2;
                    if (j >= CountPages - CountCenterButtons)
                        j = CountPages - CountCenterButtons;
                    if (CurrentPage.Page == CountPages - 2)
                    {
                        j = CountPages - CountCenterButtons - 1;
                    }
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

                if (CountPages > CountCenterButtons + 4)
                    Is();
                else
                    RightEllipsis = false;
            }
        }

        public override UserControl Initial() => new SalesUC(this);
    }
