using AlgogeoPresentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace AlgogeoPresentation.Converters
{
    class ChangeScaleXConverter : IValueConverter 
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            double val = (double)value;
            double size = (val - 0.5) * Const.SIZE;
            return size + (Const.OFFSET_X - size/2);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
