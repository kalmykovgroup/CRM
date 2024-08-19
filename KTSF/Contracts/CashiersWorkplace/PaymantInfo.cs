using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Contracts.CashiersWorkplace;

public enum PaymentMethod {
    None,
    Cash,
    Card,
    Mixed
}

public partial class PaymentInfo : ObservableObject {

    [ObservableProperty] public double cashAmount;
    [ObservableProperty] public double cardAmount;

    private PaymentMethod paymentMethod;

    public PaymentMethod PaymentMethod {
        get { return paymentMethod; }
        set { paymentMethod = value; }
    }

    public PaymentInfo (double cashAmount, double cardAmount) {
        CashAmount = cashAmount;
        CardAmount = cardAmount; 
    }
}