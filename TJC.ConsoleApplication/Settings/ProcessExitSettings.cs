namespace TJC.ConsoleApplication.Settings;

public class ProcessExitSettings
{
    #region Predefined Types

    public static ProcessExitSettings Default => new();

    public static ProcessExitSettings SilentExitOnSuccess => new() { ShowSuccessMessage = false };

    #endregion

    #region Properties

    public bool ShowSuccessMessage { get; set; } = true;
    public bool ShowFailedMessage { get; set; } = true;
    public bool ShowSuggestHelp { get; set; } = true;
    public bool ForceExitCode0 { get; set; } = false;

    #endregion
}