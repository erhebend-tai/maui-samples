using System.Diagnostics;
using System.Text;

namespace Maui.Diagnostics.StackTracing;

public sealed class MauiStackTraceCapturer : IStackTraceCapturer
{
	public string Capture(Exception? exception = null, bool includeFileInfo = true, int skipFrames = 0)
	{
		if (exception is null)
		{
			var trace = new StackTrace(skipFrames + 1, includeFileInfo);
			return trace.ToString();
		}

		var builder = new StringBuilder();
		builder.Append(exception.GetType().FullName);
		builder.Append(": ");
		builder.AppendLine(exception.Message);
		builder.Append(new StackTrace(exception, includeFileInfo).ToString());
		return builder.ToString();
	}
}

public static class StackTraceExceptionExtensions
{
	public static string FormatForReport(this Exception exception, IStackTraceCapturer capturer)
		=> capturer.Capture(exception);
}
