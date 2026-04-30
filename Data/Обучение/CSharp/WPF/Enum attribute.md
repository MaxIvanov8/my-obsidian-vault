![[StringValueAttribute.cs]]

```
public class StringValueAttribute : Attribute
{
    public string StringValue { get; protected set; }

    public StringValueAttribute(string value)
    {
        var temp = App.GetStringResource(value);
        StringValue = temp ?? value;
    }
}
```

Конвертер для отображения: [[EnumToNameConverter]]

