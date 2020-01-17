using AlgogeoPresentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace AlgogeoPresentation.Converters
{
    class DisplayModeToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DisplayModeEnum val = (DisplayModeEnum)value;
             if (val == DisplayModeEnum.EXECUTE)
                return false;

            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
