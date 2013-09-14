using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace WPFIntroduction
{
    public class ColorValuesToBrushConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new SolidColorBrush(new Color { R = System.Convert.ToByte(values[0]), G = System.Convert.ToByte(values[1]), B = System.Convert.ToByte(values[2]), A = System.Convert.ToByte(255) });
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
