using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace avoVPN.Converters;

public class StringToVisibilityConverter : IValueConverter
{
    public bool Inverted { private get; set; }

    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if(value is string str)
        {
            if (string.IsNullOrEmpty(str))
                return Inverted ? Visibility.Visible : Visibility.Hidden;
            return Inverted ? Visibility.Hidden : Visibility.Visible;
        }
        return 0d;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return 0d;
    }
}