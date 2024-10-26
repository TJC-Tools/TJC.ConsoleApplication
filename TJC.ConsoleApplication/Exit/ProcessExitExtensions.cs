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
    public static void ConfigureProcessExitEvent_SilentExitOnSuccess()
    {
        ProcessExitSettings.SetInstance(ProcessExitSettings.SilentExitOnSuccess);
        ConfigureProcessExitEvent(Assembly.GetCallingAssembly());
    }

    /// <summary>
    /// Configures an event to run at the end of a process.
    /// </summary>
    /// <remarks>Depending on the options, this may display some of the following; run time, exit code &amp; help menu</remarks>
    /// <param name="assembly"></param>
    public static void ConfigureProcessExitEvent(Assembly? assembly = null)
    {
        var startTime = DateTime.Now; // This must be here, otherwise it does not get called until the event occurs
        assembly ??= Assembly.GetCallingAssembly();
        AppDomain.CurrentDomain.ProcessExit += (_, _) =>
            OnProcessExit(startTime, assembly.GetName().Name, HelpArgument.StandardPrototype);
    }

    private static void OnProcessExit(DateTime startTime,
                                      string? programName = null,
                                      string? helpOption = null)
    {
        OnProcessExit<ExitCodes>(startTime, programName, helpOption);
        FinalExit();
    }

    private static void OnProcessExit<T>(DateTime startTime,
                                         string? programName = null,
                                         string? helpOption = null)
        where T : Enum
    {
        var runtime = (DateTime.Now - startTime).GetElapsedTime();

        ConsoleOutputHandler.Silent = false;

        if (Environment.ExitCode == 0)
        {
            if (ProcessExitSettings.Instance.ShowSuccessMessage)
            {
                ConsoleOutputHandler.Empty();
                ConsoleOutputHandler.WriteLine($"Complete [Run Time: {runtime}]");
            }
            return;
        }

        if (ProcessExitSettings.Instance.ShowFailedMessage)
        {
            ConsoleOutputHandler.Empty();
            ConsoleOutputHandler.WriteLine($"Failed [Run Time: {runtime}]");
            ConsoleOutputHandler.Empty();
            var processName = $"Process{(string.IsNullOrEmpty(programName) ? string.Empty : $" [{programName}]")}";
            var exitCode = $"[{Environment.ExitCode}] [{Enum.ToObject(typeof(T), Environment.ExitCode)}]";
            ConsoleOutputHandler.WriteLine($"{processName} exited with code {exitCode}");
        }

        if (ProcessExitSettings.Instance.ShowSuggestHelp)
            SuggestHelp(helpOption);

        if (ProcessExitSettings.Instance.ForceExitCode0)
            Environment.ExitCode = 0;
    }

    private static void SuggestHelp(string? helpOption)
    {
        if (string.IsNullOrEmpty(helpOption))
            return;
        ConsoleOutputHandler.Empty();
        ConsoleOutputHandler.WriteLine($"Try {helpOption} for more information.");
    }

    private static void FinalExit()
    {
        if (ProcessExitSettings.Instance.AutoExit) // Auto-exit (with optional countdown)
            ExitCountdown(ProcessExitSettings.Instance.ExitCountdownSeconds);
        else // Manual exit only (wait for user input)
            ConsoleInputHandler.ReadKey(true);
    }

    private static void ExitCountdown(uint timeoutSeconds)
    {
        var startTime = DateTime.Now;
        ConsoleOutputHandler.Empty();
        ConsoleOutputHandler.WriteLine($"Press any key to exit...");

        while ((DateTime.Now - startTime).TotalSeconds < timeoutSeconds)
        {
            // Check if a key is pressed
            if (Console.KeyAvailable)
            {
                ConsoleInputHandler.ReadKey(true); // Consume the key
                break;
            }

            // Calculate remaining time
            var remainingTime = timeoutSeconds - (int)(DateTime.Now - startTime).TotalSeconds;

            // Clear the current line & write the remaining time
            ConsoleOutputHandler.ClearCurrentLine();
            ConsoleOutputHandler.Write($"Timeout in {remainingTime} seconds");

            // Sleep for 100ms to reduce CPU usage (but allow key press detection to feel responsive)
            Thread.Sleep(100);
        }

        // Final message after timeout or key press
        ConsoleOutputHandler.ClearCurrentLine();
        ConsoleOutputHandler.WriteLine("Exiting...");
    }
}