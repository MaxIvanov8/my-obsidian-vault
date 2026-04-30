![[EnumToNameConverter.cs]]

```
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
```

```
public static string GetStringResource(string name) =>
	avoVPN.Properties.Resources.ResourceManager.GetString(name);

public static string GetStringResource(Enum enumValue) => GetStringResource(enumValue.ToString());
```
