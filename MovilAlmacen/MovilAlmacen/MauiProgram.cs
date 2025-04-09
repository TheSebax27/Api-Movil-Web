using Microsoft.Extensions.Logging;
using MovilAlmacen.Services;
using MovilAlmacen.ViewModels;
using MovilAlmacen.Views;

namespace MovilAlmacen;

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

        // Registrar servicios
        builder.Services.AddSingleton<ApiService>();
        builder.Services.AddSingleton<LoginService>();

        // Registrar ViewModels
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<ClientesViewModel>();
        builder.Services.AddTransient<DetalleClienteViewModel>();

        // Registrar Views
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<ClientesPage>();
        builder.Services.AddTransient<DetalleClientePage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
	}
}
