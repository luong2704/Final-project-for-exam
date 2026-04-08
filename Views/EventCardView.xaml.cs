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

    public static readonly BindableProperty TapCommandProperty =
        BindableProperty.Create(nameof(TapCommand), typeof(ICommand), typeof(EventCardView));

    public ICommand TapCommand
    {
        get => (ICommand)GetValue(TapCommandProperty);
        set => SetValue(TapCommandProperty, value);
    }

    public static readonly BindableProperty ShowActionsProperty =
        BindableProperty.Create(nameof(ShowActions), typeof(bool), typeof(EventCardView), true);

    public bool ShowActions
    {
        get => (bool)GetValue(ShowActionsProperty);
        set => SetValue(ShowActionsProperty, value);
    }

    public EventCardView()
    {
        InitializeComponent();
    }
}
