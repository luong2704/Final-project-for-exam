namespace Campus.Services
{
    public interface ISettingsService
    {
        
        Task<Models.SettingsPreferences> GetSettingsAsync();

        
        Task SaveSettingsAsync(Models.SettingsPreferences settings);
        
        void ApplyTheme(string theme);
    }
}