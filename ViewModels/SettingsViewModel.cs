using Campus.Models;
using Campus.Services;
using Campus.Session;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Campus.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        private readonly SettingsService _settingsService;
        public event PropertyChangedEventHandler? PropertyChanged;

        private string? _fullName;
        public string? FullName
        {
            get => _fullName;
            set { _fullName = value; OnPropertyChanged(); }
        }

        private string? _email;
        public string? Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); }
        }

        private string? _studentId;
        public string? StudentId
        {
            get => _studentId;
            set { _studentId = value; OnPropertyChanged(); }
        }

        private bool _isDarkMode;
        public bool IsDarkMode
        {
            get => _isDarkMode;
            set
            {
                if (_isDarkMode != value)
                {
                    _isDarkMode = value;
                    OnPropertyChanged();
                    ApplyThemeChange(value);
                }
            }
        }

        private string _themeLabel = "LIGHT";
        public string ThemeLabel
        {
            get => _themeLabel;
            set { _themeLabel = value; OnPropertyChanged(); }
        }

        private bool _isNotificationsEnabled;
        public bool IsNotificationsEnabled
        {
            get => _isNotificationsEnabled;
            set
            {
                if (_isNotificationsEnabled == value) return;
                _isNotificationsEnabled = value;
                OnPropertyChanged();
                _settingsService.SaveNotificationsEnabled(value);
            }
        }

        private string? _selectedLanguage;
        public string? SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                if (_selectedLanguage == value) return;
                _selectedLanguage = value;
                OnPropertyChanged();

                if (!string.IsNullOrWhiteSpace(value))
                {
                    _settingsService.SaveLanguage(value);
                }
            }
        }

        public ObservableCollection<string> SupportedLanguages { get; } = new ObservableCollection<string>
        {
            "English",    
            "Vietnamese"
        };

        
        public SettingsViewModel()
        {
            _settingsService = new SettingsService();

           
            var user = AppSession.CurrentUser;
            if (user != null)
            {
                FullName = user.Username;
                Email = user.Email;
                StudentId = user.StudentId;
            }

            // Lấy cài đặt Theme & Notification
            var currentSettings = _settingsService.GetSettings();
            _isDarkMode = currentSettings.ThemeMode == ThemeMode.Dark;
            ThemeLabel = _isDarkMode ? "DARK" : "LIGHT";
            _isNotificationsEnabled = currentSettings.NotificationsEnabled;

            _selectedLanguage = _settingsService.GetLanguage();
            if (string.IsNullOrWhiteSpace(_selectedLanguage))
            {
                _selectedLanguage = SupportedLanguages[0];
            }
        }

        private void ApplyThemeChange(bool isDark)
        {
            _settingsService.SaveThemeMode(isDark ? ThemeMode.Dark : ThemeMode.Light);
            
            if (Application.Current != null)
            {
                Application.Current.UserAppTheme = isDark ? AppTheme.Dark : AppTheme.Light;
            }
            
            ThemeLabel = isDark ? "DARK" : "LIGHT";
        }

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}