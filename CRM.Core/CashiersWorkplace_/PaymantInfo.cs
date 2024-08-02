using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Core.CashiersWorkplace_;

public enum PaymentMethod {
    None,
    Cash,
    Card,
    Mixed
}

public class PaymentInfo {
    public double CashAmount { get; set; }
    public double CardAmount { get; set; }

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
            return PaymentMethod;
        }
        set { PaymentMethod = value; }
    }

    public PaymentInfo (double cashAmount, double cardAmount) {
        CashAmount = cashAmount;
        CardAmount = cardAmount; 
    }
}