# MAUI Diagnostics Pseudo Libraries

Three small wrapper libraries — `Maui.Diagnostics.Telemetry`,
`Maui.Diagnostics.StackTracing`, and `Maui.Diagnostics.Logging` — plus a
`DiagnosticsDemo` MAUI app that wires all three together.

These are intentionally thin "pseudo libraries" over .NET built-in primitives.
They give MAUI samples and tests a single, opinionated surface for the three
cross-cutting concerns without standing up real telemetry/logging
infrastructure.

## Projects

| Project | Wraps | Highlights |
| ------- | ----- | ---------- |
| `Maui.Diagnostics.Telemetry` | `System.Diagnostics.ActivitySource` + `System.Diagnostics.Metrics.Meter` | `IMauiTelemetry` with `TrackEvent`, `StartActivity`, `RecordMetric` |
| `Maui.Diagnostics.StackTracing` | `System.Diagnostics.StackTrace` | `IStackTraceCapturer` and an `Exception.FormatForReport` extension |
| `Maui.Diagnostics.Logging` | `Microsoft.Extensions.Logging.ILogger` | `IMauiLogger<T>` with MAUI-flavored helpers and passthroughs |

Each library registers its services through a `MauiAppBuilder` extension:
`AddMauiTelemetry`, `AddMauiStackTracing`, `AddMauiLogging`.

## Using from a MAUI app

Add a project reference to whichever libraries you need, then in
`MauiProgram.CreateMauiApp`:

```csharp
var builder = MauiApp.CreateBuilder();
builder
    .UseMauiApp<App>()
    .AddMauiTelemetry()
    .AddMauiStackTracing()
    .AddMauiLogging();
```

Then inject `IMauiTelemetry`, `IStackTraceCapturer`, or `IMauiLogger<T>` into
pages, view models, or services.

## Demo app

`DiagnosticsDemo` is a runnable MAUI app whose `MainPage` has three buttons that
exercise each library. Open `Diagnostics.sln` and run the
`DiagnosticsDemo` project on any installed MAUI workload.
