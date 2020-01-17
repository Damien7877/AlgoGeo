using AlgogeoPresentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace AlgogeoPresentation.Converters
{
    class DisplayModeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DisplayModeEnum val = (DisplayModeEnum)value;
            if (val == DisplayModeEnum.MODELE)
                return new SolidColorBrush( Colors.Gray);
            else if (val == DisplayModeEnum.EXECUTE)
                return new SolidColorBrush(Colors.Black);
            return new SolidColorBrush(Colors.Gray);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
