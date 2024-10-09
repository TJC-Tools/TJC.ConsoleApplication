using TJC.Singleton;

namespace TJC.ConsoleApplication.Settings;

public class ProcessExitSettings : SingletonBase<ProcessExitSettings>
{
    #region Constructors

    private ProcessExitSettings() { }

    #endregion

    #region Predefined Types

    public static ProcessExitSettings Default => new();

    public static ProcessExitSettings SilentExitOnSuccess =>
        new() { ShowSuccessMessage = false, AutoExit = true, ExitCountdownSeconds = 0 };

    public static ProcessExitSettings ManualExit => new() { AutoExit = false };

    public static ProcessExitSettings AutomaticExit => GetAutomaticExit();

    public static ProcessExitSettings GetAutomaticExit(uint countdownSeconds = 10) =>
        new() { AutoExit = true, ExitCountdownSeconds = countdownSeconds };

    #endregion

    #region Properties

    public bool ShowSuccessMessage { get; set; } = true;
    public bool ShowFailedMessage { get; set; } = true;
    public bool ShowSuggestHelp { get; set; } = true;
    public bool ForceExitCode0 { get; set; } = false;
    public bool AutoExit { get; set; } = true;
    public uint ExitCountdownSeconds { get; set; } = 5;

    #endregion

    #region Methods

    public static void SetInstance(ProcessExitSettings settings) =>
        SetBaseInstance(settings);

    #endregion
}