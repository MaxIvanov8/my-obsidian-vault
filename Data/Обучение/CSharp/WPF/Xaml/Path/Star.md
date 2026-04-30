```
<Path Stretch="Fill" Stroke="Black" StrokeThickness="10" Data="F1 M 126.578613,11.297852 L 162.373535,83.825684 L 242.412598,95.456055 L 184.495605,151.911133 L 198.167480,231.626953 L 126.578613,193.990234 L 54.988770,231.626953 L 68.661621,151.911133 L 10.744629,95.456055 L 90.783691,83.825684 L 126.578613,11.297852 Z">
    <Path.Style>
        <Style TargetType="Path">
            <Style.Triggers>
                <DataTrigger Binding="{Binding IsChecked, RelativeSource={RelativeSource AncestorType={x:Type ToggleButton}}}" Value="True">
                    <Setter Property="Fill" Value="Black" />
                </DataTrigger>
                <DataTrigger Binding="{Binding IsChecked, RelativeSource={RelativeSource AncestorType={x:Type ToggleButton}}}" Value="False">
                    <Setter Property="Fill" Value="Transparent" />
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </Path.Style>
</Path>
```
