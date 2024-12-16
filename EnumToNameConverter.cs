using System.Globalization;
using System.Windows.Data;

namespace avoVPN.Converters;

public class EnumToNameConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value switch
        {
            Enum enumValue => App.GetStringResource(enumValue),
            string str => str,
            _ => 0d
        };
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return 0d;
    }
}