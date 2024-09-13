using KTSF.ViewModel;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using KTSF.Components.CommonComponents.PaginateComponent;
using KTSF.Contracts.CashiersWorkplace;
using KTSF.Core.Object.Receipt_;

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

            Receipts.Clear();
            foreach (Receipt receipt in newReceipts)
            {
                Receipts.Add(new ReceiptVM(receipt));
            }
            
            IsLoad = null;
        }

        public void TakeCurrentPageReceipts(List<object> currentReceipts)
        {
            List<Receipt> newReceipts = currentReceipts.Cast<Receipt>().ToList();
            
            Receipts.Clear();
            foreach (Receipt receipt in newReceipts)
            {
                Receipts.Add(new ReceiptVM(receipt));
            }
        }
        
        public override SalesUC Initial() => new SalesUC(this);
    }
