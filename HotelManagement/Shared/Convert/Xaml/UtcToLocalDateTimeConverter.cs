using HotelManagement.Shared.Convert.Extensions;
using System;
using System.Globalization;
using System.Windows.Data;

namespace HotelManagement.Shared.Convert.Xaml
{
    public class UtcToLocalDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime date && date > DateTime.MinValue)
            {
                if (parameter is string paramPst && paramPst.ToSafeString().ToLower() == "pst")
                    return date.ToPst();
                else
                    //return date.ToLocalDateTime();
                    return date.ToLocalTime();
            }
            else
                return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
