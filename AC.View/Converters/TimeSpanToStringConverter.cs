using System;
using System.Globalization;
using Microsoft.UI.Xaml.Data;

namespace AC.View.Converters
{
    public class TimeSpanToStringConverter : IValueConverter
    {
        readonly string defaultFormat = @"hh\:mm\:ss";

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is null) return value;
            if (value is not TimeSpan) return value;

            string format = defaultFormat;
            if (parameter != null) format = parameter.ToString();

            string result = null;
            try
            {
                TimeSpan timeSpan = (TimeSpan)value;
                result = timeSpan.ToString(format);
            }
            catch (Exception) { }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is null) return value;

            string format = defaultFormat;
            if (parameter != null) format = parameter.ToString();

            TimeSpan result = TimeSpan.Zero;
            try
            {
                result = TimeSpan.ParseExact(value.ToString(), format, CultureInfo.InvariantCulture);
            }
            catch (Exception) { }
            return result;
        }
    }
}
