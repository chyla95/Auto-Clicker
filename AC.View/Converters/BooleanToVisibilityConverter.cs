﻿using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;

namespace AC.View.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool boolean && boolean) return Visibility.Visible;
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is Visibility visibility && visibility == Visibility.Visible) return true;
            return false;
        }
    }
}
