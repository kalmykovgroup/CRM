using System;
using System.Globalization;
using System.Windows.Data;

namespace KTSF.Components.TabComponents.CashiersWorkplaceComponent.Converters;

public class DiscountedTotalConverter : IValueConverter {
    public object Convert (object value, Type targetType, object parameter, CultureInfo culture) {
        if (value is double totalSum && parameter is double discount) {
            return totalSum - (totalSum * discount / 100);
        }
        return 0;
    }

    public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException ();
    }
}