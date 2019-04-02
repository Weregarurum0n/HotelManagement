using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace HotelManagement.Shared.Convert.Xaml
{
    public class ButtonParamsConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var ret =  values.ToArray();
            return ret;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
