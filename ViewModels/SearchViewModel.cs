using Campus.Models;
using Campus.Services;   // ✅ thêm
using Campus.Views;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

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
    // Cập nhật lại hàm PerformSearch
    async Task PerformSearch()
    {
        IEnumerable<Event> sourceData;

        try
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                // Nếu không search text -> lấy toàn bộ data gốc
                sourceData = allEvents;
            }
            else
            {
                // Gọi API lấy kết quả theo SearchText
                var apiResult = await service.Search(SearchText);
                sourceData = apiResult;

                // Nếu API không trả về gì hoặc lỗi, fallback về local search
                if (apiResult == null || !apiResult.Any())
                    sourceData = allEvents.Where(e => e.Title.Contains(SearchText, StringComparison.OrdinalIgnoreCase));
            }
        }
        catch
        {
            // Fallback local nếu API sập
            sourceData = allEvents.Where(e => e.Title.Contains(SearchText, StringComparison.OrdinalIgnoreCase));
        }

        // Sau khi có nguồn dữ liệu (từ API hoặc Local), tiến hành lọc theo Category
        ApplyFilter(sourceData);
    }

    // Hàm này đóng vai trò "chốt chặn" cuối cùng để hiển thị lên UI
    void ApplyFilter(IEnumerable<Event> source)
    {
        var query = source.AsEnumerable();

        // Lọc theo Category nếu người dùng chọn khác "All"
        if (SelectedCategory != "All")
        {
            query = query.Where(e => e.Category == SelectedCategory);
        }

        // Cập nhật ObservableCollection trên UI thread
        MainThread.BeginInvokeOnMainThread(() => {
            Events.Clear();
            foreach (var e in query)
            {
                Events.Add(e);
            }
        });
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

    public ICommand GoToEventDetailCommand => new Command<Event>(async (selectedEvent) =>
    {
        if (selectedEvent == null) return;

        await Shell.Current.GoToAsync(nameof(EventDetailPage), true, new Dictionary<string, object>
    {
        { "Event", selectedEvent }
    });
    });
}