
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KTSF.Components.CommonComponents.SearchComponent;
using KTSF.ViewModel; 
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using KTSF.Core.Product_;
using KTSF.Contracts.CashiersWorkplace;

namespace KTSF.Components.TabComponents.CashiersWorkplaceComponent;

public partial class CashiersWorkplaceComponent : TabComponent
{

    public override UserControl Initial() => new CashiersWorkplaceUC(this);

    public SearchComponent SearchComponent { get; }

    [ObservableProperty] private bool isBuy = false;
    [ObservableProperty] private bool isPayment = false;
    [ObservableProperty] private string countProductText = "Оплатить (позиций: 1)";

    [ObservableProperty] public Receipt checkList = new Receipt ();

    [ObservableProperty] public BuyProduct? selectedProduct;

    public CashiersWorkplaceComponent(UserControlVM binding, AppControl appControl, string iconPath) : base(binding, appControl, iconPath)
    {
        SearchComponent = new SearchComponent(binding, appControl);
        SearchComponent.SearchAction += SelectedProductFromSearchList;
    }

    // Добавление найденого товара в текущий чек
    public void SelectedProductFromSearchList(Product product) {
        BuyProduct newProduct = new BuyProduct (product, product.SalePrice, 1);
        if (CheckList.AddProduct(newProduct)) {
            SelectedProduct = newProduct;
            IsBuy = true;
            CountProductText = $"Оплатить (позиций: {CheckList.BuyProducts.Count})";
        }
    }

    // Событие на потерю фокуса на нажатие клавиши "ENTER"
    public void textBoxCountProduct_KeyDown (object sender, KeyEventArgs e) {
        CashiersWorkplaceUC cashiersWorkplaceUC = (CashiersWorkplaceUC)Build!;

        if (e.Key == Key.Enter) {
            var textBox = sender as TextBox;
            if (textBox != null) {
                FocusManager.SetFocusedElement (cashiersWorkplaceUC, null);
                Keyboard.ClearFocus ();
            }
        }
    }

    // Событие на изменение цены выбраного товара
    public void textBoxPrice_TextChanged (object sender, TextChangedEventArgs e) {
        SelectedProduct.Price = double.Parse(((TextBox) sender).Text);
        UpdateTotalSumCheck ();
    }

    // Событие на изменение количество выбраного товара
    public void textBoxCount_TextChanged (object sender, TextChangedEventArgs e) {
        SelectedProduct.Count = int.Parse (((TextBox) sender).Text);
        UpdateTotalSumCheck ();
    }

    // Метод для обновления общей суммы товаров
    public void UpdateTotalSumCheck() {
        foreach (var buyProduct in CheckList.BuyProducts) {
            buyProduct.UpdateTotalSumProduct ();
        }
        CheckList.UpdateTotalSum ();
    }

    // Метод для выбора товара из текущего списка
    [RelayCommand]
    public void SelectedProductFromCheckList(object parameter) {
        if (((BuyProduct)parameter).Product.Id != SelectedProduct.Product.Id) {
            SelectedProduct = (BuyProduct) parameter;
        } 
    }

    // Прибавление количество товара
    [RelayCommand]
    public void IncreaseNumber (object? parameter = null) {
        if (SelectedProduct == null) {
            throw new ArgumentNullException(nameof(SelectedProduct));
        }
        SelectedProduct.Count++;
        SelectedProduct.TotalSumProduct = SelectedProduct.Price * SelectedProduct.Count;

        UpdateTotalSumCheck ();
    }
    
    // Убавление количество товара
    [RelayCommand]
    public void ReduceNumber (object? parameter = null) {
        if (SelectedProduct == null) {
            throw new ArgumentNullException(nameof(SelectedProduct));
        }
        if (SelectedProduct.Count == 1) {
            MessageBox.Show ("Невозможно взять 0 количества продукта");
            return;
        }
        SelectedProduct.Count--;
        SelectedProduct.TotalSumProduct = SelectedProduct.Price * SelectedProduct.Count;
    }

    [RelayCommand]
    public void ProcessPayment (object? parameter = null) {
        IsPayment = true;
    }

    
    [RelayCommand]
    public void PayCardClick(object? parameter = null) => CheckList.ReceiptPaymentInfo.PaymentMethod = PaymentMethod.Card;
    
    
    [RelayCommand]
    public void PayCashClick(object? parameter = null)  => CheckList.ReceiptPaymentInfo.PaymentMethod = PaymentMethod.Cash;
   


     
}

public partial class Receipt : ObservableObject {
    public ObservableCollection<BuyProduct> BuyProducts { get; set; }

    [ObservableProperty]
    private double totalSum;

    [ObservableProperty]
    private double amountPaid;

    [ObservableProperty]
    private double discount = 0;

    [ObservableProperty] private PaymentInfo receiptPaymentInfo = new PaymentInfo (cashAmount: 0, cardAmount: 0);

    public Receipt () {
        BuyProducts = new ObservableCollection<BuyProduct> ();
        totalSum = 0;
    }

    public bool AddProduct (BuyProduct selectProduct) {
        foreach (BuyProduct product in BuyProducts) {
            if (product.Product.Id == selectProduct.Product.Id) {
                MessageBox.Show ("Такой товар уже есть в списке");
                return false;
            }
        }
        BuyProducts.Add (selectProduct);
        return true;
        }

    public bool DeleteProduct (BuyProduct selectProduct) {
        foreach(BuyProduct product in BuyProducts) {
            if (product.Product.Id == selectProduct.Product.Id) {
                MessageBox.Show ("Такого товара нет в списке");
                return false;
            }
        }
        BuyProducts.Remove (selectProduct);
        return true;
    }

    public void UpdateTotalSum () {
        TotalSum = BuyProducts.Sum (p => p.TotalSumProduct);
    }
}

public partial class BuyProduct : ObservableObject {
    public Product Product { get; set; }

    [ObservableProperty]
    private double price;

    [ObservableProperty]
    private int count;

    [ObservableProperty]
    private double totalSumProduct;
    
    [ObservableProperty]
    private double discount = 0;



    public BuyProduct (Product product, double price, int count) {
        Product = product;
        Price = price;
        Count = count;
        TotalSumProduct = Price * Count;
    }

    public void UpdateTotalSumProduct () {
        TotalSumProduct = Price * Count;
    }
}