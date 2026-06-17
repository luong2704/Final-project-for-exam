using Microsoft.Extensions.Logging;
using Campus.Services;
using Campus.ViewModels;
using Campus.Views;

namespace Campus
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Services
            builder.Services.AddSingleton<ICategoryService, CategoryService>();
            builder.Services.AddSingleton<IEventService, MockEventService>();
            builder.Services.AddSingleton<CampusService>();
            builder.Services.AddSingleton<SettingsService>();

            // ViewModels
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<MainEventViewModel>();
            builder.Services.AddTransient<EventListViewModel>();
            builder.Services.AddTransient<EventViewModels>(); // Used by MyEventsPage
            builder.Services.AddTransient<CategoryViewModel>();
            builder.Services.AddTransient<DashboardViewModel>();
            builder.Services.AddTransient<EventDetailViewModel>();
            builder.Services.AddTransient<RegistrationViewModel>();
            builder.Services.AddTransient<SearchViewModel>();
            builder.Services.AddTransient<ProfileViewModel>();
            builder.Services.AddTransient<SettingsViewModel>();

            // Pages (Registered for DI because some have parameterized constructors)
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<Views.EventListPage>();
            builder.Services.AddTransient<Views.MyEventsPage>();
            builder.Services.AddTransient<Views.CategoryFilterView>();
            builder.Services.AddTransient<Views.DashboardPage>();
            builder.Services.AddTransient<Views.SearchPage>();
            builder.Services.AddTransient<Views.ProfilePage>();
            builder.Services.AddTransient<RegistrationPage>();
            builder.Services.AddTransient<EventDetailPage>();

            builder.Services.AddTransient<MainPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // Routing
            Routing.RegisterRoute("EventDetailPage", typeof(EventDetailPage));
            Routing.RegisterRoute("categoryfilter", typeof(CategoryFilterView));
            Routing.RegisterRoute(nameof(Views.DashboardPage), typeof(Views.DashboardPage));
            Routing.RegisterRoute("EventRegistrationPage", typeof(Views.RegistrationPage));
            Routing.RegisterRoute("EventListPage", typeof(Views.EventListPage));

            return builder.Build();
        }
    }
}
