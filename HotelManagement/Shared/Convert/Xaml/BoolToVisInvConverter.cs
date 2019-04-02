using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace HotelManagement.Shared.Convert.Xaml
{
    public class BoolToVisInvConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && (bool)value ?  Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Visibility.Collapsed;
        }
    }
}
