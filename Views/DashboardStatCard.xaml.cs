namespace Campus.Views;

public partial class DashboardStatCard : ContentView
{
    // ── Title ──────────────────────────────────────────────────────────────
    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(
            propertyName: nameof(Title),
            returnType: typeof(string),
            declaringType: typeof(DashboardStatCard),
            defaultValue: string.Empty);

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    // ── Value ──────────────────────────────────────────────────────────────
    public static readonly BindableProperty ValueProperty =
        BindableProperty.Create(
            propertyName: nameof(Value),
            returnType: typeof(int),
            declaringType: typeof(DashboardStatCard),
            defaultValue: 0);

    public int Value
    {
        get => (int)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    // ── AccentColor ────────────────────────────────────────────────────────
    public static readonly BindableProperty AccentColorProperty =
        BindableProperty.Create(
            propertyName: nameof(AccentColor),
            returnType: typeof(Color),
            declaringType: typeof(DashboardStatCard),
            defaultValue: Colors.Black);

    public Color AccentColor
    {
        get => (Color)GetValue(AccentColorProperty);
        set => SetValue(AccentColorProperty, value);
    }

    public DashboardStatCard()
    {
        InitializeComponent();
    }
}
