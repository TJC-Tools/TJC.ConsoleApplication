using TJC.Singleton;

namespace TJC.ConsoleApplication.Settings;

/// <summary>
/// Settings for the console application input &amp; output.
/// </summary>
public class ConsoleSettings : SingletonBase<ConsoleSettings>
{
    #region Constructors

    private ConsoleSettings() { }

    #endregion

    #region Predefined Types

    /// <summary>
    /// Default console settings.
    /// </summary>
    public static ConsoleSettings Default => new();

    /// <summary>
    /// Console settings without any messages routed to the console.
    /// </summary>
    public static ConsoleSettings Silent => new() { SilentLogging = false };

    /// <summary>
    /// Console settings without trace messages routed to the console.
    /// </summary>
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

    #region Methods

    /// <summary>
    /// Set the instance of the console settings.
    /// </summary>
    /// <param name="settings"></param>
    public static void SetInstance(ConsoleSettings settings) => SetBaseInstance(settings);

    #endregion
}
