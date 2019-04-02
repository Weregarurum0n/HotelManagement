using HotelManagement.Shared.Convert.Extensions;
using System;
using System.Globalization;
using System.Windows.Data;

namespace HotelManagement.Shared.Convert.Xaml
{
    public class LocalToUtcDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTime)
            {
                return dateTime.ToUtcDateTime();
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
