using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace KTSF.Core.Receipt_;

public partial class Receipt : ObservableObject {
    public ObservableCollection<BuyProduct> BuyProducts { get; set; }
    
    [ObservableProperty]
    private double discount = 0;

    [ObservableProperty] private PaymentInfo receiptPaymentInfo = new PaymentInfo (cashAmount: 0, cardAmount: 0);

    public Receipt () {
        BuyProducts = new ObservableCollection<BuyProduct> ();
        ReceiptPaymentInfo.TotalSum = 0;
    }

    public bool AddProduct (BuyProduct selectProduct) {
        foreach (BuyProduct product in BuyProducts) {
            if (product.Product.Id == selectProduct.Product.Id) {
                //MessageBox.Show ("Такой товар уже есть в списке");
                return false;
            }
        }
        BuyProducts.Add (selectProduct);
        return true;
    }

    public bool DeleteProduct (BuyProduct selectProduct) {
        foreach(BuyProduct product in BuyProducts) {
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