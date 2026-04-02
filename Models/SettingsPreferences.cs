using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.Models
{
    public class SettingsPreferences
    {
        public ThemeMode ThemeMode { get; set; } = ThemeMode.Light;
        public bool NotificationsEnabled { get; set; } = true;
    }
}