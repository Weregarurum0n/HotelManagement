using System;
using System.Globalization;
using System.Windows.Data;

namespace HotelManagement.Shared.Convert.Xaml
{
    public class NullToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter is string param && param.ToLower() == "inverse" ? value == null : value != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return false;
        }
    }
}
