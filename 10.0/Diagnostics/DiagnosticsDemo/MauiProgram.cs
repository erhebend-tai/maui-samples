using Maui.Diagnostics.Logging;
using Maui.Diagnostics.StackTracing;
using Maui.Diagnostics.Telemetry;
using Microsoft.Extensions.DependencyInjection;

namespace DiagnosticsDemo;

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
			})
			.AddMauiTelemetry()
			.AddMauiStackTracing()
			.AddMauiLogging();

		builder.Services.AddTransient<MainPage>();

		return builder.Build();
	}
}
