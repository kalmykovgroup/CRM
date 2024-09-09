using KTSF.Components;
using KTSF.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace KTSF.Components.Windows.MainMenuWinComponent.Converters
{
    public class QualsComponentUserVMToBoolConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Component Component = (Component)values[0];
            UserControl UserControl = (UserControl)values[1];

            return Component.UserControl == UserControl;
             
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
