using System.Globalization;

namespace Campus.Converters;

/// <summary>
/// Converts bool => Color: true = #22C55E (green success), false = #EF4444 (red error)
/// </summary>
public class BoolToColorConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        => value is true ? Color.FromArgb("#22C55E") : Color.FromArgb("#EF4444");

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}
