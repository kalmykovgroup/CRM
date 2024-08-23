using CommunityToolkit.Mvvm.ComponentModel;

namespace KTSF.Core.Receipt_;

public enum PaymentMethod {
    None,
    Cash,
    Card,
    Mixed
}

public partial class PaymentInfo : ObservableObject {

    [ObservableProperty] public double cashAmount;
    [ObservableProperty] public double cardAmount;
     
    [ObservableProperty] private double totalSum;
    [ObservableProperty] private double amountPaid;

    [ObservableProperty] private PaymentMethod paymentMethod;

    public PaymentInfo (double cashAmount, double cardAmount) {
        CashAmount = cashAmount;
        CardAmount = cardAmount; 
    }
}