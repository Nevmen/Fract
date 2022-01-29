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
                case(Sets.Mandelbrot): return "Множество Мадельброт";
                case(Sets.Julia): return "Множество Джулиа";
                case(Sets.Newton): return "Множество Ньютона";
                default: return "Выберите множество";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str = (string)value;
            if(str == "Множество Мадельброт") return Sets.Mandelbrot;
            if(str == "Множество Джулиа") return Sets.Julia;
            return Sets.Newton;
        }
    }
}
