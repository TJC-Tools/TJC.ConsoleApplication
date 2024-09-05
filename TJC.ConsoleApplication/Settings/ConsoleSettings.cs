namespace TJC.ConsoleApplication.Settings;

public class ConsoleSettings
{
    #region Predefined Types

    public static ConsoleSettings Default => new();

    public static ConsoleSettings Silent => new() { SilentLogging = false };

    public static ConsoleSettings Traceless => new() { TraceToConsole = false };

    #endregion

    #region Properties

    /// <summary>
    /// Display header on program start.
    /// </summary>
    public bool DisplayHeader { get; set; } = true;

    /// <summary>
    /// Do not display any messages to the console.
    /// </summary>
    public bool SilentLogging { get; set; } = false;

    /// <summary>
    /// Route trace messages to the console.
    /// </summary>
    public bool TraceToConsole { get; set; } = true;

    #endregion
}