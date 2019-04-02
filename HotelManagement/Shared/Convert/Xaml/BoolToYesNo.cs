using System;
using System.Windows.Data;

namespace HotelManagement.Shared.Convert.Xaml
{
    public class BoolToYesNo : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {

            bool visibility = (bool)value;

            if (visibility)
            {
                return "Yes";
            }

            return parameter is string param && param.ToLower() == "hideno" ? "" : "No";
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
