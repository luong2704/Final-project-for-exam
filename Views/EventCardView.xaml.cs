using System.Windows.Input;

namespace Campus.Views;

public partial class EventCardView : ContentView
{
	public static readonly BindableProperty UnregisterCommandProperty =
		BindableProperty.Create(nameof(UnregisterCommand), typeof(ICommand), typeof(EventCardView));

	public ICommand UnregisterCommand
	{
		get => (ICommand)GetValue(UnregisterCommandProperty);
		set => SetValue(UnregisterCommandProperty, value);
	}

	public EventCardView()
	{
		InitializeComponent();
	}
}
