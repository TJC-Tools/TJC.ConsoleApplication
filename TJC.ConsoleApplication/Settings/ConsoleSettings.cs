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

    /// <summary>
    /// The number of digits to display for the version.
    /// Formats:
    /// 3: v{major}.{minor}.{patch}.
    /// 4: v{major}.{minor}.{build}.{revision}
    /// </summary>
    public int VersionDigits { get; set; } = 3;

    #endregion
}