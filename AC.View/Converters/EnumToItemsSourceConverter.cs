using System;
using Microsoft.UI.Xaml.Data;

namespace AC.View.Converters
{
    class EnumToItemsSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Type valueType = value.GetType();
            if (!valueType.IsEnum) throw new Exception("Value must be of type Enum!");

            Array values = Enum.GetValues(valueType);
            //List<object> descriptionValues = new();
            //foreach (object item in values) descriptionValues.Add(GetDescription(item));

            return values;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        //private static string GetDescription(object o)
        //{
        //    return o.GetType().GetMember(o.ToString()).First().GetCustomAttribute<DescriptionAttribute>().Description;
        //}
    }
}
