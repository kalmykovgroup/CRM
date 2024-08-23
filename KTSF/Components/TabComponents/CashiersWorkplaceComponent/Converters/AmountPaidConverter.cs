using System;
using System.Globalization;
using System.Windows.Data;

namespace KTSF.Components.TabComponents.CashiersWorkplaceComponent.Converters;

public class AmountPaidConverter : IMultiValueConverter {
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        double result = ((double)values[0] + (double)values[1]) - (double)values[2];
        return result.ToString("F2", culture);
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
