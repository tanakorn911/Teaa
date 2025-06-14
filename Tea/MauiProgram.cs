using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Tea.Services;
using Tea.Shared.Services;

namespace Tea
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
                });

            // Add configuration
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .Build();
            builder.Services.AddSingleton<IConfiguration>(config);

            // Add device-specific services used by the Tea.Shared project
            builder.Services.AddSingleton<IFormFactor, FormFactor>();

            // Add shared services
            builder.Services.AddSingleton<BeverageService>();
            builder.Services.AddSingleton<CartService>();
            builder.Services.AddSingleton<LanguageService>();
            
            // Add HTTP client and PaymentService
            builder.Services.AddHttpClient<PaymentService>();

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
