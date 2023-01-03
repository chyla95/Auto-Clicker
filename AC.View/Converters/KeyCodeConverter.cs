using System;
using Microsoft.UI.Xaml.Data;
using PeripheralDeviceEmulator.Constants;

namespace AC.View.Converters
{
    public class KeyCodeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return Enum.Parse(typeof(KeyCode), value.ToString());
        }
    }
}
