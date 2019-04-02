using HotelManagement.Shared.Convert.Extensions;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace HotelManagement.Shared.Convert.Xaml
{
    public class NullToVisConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is string param && param.ToSafeString().ToLower() == "inverse")
            {
                return string.IsNullOrEmpty(value.ToSafeString()) ? Visibility.Visible : Visibility.Collapsed;
            }
            else if (parameter is string param2 && param2.ToSafeString().ToLower() == "inversehidden")
            {
                return string.IsNullOrEmpty(value.ToSafeString()) ? Visibility.Visible : Visibility.Hidden;
            }
            else
            {
                return !string.IsNullOrEmpty(value.ToSafeString()) ? Visibility.Visible : parameter.ToSafeString().ToLower() == "hidden" ? Visibility.Hidden : Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Visibility.Visible;
        }
    }
}
