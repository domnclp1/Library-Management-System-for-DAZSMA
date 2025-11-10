using System;
using System.Globalization;
using System.Windows.Data;

namespace Library_Management_System_for_DAZSMA.Converters
{
    // Returns a glyph for eye / eye-with-slash depending on boolean (true -> eye-with-slash)
    public class EyeIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b && b)
                return "\uE8D4"; // eye with slash
            return "\uE7B3"; // eye
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
