
using Campus.Models;

namespace Campus.App
{
    public static class AppSession
    {
        public static User CurrentUser { get; set; }

        public static bool IsLoggedIn => CurrentUser != null;

        public static void Logout()
        {
            CurrentUser = null;
        }
    }
}