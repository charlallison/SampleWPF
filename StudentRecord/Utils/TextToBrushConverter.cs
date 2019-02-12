using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace StudentRecord.Utils
{
    public class TextToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var arguement = (string)value;
            if (arguement == null) { return null; }
            return Brushes.Red;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
