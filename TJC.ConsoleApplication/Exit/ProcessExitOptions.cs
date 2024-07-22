namespace TJC.ConsoleApplication.Exit;

public class ProcessExitOptions
{
    #region Predefined Types

    public static ProcessExitOptions Default => new();

    public static ProcessExitOptions SilentExitOnSuccess => new() { ShowSuccessMessage = false };

    #endregion

    #region Properties

    public bool ShowSuccessMessage { get; set; } = true;
    public bool ShowFailedMessage { get; set; } = true;
    public bool ShowSuggestHelp { get; set; } = true;
    public bool ForceExitCode0 { get; set; } = false;

    #endregion
}