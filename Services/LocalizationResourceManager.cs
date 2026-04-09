using Campus.Resources.Strings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace Campus.Services
{
    public class LocalizationResourceManager : INotifyPropertyChanged
    {
        private static readonly LocalizationResourceManager _instance = new();
        public static LocalizationResourceManager Instance => _instance;

        private LocalizationResourceManager()
        {
            AppResources.Culture = CultureInfo.CurrentCulture;
        }

        public string this[string resourceKey]
        {
            get => AppResources.ResourceManager.GetString(resourceKey, AppResources.Culture) ?? string.Empty;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void SetCulture(CultureInfo culture)
        {
            AppResources.Culture = culture;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}
