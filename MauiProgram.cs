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
            builder.Services.AddTransient<Views.RegistrationPage>();
            builder.Services.AddTransient<Views.MyEventsPage>();
            builder.Services.AddTransient<EventDetailViewModel>();
            builder.Services.AddTransient<EventDetailPage>();  // Team 3
            builder.Services.AddTransient<CategoryViewModel>();

<<<<<<< team-8-Dashboard-statistics-cards
            // Task 6, 7, 9 — Shania's centralized ViewModel + pages
            builder.Services.AddTransient<MainEventViewModel>();
            builder.Services.AddTransient<Views.EventListPage>();
            builder.Services.AddTransient<Views.EventDetailPage>();

            // Dashboard ViewModel and Page
            builder.Services.AddTransient<DashboardViewModel>();
            builder.Services.AddTransient<Views.DashboardPage>();
=======
            builder.Services.AddSingleton<CampusService>();
            builder.Services.AddTransient<MainPage>();

            
>>>>>>> main

#if DEBUG
            builder.Logging.AddDebug();
#endif

            Routing.RegisterRoute("EventDetailPage", typeof(EventDetailPage));          // Team 3
            Routing.RegisterRoute("categoryfilter", typeof(CategoryFilterView));
<<<<<<< team-8-Dashboard-statistics-cards
            Routing.RegisterRoute(nameof(Views.EventDetailPage), typeof(Views.EventDetailPage));
            Routing.RegisterRoute(nameof(Views.DashboardPage), typeof(Views.DashboardPage));
=======
            Routing.RegisterRoute("EventRegistrationPage", typeof(Views.RegistrationPage)); // Team 4
>>>>>>> main

            return builder.Build();
        }
    }
}