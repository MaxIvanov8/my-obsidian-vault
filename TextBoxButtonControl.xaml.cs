using System.Windows;
using System.Windows.Input;

namespace avoVPN.Controls;

/// <summary>
/// Interaction logic for TextBoxButtonControl.xaml
/// </summary>
public partial class TextBoxButtonControl
{
	public static readonly DependencyProperty IsReadOnlyTextProperty = DependencyProperty.Register(nameof(IsReadOnlyText), typeof(bool), typeof(TextBoxButtonControl), new PropertyMetadata(default(bool)));
	public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(TextBoxButtonControl), new PropertyMetadata(default(string)));
	public static readonly DependencyProperty IconPathProperty = DependencyProperty.Register(nameof(IconPath), typeof(string), typeof(TextBoxButtonControl), new PropertyMetadata(default(string)));
	public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(TextBoxButtonControl), new PropertyMetadata(default(ICommand)));

	public TextBoxButtonControl()
	{
		InitializeComponent();
	}

	public ICommand Command
	{
		get => (ICommand)GetValue(CommandProperty);
		set => SetValue(CommandProperty, value);
	}

	public string IconPath
	{
		get => (string)GetValue(IconPathProperty);
		set => SetValue(IconPathProperty, value);
	}

	public string Text
	{
		get => (string)GetValue(TextProperty);
		set => SetValue(TextProperty, value);
	}

	public bool IsReadOnlyText
	{
		get => (bool)GetValue(IsReadOnlyTextProperty);
		set => SetValue(IsReadOnlyTextProperty, value);
	}

	private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
	{
		Text = Clipboard.GetText();
	}
}