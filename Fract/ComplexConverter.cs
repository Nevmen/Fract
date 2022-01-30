using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Fract
{
    public class ComplexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var c = (Complex)value;
            return c.Real.ToString() + " + " + c.Imaginary.ToString() + "i";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null)
            {
                string str = (string)value;
                str = str.Replace(" ","").Trim('i');
                var strarr = str.Split('+');
                IFormatProvider fornatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
                double x = double.Parse(strarr[0], fornatter);
                var y = double.Parse(strarr[1], fornatter);
                Complex c = new Complex(x, y);
                return c;
            }
            return null;
        }
    }
}
