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
 Team-3-Display-Event-images
            builder.Services.AddTransient<EventDetailPage>();

            builder.Services.AddTransient<CategoryViewModel>();
 main

#if DEBUG
            builder.Logging.AddDebug();
#endif

 Team-3-Display-Event-images
            Routing.RegisterRoute("EventDetailPage", typeof(EventDetailPage));

            Routing.RegisterRoute("categoryfilter", typeof(CategoryFilterView));
 main

            return builder.Build();
        }
    }
}
