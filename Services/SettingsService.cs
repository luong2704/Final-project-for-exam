using System;
using System.Collections.Generic;
using System.Text;
using Campus.Models;
using Microsoft.Maui.Storage;

namespace Campus.Services
{
    public class SettingsService
    {
        private const string ThemeKey = "settings_theme_mode";
        private const string NotificationKey = "settings_notifications_enabled";
        private const string LanguageKey = "settings_language";


        public SettingsPreferences GetSettings()
        {
            var themeValue = Preferences.Default.Get(ThemeKey, (int)ThemeMode.Light);
            var notificationsEnabled = Preferences.Default.Get(NotificationKey, true);

            return new SettingsPreferences
            {
                ThemeMode = (ThemeMode)themeValue,
                NotificationsEnabled = notificationsEnabled
            };
        }

        public void SaveThemeMode(ThemeMode themeMode)
        {
            Preferences.Default.Set(ThemeKey, (int)themeMode);
        }

        public void SaveNotificationsEnabled(bool enabled)
        {
            Preferences.Default.Set(NotificationKey, enabled);
        }
    }
}