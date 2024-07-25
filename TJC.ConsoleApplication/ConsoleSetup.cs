namespace TJC.ConsoleApplication;

public class ConsoleSetup
{
    public static void Setup(
        ConsoleSettings? consoleSettings = null,
        ProcessExitSettings? processExitSettings = null)
    {
        // Set default values if not provided
        consoleSettings ??= ConsoleSettings.Default;
        processExitSettings ??= ProcessExitSettings.Default;

        // Configure settings
        ConsoleOutputHandler.Silent = consoleSettings.SilentLogging;
        ProcessExitExtensions.ConfigureProcessExitEvent(processExitSettings);
    }

    public static void SetupSilent() =>
        Setup(ConsoleSettings.Silent, ProcessExitSettings.SilentExitOnSuccess);

}