using HotelManagement.Shared.Convert.Extensions;
using System;
using System.Globalization;
using System.Windows.Data;

namespace HotelManagement.Shared.Convert.Xaml
{
    public class StringToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.IsNullOrEmpty(value.ToSafeString()) ? 0 : value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.IsNullOrEmpty(value.ToSafeString()) ? 0 : value;
        }
    }
}
