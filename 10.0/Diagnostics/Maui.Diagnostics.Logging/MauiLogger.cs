using Microsoft.Extensions.Logging;

namespace Maui.Diagnostics.Logging;

public sealed class MauiLogger<T> : IMauiLogger<T>
{
	private readonly ILogger<T> _logger;

	public MauiLogger(ILogger<T> logger)
	{
		_logger = logger;
	}

	public void LogUserAction(string action, IReadOnlyDictionary<string, object?>? data = null)
	{
		if (data is null || data.Count == 0)
		{
			_logger.LogInformation("UserAction: {Action}", action);
			return;
		}

		_logger.LogInformation("UserAction: {Action} {@Data}", action, data);
	}

	public void LogPageNavigation(string fromPage, string toPage)
		=> _logger.LogInformation("Navigation: {From} -> {To}", fromPage, toPage);

	public void LogPlatformEvent(string platform, string @event)
		=> _logger.LogInformation("Platform[{Platform}]: {Event}", platform, @event);

	public void LogInformation(string message) => _logger.LogInformation("{Message}", message);

	public void LogWarning(string message) => _logger.LogWarning("{Message}", message);

	public void LogError(Exception exception, string message)
		=> _logger.LogError(exception, "{Message}", message);
}
