namespace Maui.Diagnostics.StackTracing;

public interface IStackTraceCapturer
{
	string Capture(Exception? exception = null, bool includeFileInfo = true, int skipFrames = 0);
}
