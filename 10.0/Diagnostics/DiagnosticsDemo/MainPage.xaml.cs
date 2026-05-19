using Maui.Diagnostics.Logging;
using Maui.Diagnostics.StackTracing;
using Maui.Diagnostics.Telemetry;

namespace DiagnosticsDemo;

public partial class MainPage : ContentPage
{
	private readonly IMauiTelemetry _telemetry;
	private readonly IStackTraceCapturer _stackTraceCapturer;
	private readonly IMauiLogger<MainPage> _logger;
	private int _eventCount;

	public MainPage(
		IMauiTelemetry telemetry,
		IStackTraceCapturer stackTraceCapturer,
		IMauiLogger<MainPage> logger)
	{
		InitializeComponent();
		_telemetry = telemetry;
		_stackTraceCapturer = stackTraceCapturer;
		_logger = logger;
	}

	private void OnTrackEventClicked(object? sender, EventArgs e)
	{
		_eventCount++;
		var properties = new Dictionary<string, object?>
		{
			["count"] = _eventCount,
			["source"] = "MainPage"
		};
		_telemetry.TrackEvent("button.clicked", properties);
		_telemetry.RecordMetric("button.clicked.count", 1);

		ResultLabel.Text = $"Tracked event 'button.clicked' (#{_eventCount}). " +
			$"ActivitySource '{MauiTelemetry.SourceName}' emitted an activity.";
	}

	private void OnThrowCaptureClicked(object? sender, EventArgs e)
	{
		try
		{
			throw new InvalidOperationException("Pseudo-demo exception from MainPage.");
		}
		catch (Exception ex)
		{
			var formatted = ex.FormatForReport(_stackTraceCapturer);
			ResultLabel.Text = formatted;
		}
	}

	private void OnLogMessageClicked(object? sender, EventArgs e)
	{
		_logger.LogUserAction("LogButtonClicked", new Dictionary<string, object?>
		{
			["timestamp"] = DateTimeOffset.UtcNow
		});
		_logger.LogPageNavigation(fromPage: nameof(MainPage), toPage: nameof(MainPage));
		_logger.LogPlatformEvent(DeviceInfo.Platform.ToString(), "log-button-tap");

		ResultLabel.Text = "Logged a user action, a navigation event, and a platform event " +
			"via Microsoft.Extensions.Logging.Debug. See the IDE Debug Output.";
	}
}
