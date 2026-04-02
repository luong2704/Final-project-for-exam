using CommunityToolkit.Mvvm.ComponentModel;

namespace Campus.Models
{
	public partial class Event : ObservableObject
	{
		public Guid Id { get; set; }

		public string Title { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;

		public DateTime Date { get; set; }

		public string Location { get; set; } = string.Empty;

		public string Image { get; set; } = string.Empty;

		public string Category { get; set; } = string.Empty;

		// 🔥 giữ MVVM observable
		[ObservableProperty]
		private bool _isRegistered;

		// 🔥 giữ status cho Task 3.5
		public string Status { get; set; } = string.Empty;
	}
}
