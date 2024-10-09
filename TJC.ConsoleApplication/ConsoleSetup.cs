using System.Diagnostics;
using System.Reflection;

namespace TJC.ConsoleApplication;

public static class ConsoleSetup
{
    public static void Setup(Assembly? assembly = null)
    {
        // Configure settings
        ConsoleOutputHandler.Silent = ConsoleSettings.Instance.SilentLogging;
        ProcessExitExtensions.ConfigureProcessExitEvent(assembly ?? Assembly.GetCallingAssembly());

        // Re-route trace messages to the console
        if (ConsoleSettings.Instance.TraceToConsole)
        {
            Trace.Listeners.Clear();
            Trace.Listeners.Add(new ConsoleOutputTraceListener());
        }

        // Header (with title, version, copyright, & description)
        if (ConsoleSettings.Instance.DisplayHeader)
        {
            Assembly.GetCallingAssembly().WriteHeader();
            ConsoleOutputHandler.Empty();
        }
    }

    public static void SetupSilent()
    {
        ConsoleSettings.SetInstance(ConsoleSettings.Silent);
        ProcessExitSettings.SetInstance(ProcessExitSettings.SilentExitOnSuccess);
        Setup();
    }
}