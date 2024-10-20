using System.Diagnostics;
using System.Reflection;

namespace TJC.ConsoleApplication;

/// <summary>
/// Setup the console application settings.
/// </summary>
public static class ConsoleSetup
{
    /// <summary>
    /// Setup the console application.
    /// <para></para>
    /// If custom settings are needed, use the <seealso cref="ConsoleSettings"/> &amp; <seealso cref="ProcessExitSettings"/> to set the settings before calling this method.
    /// </summary>
    /// <param name="assembly"></param>
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

    /// <summary>
    /// Default settings for a silent console application.
    /// <para></para>
    /// This is useful for application where the console output must be limited only to result or errors.
    /// </summary>
    public static void SetupSilent()
    {
        ConsoleSettings.SetInstance(ConsoleSettings.Silent);
        ProcessExitSettings.SetInstance(ProcessExitSettings.SilentExitOnSuccess);
        Setup();
    }
}