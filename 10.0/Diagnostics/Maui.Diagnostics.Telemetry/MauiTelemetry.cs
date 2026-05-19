using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Maui.Diagnostics.Telemetry;

public sealed class MauiTelemetry : IMauiTelemetry, IDisposable
{
	public const string SourceName = "Maui.Diagnostics.Telemetry";

	private readonly ActivitySource _activitySource = new(SourceName);
	private readonly Meter _meter = new(SourceName);
	private readonly ConcurrentDictionary<string, Counter<double>> _counters = new();

	public void TrackEvent(string name, IReadOnlyDictionary<string, object?>? properties = null)
	{
		using var activity = _activitySource.StartActivity(name, ActivityKind.Internal);
		if (activity is null || properties is null)
		{
			return;
		}

		foreach (var (key, value) in properties)
		{
			activity.SetTag(key, value);
		}
	}

	public Activity? StartActivity(string name, ActivityKind kind = ActivityKind.Internal)
		=> _activitySource.StartActivity(name, kind);

	public void RecordMetric(string name, double value, IReadOnlyDictionary<string, object?>? tags = null)
	{
		var counter = _counters.GetOrAdd(name, n => _meter.CreateCounter<double>(n));

		if (tags is null)
		{
			counter.Add(value);
			return;
		}

		var tagList = new TagList();
		foreach (var (key, tagValue) in tags)
		{
			tagList.Add(key, tagValue);
		}

		counter.Add(value, tagList);
	}

	public void Dispose()
	{
		_activitySource.Dispose();
		_meter.Dispose();
	}
}
