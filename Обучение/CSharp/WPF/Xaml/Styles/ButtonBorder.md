```
 <Style x:Key="ButtonRounded" TargetType="{x:Type Button}">
     <Setter Property="Cursor" Value="Hand"/>
     <Setter Property="Template">
         <Setter.Value>
             <ControlTemplate TargetType="{x:Type Button}">
                 <Border x:Name="Border" Background="{TemplateBinding Background}" CornerRadius="4">
                     <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center" />
                 </Border>
                 <ControlTemplate.Triggers>
                     <Trigger Property="IsMouseOver" Value="True">
                         <Setter Property="Background" Value="#0257A7" TargetName="Border" />
                         <Setter Property="Foreground" Value="#FFFFFF" />
                     </Trigger>
                 </ControlTemplate.Triggers>
             </ControlTemplate>
         </Setter.Value>
     </Setter>
 </Style>
```
