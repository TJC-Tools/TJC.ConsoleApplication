namespace TJC.ConsoleApplication.Settings;

/// <summary>
/// The version source used by the console application.
/// </summary>
public enum VersionType
{
    /// <summary>
    /// The assembly version.
    /// </summary>
    Version,

    /// <summary>
    /// The informational version.
    /// </summary>
    InformationalVersion,

    /// <summary>
    /// The file version.
    /// </summary>
    FileVersion,

    /// <summary>
    /// The product version from the file version information.
    /// </summary>
    ProductVersion,
}