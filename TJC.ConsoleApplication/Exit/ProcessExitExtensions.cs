using System.Reflection;

namespace TJC.ConsoleApplication.Exit;

/// <summary>
/// Used within to display debug information on process completion.
/// </summary>
/// <remarks>Recommended to use this with <see cref="EnvironmentEx"/></remarks>
public static class ProcessExitExtensions
{
    /// <summary>
    /// Configures an event to run at the end of a failed process.
    /// </summary>
    /// <remarks>If the process fails, it will display exit code, run time &amp; help menu</remarks>
    public static void ConfigureProcessExitEvent_SilentExitOnSuccess() =>
        ConfigureProcessExitEvent(ProcessExitSettings.SilentExitOnSuccess);

    /// <summary>
    /// Configures an event to run at the end of a process.
    /// </summary>
    /// <remarks>Depending on the options, this may display some of the following; run time, exit code &amp; help menu</remarks>
    /// <param name="settings">Options to determine which outputs should be displayed depending on the results</param>
    public static void ConfigureProcessExitEvent(ProcessExitSettings? processExitSettings = null)
    {
        var startTime = DateTime.Now; // This must be here, otherwise it does not get called until the event occurs
        AppDomain.CurrentDomain.ProcessExit += (_, _) =>
            OnProcessExit(startTime,
                          Assembly.GetCallingAssembly().GetName().Name,
                          "--help",
                          processExitSettings ?? ProcessExitSettings.Default);
    }

    private static void OnProcessExit(DateTime startTime,
                                      string? programName = null,
                                      string? helpOption = null,
                                      ProcessExitSettings? processExitSettings = null) =>
        OnProcessExit<ExitCodes>(startTime, programName, helpOption, processExitSettings);

    private static void OnProcessExit<T>(DateTime startTime,
                                     string? programName = null,
                                     string? helpOption = null,
                                     ProcessExitSettings? processExitSettings = null)
        where T : Enum
    {
        var runtime = (DateTime.Now - startTime).GetElapsedTime();

        processExitSettings ??= ProcessExitSettings.Default;

        ConsoleOutputHandler.Silent = false;

        if (Environment.ExitCode == 0)
        {
            if (processExitSettings.ShowSuccessMessage)
            {
                ConsoleOutputHandler.Empty();
                ConsoleOutputHandler.WriteLine($"Complete [Run Time: {runtime}]");
            }
            return;
        }

        if (processExitSettings.ShowFailedMessage)
        {
            ConsoleOutputHandler.Empty();
            ConsoleOutputHandler.WriteLine($"Failed [Run Time: {runtime}]");
            ConsoleOutputHandler.Empty();
            var processName = $"Process{(string.IsNullOrEmpty(programName) ? string.Empty : $" [{programName}]")}";
            var exitCode = $"[{Environment.ExitCode}] [{Enum.ToObject(typeof(T), Environment.ExitCode)}]";
            ConsoleOutputHandler.WriteLine($"{processName} exited with code {exitCode}");
        }

        if (processExitSettings.ShowSuggestHelp)
            SuggestHelp(helpOption);

        if (processExitSettings.ForceExitCode0)
            Environment.ExitCode = 0;
    }

    private static void SuggestHelp(string? helpOption)
    {
        if (string.IsNullOrEmpty(helpOption))
            return;
        ConsoleOutputHandler.Empty();
        ConsoleOutputHandler.WriteLine($"Try {helpOption} for more information.");
    }
}