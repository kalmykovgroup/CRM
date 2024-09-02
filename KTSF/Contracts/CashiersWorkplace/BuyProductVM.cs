using CommunityToolkit.Mvvm.ComponentModel;
using KTSF.Core.Product_;
using KTSF.Core.Receipt_;

namespace KTSF.Contracts.CashiersWorkplace;

public partial class BuyProductVM : ObservableObject {
    public Product Product { get; set; }

    [ObservableProperty]
    private double price;

    [ObservableProperty]
    private int count;

    [ObservableProperty]
    private double totalSumProduct;
    
    [ObservableProperty]
    private double? discount = 0;

    public BuyProductVM (Product product, double price, int count) {
        Product = product;
        Price = price;
        Count = count;
        TotalSumProduct = Price * Count;
    }

    public BuyProductVM(BuyProduct buyProduct)
    {
        Product = buyProduct.Product;
        Price = buyProduct.Price;
        count = buyProduct.Count;
        totalSumProduct = buyProduct.TotalSumProduct;
        discount = buyProduct.Discount;
    }

    public void UpdateTotalSumProduct () {
        TotalSumProduct = Price * Count;
    }
}