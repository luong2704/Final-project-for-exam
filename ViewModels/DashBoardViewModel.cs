using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Campus.Models;
using Campus.Services;
using Campus.Session;

namespace Campus.ViewModels;

public partial class DashboardViewModel : ObservableObject
{
    private readonly IEventService _eventService;
    private List<Event> _allEvents = new();

    [ObservableProperty]
    private int totalEvents;

    [ObservableProperty]
    private int upcomingEvents;

    [ObservableProperty]
    private int attendedEvents;

    [ObservableProperty]
    private int savedEvents;

    [ObservableProperty]
    private ObservableCollection<Event> recentEvents = new();

    [ObservableProperty]
    private bool isLoading;

    [ObservableProperty]
    private string userName = string.Empty;

    [ObservableProperty]
    private string greetingMessage = string.Empty;

    public DashboardViewModel(IEventService eventService)
    {
        _eventService = eventService;
    }

    /// <summary>
    /// Khởi tạo lời chào dựa trên giờ trong ngày
    /// </summary>
    private void InitializeGreeting()
    {
        var user = AppSession.CurrentUser;
        if (user != null)
        {
            UserName = user.Username;
            GenerateGreetingMessage();
        }
    }

    /// <summary>
    /// Tạo lời chào thông minh dựa trên thời gian
    /// </summary>
    private void GenerateGreetingMessage()
    {
        var hour = DateTime.Now.Hour;
        var greeting = hour switch
        {
            >= 5 and < 12 => "Chào buổi sáng",
            >= 12 and < 17 => "Chào buổi chiều",
            >= 17 and < 21 => "Chào buổi tối",
            _ => "Chào đêm"
        };

        GreetingMessage = $"{greeting}, {UserName}! 👋";
    }

    /// <summary>
    /// Tải dữ liệu Dashboard: thống kê và sự kiện gần đây
    /// </summary>
    [RelayCommand]
    private async Task LoadDashboardDataAsync()
    {
        IsLoading = true;
        try
        {
            // Khởi tạo lời chào
            InitializeGreeting();

            // Lấy tất cả sự kiện từ service
            _allEvents = await _eventService.GetAllEventsAsync();

            // Tính toán các thống kê
            CalculateStatistics();

            // Load sự kiện gần đây
            LoadRecentEvents();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Lỗi tải Dashboard: {ex.Message}");
        }
        finally
        {
            IsLoading = false;
        }
    }

    /// <summary>
    /// Tính toán các thống kê: Tổng sự kiện, Sắp tới, Đã tham gia, Đã lưu
    /// </summary>
    private void CalculateStatistics()
    {
        // Tổng số sự kiện
        TotalEvents = _allEvents.Count;

        var now = DateTime.Now;

        // Sự kiện sắp tới: ngày diễn ra lớn hơn thời gian hiện tại
        UpcomingEvents = _allEvents.Count(e => e.Date > now);

        // Sự kiện đã tham gia: IsRegistered = true
        AttendedEvents = _allEvents.Count(e => e.IsRegistered);

        // Sự kiện đã lưu: đã đăng ký AND sắp tới
        SavedEvents = _allEvents.Count(e => e.IsRegistered && e.Date > now);
    }

    /// <summary>
    /// Load 5 sự kiện sắp tới gần nhất theo thứ tự thời gian
    /// </summary>
    private void LoadRecentEvents()
    {
        RecentEvents.Clear();

        var recent = _allEvents
            .Where(e => e.Date > DateTime.Now)          // Lọc sự kiện sắp tới
            .OrderBy(e => e.Date)                        // Sắp xếp theo ngày
            .Take(5)                                     // Lấy 5 sự kiện gần nhất
            .ToList();

        // Thêm vào ObservableCollection để UI cập nhật
        foreach (var evt in recent)
        {
            RecentEvents.Add(evt);
        }
    }

    /// <summary>
    /// Điều hướng đến trang chi tiết sự kiện
    /// </summary>
    [RelayCommand]
    private async Task ViewEventDetails(Event? selectedEvent)
    {
        if (selectedEvent == null) return;

        await Shell.Current.GoToAsync($"eventdetail?eventId={selectedEvent.Id}",
            new Dictionary<string, object> { { "Event", selectedEvent } });
    }

    /// <summary>
    /// Làm mới dữ liệu Dashboard
    /// </summary>
    [RelayCommand]
    private async Task RefreshDashboard()
    {
        await LoadDashboardDataAsync();
    }
}