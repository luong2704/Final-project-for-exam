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

            builder.Services.AddSingleton<ICategoryService, CategoryService>();
            builder.Services.AddSingleton<IEventService, MockEventService>();
            builder.Services.AddTransient<EventViewModels>();
            builder.Services.AddTransient<RegistrationViewModel>();
            builder.Services.AddTransient<Views.MyEventsPage>();
            builder.Services.AddTransient<EventDetailViewModel>();
            builder.Services.AddTransient<CategoryViewModel>();

            // Task 6, 7, 9 — Shania's centralized ViewModel + pages
            builder.Services.AddTransient<MainEventViewModel>();
            builder.Services.AddTransient<Views.EventListPage>();
            builder.Services.AddTransient<Views.EventDetailPage>();

            // Dashboard ViewModel and Page
            builder.Services.AddTransient<DashboardViewModel>();
            builder.Services.AddTransient<Views.DashboardPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            Routing.RegisterRoute("categoryfilter", typeof(CategoryFilterView));
            Routing.RegisterRoute(nameof(Views.EventDetailPage), typeof(Views.EventDetailPage));
            Routing.RegisterRoute(nameof(Views.DashboardPage), typeof(Views.DashboardPage));

            return builder.Build();
        }
    }
}
