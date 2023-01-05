using System;
using System.Collections.Generic;
using Microsoft.UI.Xaml.Data;

namespace AC.View.Converters
{
    public class ValueConverterGroup : List<IValueConverter>, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            object returnValue = value;

            foreach (IValueConverter converter in this)
                returnValue = converter.Convert(returnValue, targetType, parameter, language);

            return returnValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
