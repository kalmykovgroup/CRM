using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KTSF.Components.CommonComponents.SearchComponent;
using KTSF.ViewModel; 
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using KTSF.Contracts.CashiersWorkplace;
using KTSF.Core.Product_;
using KTSF.Core.Receipt_;
using PaymentMethod = KTSF.Core.Receipt_.PaymentMethod;

namespace KTSF.Components.TabComponents.CashiersWorkplaceComponent;

public partial class CashiersWorkplaceComponent : TabComponent
{

    public override UserControl Initial() => new CashiersWorkplaceUC(this);

    public SearchComponent SearchComponent { get; }

    [ObservableProperty] private bool isBuy = false;
    [ObservableProperty] private bool isPayment = false;
    [ObservableProperty] private string countProductText = "Оплатить (позиций: 1)";

    [ObservableProperty] public ReceiptVM checkList = new ReceiptVM ();

    [ObservableProperty] public BuyProductVM? selectedProduct;

    public CashiersWorkplaceComponent(UserControlVM binding, AppControl appControl, string iconPath) : base(binding, appControl, iconPath)
    {
        SearchComponent = new SearchComponent(binding, appControl);
        SearchComponent.SearchAction += SelectedProductFromSearchList;
    }

    // Добавление найденого товара в текущий чек
    public void SelectedProductFromSearchList(Product product) {
        BuyProductVM newProduct = new BuyProductVM (product, product.SalePrice, 1);
        if (CheckList.AddProduct(newProduct)) {
            SelectedProduct = newProduct;
            IsBuy = true;
            CountProductText = $"Оплатить (позиций: {CheckList.BuyProducts.Count})";
            
            
        }
    }

    // Событие на потерю фокуса на нажатие клавиши "ENTER"
    public void textBox_KeyDown (object sender, KeyEventArgs e) {
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
    public void TextBoxPrice_TextChanged (object sender, TextChangedEventArgs e)
    {
        if (SelectedProduct is null) return;
        SelectedProduct.Price = double.Parse(((TextBox) sender).Text);
        UpdateTotalSumCheck ();
    }

    // Событие на изменение количество выбраного товара
    public void TextBoxCount_TextChanged (object sender, TextChangedEventArgs e) {
        if (SelectedProduct is null) return;
        SelectedProduct.Count = int.Parse (((TextBox) sender).Text);
        UpdateTotalSumCheck ();
    }
    
    public void TextBoxCashOrCard_TextChanged (object sender, TextChangedEventArgs e)
    {
        TextBox textBox = (TextBox)sender;
        switch (textBox.Tag)
        {
            case "Cash":
            {
                CheckList.ReceiptPaymentInfo.CashAmount = double.Parse(textBox.Text);
                break;
            }
            case "Card":
            {
                CheckList.ReceiptPaymentInfo.CardAmount = double.Parse(textBox.Text);
                break;
            }
        }
    }
    
    public void UIElement_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        e.Handled = !IsTextAllowed(e.Text);
    }
    
    public void UIElement_OnPreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Back || e.Key == Key.Delete || e.Key == Key.Tab ||
            e.Key == Key.Left || e.Key == Key.Right || e.Key == Key.Escape)
        {
            e.Handled = false;
        }
        else
        {
            e.Handled = !IsTextAllowed(e.Key.ToString());
        }
    }
    
    private bool IsTextAllowed(string text)
    {
        return text.All(char.IsDigit);
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
            SelectedProduct = (BuyProductVM) parameter;
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
        IsPayment = !IsPayment;
        CheckList.ReceiptPaymentInfo.CashAmount = 0;
        CheckList.ReceiptPaymentInfo.CardAmount = 0;
    }

    [RelayCommand]
    public void PayCardClick (object? parameter = null) {
        CheckList.ReceiptPaymentInfo.PaymentMethod = PaymentMethodVM.Card;
        CheckList.ReceiptPaymentInfo.CashAmount = 0;
    }


    [RelayCommand]
    public void PayCashClick (object? parameter = null) { 
        CheckList.ReceiptPaymentInfo.PaymentMethod = PaymentMethodVM.Cash;
        CheckList.ReceiptPaymentInfo.CardAmount = 0;
    }

    [RelayCommand]
    public void PaymentRequestCommand(object? parameter = null)
    {
        switch (CheckList.ReceiptPaymentInfo.PaymentMethod)
        {
            case PaymentMethodVM.Card:
            {
                AppControl.Server.SaveReceipt(CheckList);
                break;
            }
            case PaymentMethodVM.Cash:
            {
                AppControl.Server.SaveReceipt(CheckList);
                break;
            }
        }
    }
}