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
using KTSF.Components.CommonComponents.PaginateComponent;
using KTSF.Components.TabComponents.WarehouseComponent;
using KTSF.Contracts.CashiersWorkplace;
using KTSF.Core.Object.Product_;
using KTSF.Core.Object.Receipt_;
using KTSF.Dto.Product_;
using KTSF.Dto.Receipt_;

namespace KTSF.Components.TabComponents.SalesComponent;

    public partial class SalesComponent : TabComponent, IPaganatable
    { 
        public ObservableCollection<ReceiptVM> Receipts { get; } = new ObservableCollection<ReceiptVM>();
        [ObservableProperty] private ReceiptVM selectedReceipt;

        public PaginateComponent PaginateComponent { get; }
        
        public SalesComponent(UserControlVM binding, AppControl appControl, string iconPath) : base(binding, appControl, iconPath)
        {
            PaginateComponent = new PaginateComponent(binding, appControl, this);
            PaginateComponent.GetCurrentPage += TakeCurrentPageReceipts;
            SelectedReceipt = null; 
        }
        
        public override async void ComponentLoaded()
        {                        
            IsLoad = "Загрузка";
            
            List<Receipt> newReceipts = (await PaginateComponent.TakeFirstPage()).Cast<Receipt>().ToList();

            foreach (Receipt receipt in newReceipts)
            {
                Receipts.Add(new ReceiptVM(receipt));
            }
            
            IsLoad = null;
        }

        public void TakeCurrentPageReceipts(List<object> currentReceipts)
        {
            List<Receipt> newReceipts = currentReceipts.Cast<Receipt>().ToList();
            
            foreach (Receipt receipt in newReceipts)
            {
                Receipts.Add(new ReceiptVM(receipt));
            }
        }

        public async void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if ((ReceiptVM)sender is ReceiptVM receipt) return;
            //var result = await AppControl.Server.GetReceiptFullInfo(receipt.Id);
        }
        
        public override SalesUC Initial() => new SalesUC(this);
    }
