using Campus.Session;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Campus.ViewModels;

public class ProfileViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    private string? _email;
    public string? Email
    {
        get => _email;
        set
        {
            _email = value;
            OnPropertyChanged();
        }
    }

    private string? _fullName;
    public string? FullName
    {
        get => _fullName;
        set
        {
            _fullName = value;
            OnPropertyChanged();
        }
    }

    private string? _studentId;
    public string? StudentId
    {
        get => _studentId;
        set
        {
            _studentId = value;
            OnPropertyChanged();
        }
    }

    public ICommand LogoutCommand { get; }

    public ProfileViewModel()
    {
        var user = AppSession.CurrentUser;

        if (user != null)
        {
            FullName = user.Username;
            Email = user.Email;
            StudentId = user.StudentId;
        }

        LogoutCommand = new Command(OnLogout);
    }

    private async void OnLogout()
    {
        AppSession.Logout();
        await Shell.Current.GoToAsync("//LoginPage");
    }
}