using System;
using System.Globalization;
using Xamarin.Forms;

namespace IsEnabledIssue.Views.Converters
{
    public class InvertBooleanConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool valueToConvert = (bool)value;
            return !valueToConvert;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
