using System.Diagnostics;

namespace Maui.Diagnostics.Telemetry;

public interface IMauiTelemetry
{
	void TrackEvent(string name, IReadOnlyDictionary<string, object?>? properties = null);

	Activity? StartActivity(string name, ActivityKind kind = ActivityKind.Internal);

	void RecordMetric(string name, double value, IReadOnlyDictionary<string, object?>? tags = null);
}
