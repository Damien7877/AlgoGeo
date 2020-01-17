using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace AlgogeoPresentation.Converters
{
    class BooleanToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool val = (bool)value;
            if (val)
                return new Uri("ms-appx:///Assets/green_tick-300x300.png");
            else
                return new Uri("ms-appx:///Assets/1465700203_f-cross_256.png");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
