using System;
using System.Globalization;
using System.Windows.Data;

namespace HotelManagement.Shared.Convert.Xaml
{
    public class RadioBtnConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter != null && (value != null && value.ToString().Equals(parameter.ToString()));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && value.Equals(true) ? parameter : Binding.DoNothing;
        }
    }
}
