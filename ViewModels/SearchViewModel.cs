using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using Campus.Models;
using Campus.Services;   // ✅ thêm
using System.Threading.Tasks;

namespace Campus.ViewModels;

public class SearchViewModel : INotifyPropertyChanged
{
	// ✅ gọi backend service
	private readonly SearchService service = new();

	public ObservableCollection<Event> Events { get; set; }

	private List<Event> allEvents;

	// ================= FILTER LIST =================
	public List<string> Categories { get; } = new()
	{
		"All",
		"Sport",
		"Music",
		"Tech",
		"Social"
	};

	private string selectedCategory = "All";
	public string SelectedCategory
	{
		get => selectedCategory;
		set
		{
			if (selectedCategory == value) return;

			selectedCategory = value;
			OnPropertyChanged();

			_ = PerformSearch();
		}
	}

	// ================= SEARCH TEXT =================
	private string searchText = string.Empty;
	public string SearchText
	{
		get => searchText;
		set
		{
			if (searchText == value) return;

			searchText = value;
			OnPropertyChanged();

			// 🔥 gọi search async
			_ = PerformSearch();
		}
	}

	// ================= CONSTRUCTOR =================
	public SearchViewModel()
	{
		allEvents = MockData();
		Events = new ObservableCollection<Event>(allEvents);
	}

	// ✅ SEARCH THẬT (API) + fallback local
	async Task PerformSearch()
	{
		if (string.IsNullOrWhiteSpace(SearchText))
		{
			ResetList();
			return;
		}

		try
		{
			// ===== CALL API =====
			var result = await service.Search(SearchText);

			Events.Clear();

			foreach (var e in result)
				Events.Add(e);
		}
		catch
		{
			// ✅ nếu API chưa chạy → dùng local search
			LocalSearch();
		}
	}

	// ================= APPLY FILTER =================
	void ApplyFilter(IEnumerable<Event> source)
	{
		var query = source.AsEnumerable();

		// TEXT SEARCH
		if (!string.IsNullOrWhiteSpace(SearchText))
		{
			query = query.Where(e =>
				e.Title.Contains(SearchText,
				StringComparison.OrdinalIgnoreCase));
		}

		// CATEGORY FILTER
		if (SelectedCategory != "All")
		{
			query = query.Where(e =>
				e.Category == SelectedCategory);
		}

		Events.Clear();

		foreach (var e in query)
			Events.Add(e);
	}

	// ================= LOCAL SEARCH BACKUP =================
	void LocalSearch()
	{
		ApplyFilter(allEvents);
	}

	void ResetList()
	{
		Events.Clear();

		foreach (var e in allEvents)
			Events.Add(e);
	}

	List<Event> MockData()
	{
		return new()
		{
			new Event { Title = "Volleyball Tournament", Category = "Sport" },
			new Event { Title = "Music Festival", Category = "Music" },
			new Event { Title = "Tech Talk: Introduction to .NET MAUI", Category = "Tech" },
			new Event { Title = "Workshop: UI/UX Design Principles", Category = "Tech"},
			new Event { Title = "Career Fair 2026", Category = "Social"}

		};
	}

	public event PropertyChangedEventHandler? PropertyChanged;

	void OnPropertyChanged([CallerMemberName] string name = "")
		=> PropertyChanged?.Invoke(this,
			new PropertyChangedEventArgs(name));
}