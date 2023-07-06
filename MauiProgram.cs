using Microsoft.Extensions.Logging;
using MyWeather.Services;
using MyWeather.View;
using MyWeather.ViewModels;

namespace MyWeather;

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

#if DEBUG
		builder.Logging.AddDebug();
#endif
		//register 
		builder.Services.AddSingleton<DashboardPage>();
		builder.Services.AddSingleton<DashboardViewModel>();
		builder.Services.AddSingleton<WeatherService>();

		return builder.Build();
	}
}
