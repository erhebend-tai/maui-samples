using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Maui.Diagnostics.StackTracing;

public static class MauiStackTracingBuilderExtensions
{
	public static MauiAppBuilder AddMauiStackTracing(this MauiAppBuilder builder)
	{
		builder.Services.TryAddSingleton<IStackTraceCapturer, MauiStackTraceCapturer>();
		return builder;
	}
}
