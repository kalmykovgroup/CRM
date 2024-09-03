using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using KTSF.Core.Object.Receipt_;

namespace KTSF.Contracts.CashiersWorkplace;

public partial class ReceiptVM : ObservableObject {
    public ObservableCollection<BuyProductVM> BuyProducts { get; set; }
    
    [ObservableProperty]
    private double discount = 0;

    [ObservableProperty] private PaymentInfoVM receiptPaymentInfo = new PaymentInfoVM (cashAmount: 0, cardAmount: 0);

    public ReceiptVM () {
        BuyProducts = new ObservableCollection<BuyProductVM> ();
        ReceiptPaymentInfo.TotalSum = 0;
    }

    public ReceiptVM(Receipt receipt)
    {
        foreach (BuyProduct buyProduct in receipt.BuyProducts)
        {
            BuyProductVM newBuyProductVm = new BuyProductVM(buyProduct);
            BuyProducts.Add(newBuyProductVm);
        }
        
        ReceiptPaymentInfo = new PaymentInfoVM(receipt.ReceiptPaymentInfo);
    }

    public bool AddProduct (BuyProductVM selectProduct) {
        foreach (BuyProductVM product in BuyProducts) {
            if (product.Product.Id == selectProduct.Product.Id) {
                //MessageBox.Show ("Такой товар уже есть в списке");
                return false;
            }
        }
        BuyProducts.Add (selectProduct);
        return true;
    }

    public bool DeleteProduct (BuyProductVM selectProduct) {
        foreach(BuyProductVM product in BuyProducts) {
            if (product.Product.Id == selectProduct.Product.Id) {
                //MessageBox.Show ("Такого товара нет в списке");
                return false;
            }
        }
        BuyProducts.Remove (selectProduct);
        return true;
    }

    public void UpdateTotalSum () {
        ReceiptPaymentInfo.TotalSum = BuyProducts.Sum (p => p.TotalSumProduct);
    }
}