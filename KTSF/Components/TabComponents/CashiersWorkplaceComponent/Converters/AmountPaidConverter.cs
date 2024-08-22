using System;
using System.Globalization;
using System.Windows.Data;
using KTSF.Contracts.CashiersWorkplace;

namespace KTSF.Components.TabComponents.CashiersWorkplaceComponent.Converters;

public class AmountPaidConverter : IValueConverter {
    public object Convert (object value, Type targetType, object parameter, CultureInfo culture) {
        PaymentInfo? paymentInfo = (PaymentInfo) value;
        if (paymentInfo == null)
            return null;
        else {
            return paymentInfo.CashAmount + paymentInfo.CardAmount;
        } 
    }

    public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException ();
    } 
}