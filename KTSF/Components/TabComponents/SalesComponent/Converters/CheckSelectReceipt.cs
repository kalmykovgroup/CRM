using System.Globalization;
using System.Windows.Data;
using KTSF.Contracts.CashiersWorkplace;

namespace KTSF.Components.TabComponents.SalesComponent.Converters;

public class CheckSelectReceipt : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if ((ReceiptVM)value is null)
            return "Visible";
        else
            return "Hidden";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}