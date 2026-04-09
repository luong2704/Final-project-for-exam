using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace Campus.Converters
{
	public class StatusColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var status = value?.ToString();

			return status switch
			{
				"Live" => Color.FromArgb("#C6F6D5"),
				"Featured" => Color.FromArgb("#BEE3F8"),
				"Popular" => Color.FromArgb("#FED7D7"),
				"Limited" => Color.FromArgb("#FEFCBF"),

				// bonus 
				"Upcoming" => Color.FromArgb("#C6F6D5"),
				"Cancelled" => Color.FromArgb("#FEB2B2"),
				_ => Color.FromArgb("#EDF2F7")
			};
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
