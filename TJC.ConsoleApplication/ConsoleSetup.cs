using System.Diagnostics;
using System.Reflection;

namespace TJC.ConsoleApplication;

public class ConsoleSetup
{
    public static void Setup(
        Assembly? assembly = null,
        ConsoleSettings? consoleSettings = null,
        ProcessExitSettings? processExitSettings = null)
    {
        // Set default values if not provided
        consoleSettings ??= ConsoleSettings.Default;
        processExitSettings ??= ProcessExitSettings.Default;

        // Configure settings
        ConsoleOutputHandler.Silent = consoleSettings.SilentLogging;
        ProcessExitExtensions.ConfigureProcessExitEvent(assembly ?? Assembly.GetCallingAssembly(), processExitSettings);

        // Re-route trace messages to the console
        if (consoleSettings.TraceToConsole)
        {
            Trace.Listeners.Clear();
            Trace.Listeners.Add(new ConsoleOutputTraceListener());
        }

        // Header (with title, version, copyright, & description)
        if (consoleSettings.DisplayHeader)
        {
            Assembly.GetCallingAssembly().WriteHeader();
            ConsoleOutputHandler.Empty();
            ConsoleOutputHandler.Empty();
        }
    }

    public static void SetupSilent() =>
        Setup(Assembly.GetCallingAssembly(),
            ConsoleSettings.Silent,
            ProcessExitSettings.SilentExitOnSuccess);
}