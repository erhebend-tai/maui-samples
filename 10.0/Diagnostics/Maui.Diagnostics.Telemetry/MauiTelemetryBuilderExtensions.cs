using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Maui.Diagnostics.Telemetry;

public static class MauiTelemetryBuilderExtensions
{
	public static MauiAppBuilder AddMauiTelemetry(this MauiAppBuilder builder)
	{
		builder.Services.TryAddSingleton<IMauiTelemetry, MauiTelemetry>();
		return builder;
	}
}
