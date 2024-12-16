using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace avoVPN.Converters;

public class BoolToVisibilityConverter : IValueConverter
{
    public bool UseHidden { private get; set; }

    public bool Inverted { private get; set; }
    private Visibility IsHidden => UseHidden ? Visibility.Hidden : Visibility.Collapsed;

    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if(value is bool valueBool)
        {
            if (valueBool)
                return Inverted ? IsHidden : Visibility.Visible;
            return Inverted ? Visibility.Visible : IsHidden;
        }
        return 0d;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is Visibility visibility)
        {
            var isVisible = visibility == Visibility.Visible;
            return Inverted ? !isVisible : isVisible;
        }
        return 0d;
    }
}