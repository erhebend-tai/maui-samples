namespace Maui.Diagnostics.Logging;

public interface IMauiLogger<T>
{
	void LogUserAction(string action, IReadOnlyDictionary<string, object?>? data = null);

	void LogPageNavigation(string fromPage, string toPage);

	void LogPlatformEvent(string platform, string @event);

	void LogInformation(string message);

	void LogWarning(string message);

	void LogError(Exception exception, string message);
}
