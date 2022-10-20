using System;
using System.Globalization;
using Xamarin.Forms;

namespace VistaLifeSampleApp.Converters
{
    public class StringToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stringTuple = value as string;
            var stringArray = stringTuple.Split(';');

            if (stringArray == null) return false;

            bool isEnabled = !string.IsNullOrEmpty(stringArray[0]) && !string.IsNullOrEmpty(stringArray[1]);
            return isEnabled;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
