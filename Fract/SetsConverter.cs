using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Fract
{
    public class SetsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var  sets = (Sets)value;
            switch(sets)
            {
                case(Sets.Mandelbrot): return "Мандельброт";
                case(Sets.Julia): return "Джулиа";
                case(Sets.Newton): return "Ньютон";
                default: return "Ньютон";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str = (string)value;
            if(str == "Мандельброт") return Sets.Mandelbrot;
            if(str == "Джулиа") return Sets.Julia;
            return Sets.Newton;
        }
    }
}
