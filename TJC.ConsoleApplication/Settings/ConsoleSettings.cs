namespace TJC.ConsoleApplication.Settings;

public class ConsoleSettings
{
    #region Predefined Types

    public static ConsoleSettings Default => new();

    public static ConsoleSettings Silent => new() { SilentLogging = false };

    #endregion

    #region Properties

    public bool SilentLogging { get; set; } = false;

    #endregion
}