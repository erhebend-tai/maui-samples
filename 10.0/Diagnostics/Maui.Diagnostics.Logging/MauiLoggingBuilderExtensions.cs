using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace Maui.Diagnostics.Logging;

public static class MauiLoggingBuilderExtensions
{
	public static MauiAppBuilder AddMauiLogging(this MauiAppBuilder builder)
	{
#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.TryAdd(ServiceDescriptor.Singleton(typeof(IMauiLogger<>), typeof(MauiLogger<>)));
		return builder;
	}
}
