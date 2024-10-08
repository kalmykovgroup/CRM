﻿using CommunityToolkit.Mvvm.ComponentModel;
using KTSF.Core.Receipt_;

namespace KTSF.Contracts.CashiersWorkplace;

public partial class PaymentInfoVM : ObservableObject {

    [ObservableProperty] public double cashAmount;
    [ObservableProperty] public double cardAmount;
     
    [ObservableProperty] private double totalSum;
    [ObservableProperty] private double amountPaid;

    [ObservableProperty] private PaymentMethodVM paymentMethod;

    public PaymentInfoVM (double cashAmount, double cardAmount) {
        CashAmount = cashAmount;
        CardAmount = cardAmount; 
    }
}

public enum PaymentMethodVM {
    None = 1,
    Cash,
    Card,
    Mixed
}