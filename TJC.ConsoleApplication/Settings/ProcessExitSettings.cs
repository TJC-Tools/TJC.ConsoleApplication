using TJC.Singleton;

namespace TJC.ConsoleApplication.Settings;

/// <summary>
/// Settings for the process exit.
/// </summary>
public class ProcessExitSettings : SingletonBase<ProcessExitSettings>
{
    #region Constructors

    private ProcessExitSettings() { }

    #endregion

    #region Predefined Types

    /// <summary>
    /// Default settings for the process exit.
    /// </summary>
    public static ProcessExitSettings Default => new();

    /// <summary>
    /// Settings for a silent exit on success.
    /// </summary>
    public static ProcessExitSettings SilentExitOnSuccess =>
        new() { ShowSuccessMessage = false, AutoExit = true, ExitCountdownSeconds = 0 };

    /// <summary>
    /// Settings to require user input to exit.
    /// </summary>
    public static ProcessExitSettings ManualExit => new() { AutoExit = false };

    /// <summary>
    /// Settings for automatic exit after a countdown.
    /// </summary>
    public static ProcessExitSettings AutomaticExit => CreateAutomaticExit(countdownSeconds: 10);

    /// <summary>
    /// Settings for automatic exit after a countdown.
    /// </summary>
    /// <param name="countdownSeconds">Number of seconds to wait before automatically exiting.</param>
    /// <returns></returns>
    public static ProcessExitSettings CreateAutomaticExit(uint countdownSeconds) =>
        new() { AutoExit = true, ExitCountdownSeconds = countdownSeconds };

    #endregion

    #region Properties

    /// <summary>
    /// Show success message if the process exits successfully.
    /// </summary>
    public bool ShowSuccessMessage { get; set; } = true;

    /// <summary>
    /// Show a failed message if the process exits with an error.
    /// </summary>
    public bool ShowFailedMessage { get; set; } = true;

    /// <summary>
    /// Suggest help argument if the process exits with an error.
    /// </summary>
    public bool ShowSuggestHelp { get; set; } = true;

    /// <summary>
    /// Force the exit code to be 0 if the process exits with an error.
    /// <para></para>
    /// This is useful if the application is used within a CI/CD pipeline where a failure of the application should not fail the pipeline.
    /// </summary>
    public bool ForceExitCode0 { get; set; } = false;

    /// <summary>
    /// Automatically exit the application after completion without user input.
    /// <para></para>
    /// This is useful for running the application in a CI/CD pipeline, script or as a scheduled task.
    /// </summary>
    public bool AutoExit { get; set; } = true;

    /// <summary>
    /// Countdown to automatically exit after completion.
    /// <para></para>
    /// This is useful if the application may be run manually as well as automatically, and the user may want to see the output before it closes.
    /// </summary>
    public uint ExitCountdownSeconds { get; set; } = 5;

    #endregion

    #region Methods

    /// <summary>
    /// Sets the instance of the process exit settings.
    /// </summary>
    /// <param name="settings"></param>
    public static void SetInstance(ProcessExitSettings settings) =>
        SetBaseInstance(settings);

    #endregion
}