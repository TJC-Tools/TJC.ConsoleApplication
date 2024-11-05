using System.Reflection;
using TJC.AssemblyExtensions.Attributes;
using TJC.StringExtensions.Header;

namespace TJC.ConsoleApplication.Header;

/// <summary>
/// The header will display the <c>AssemblyTitle</c>, <c>AssemblyVersion</c>, <c>Copyright</c>, and <c>Description</c>.
/// </summary>
public static class ConsoleHeaderExtensions
{
    /// <summary>
    /// Write the header for the calling assembly.
    /// </summary>
    public static void WriteHeader() => Assembly.GetCallingAssembly().WriteHeader();

    /// <summary>
    /// Write the header for the assembly.
    /// </summary>
    /// <param name="assembly"></param>
    public static void WriteHeader(this Assembly assembly)
    {
        foreach (var line in assembly.CreateHeader())
            ConsoleOutputHandler.WriteLine(line);
    }

    /// <summary>
    /// Create the header for the calling assembly.
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<string> CreateHeader() =>
        Assembly.GetCallingAssembly().CreateHeader();

    /// <summary>
    /// Create the header for the assembly.
    /// </summary>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static IEnumerable<string> CreateHeader(this Assembly assembly)
    {
        // Get assembly information
        var assemblyName = assembly.GetName();
        var title = assembly.GetTitle();
        var version = assemblyName.Version;
        var copyright = assembly.GetCopyright(replaceCopyrightSymbolWithC: true);
        var description = assembly.GetDescription();

        // Create lines for the header
        var lines = new List<string>();

        if (version != null)
            title += $" - v{version.ToString(ConsoleSettings.Instance.VersionDigits)}";

        lines.Add(title);

        if (!string.IsNullOrEmpty(copyright))
            lines.Add(copyright);

        if (!string.IsNullOrEmpty(description))
            lines.AddRange(["---", description]);

        // Convert lines to header
        return lines.GenerateHeader();
    }
}
