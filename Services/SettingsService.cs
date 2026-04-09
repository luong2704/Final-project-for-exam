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
            var language = Preferences.Default.Get(LanguageKey, "English");

            return new SettingsPreferences
            {
                ThemeMode = (ThemeMode)themeValue,
                NotificationsEnabled = notificationsEnabled,
                Language = language
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

        public void SaveLanguage(string language)
        {
            Preferences.Default.Set(LanguageKey, language);
        }

        public string GetLanguage()
        {
            return Preferences.Default.Get(LanguageKey, "English");
        }
    }
}