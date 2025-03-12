using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace ThemeEditor.WPF.Templating
{
    public class ColorStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Converts hex string to SolidColorBrush
            if (value is string hexColor)
            {
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString(hexColor));
            }
            return Brushes.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null; // Not necessary for one-way binding
        }
    }

}

