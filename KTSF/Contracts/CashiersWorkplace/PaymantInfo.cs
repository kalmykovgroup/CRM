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

public partial class PaymentInfo: ObservableObject {

    public double CashAmount { get; set; }
    public double CardAmount { get; set; }

    private PaymentMethod paymentMethod;

    
    public PaymentMethod PaymentMethod {
        get {
            //if (CashAmount > 0 && CardAmount > 0)
            //    return PaymentMethod.Mixed;
            //else if (CashAmount > 0)
            //    return PaymentMethod.Cash;
            //else if (CardAmount > 0)
            //    return PaymentMethod.Card;
            //else
            //    return PaymentMethod.None;
            return paymentMethod;
        }
        set { SetProperty(ref paymentMethod, value); }
    }

    public PaymentInfo (double cashAmount, double cardAmount) {
        CashAmount = cashAmount;
        CardAmount = cardAmount; 
    }
}