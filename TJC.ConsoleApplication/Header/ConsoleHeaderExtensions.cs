using System.Reflection;
using TJC.AssemblyExtensions.Attributes;
using TJC.StringExtensions.Header;

namespace TJC.ConsoleApplication.Header;

/// <summary>
/// The header will display the <c>AssemblyTitle</c>, <c>AssemblyVersion</c>, <c>Copyright</c>, and <c>Description</c>.
/// </summary>
public static class ConsoleHeaderExtensions
{
    public static void WriteHeader() =>
        Assembly.GetCallingAssembly().GetHeader();

    public static void WriteHeader(this Assembly assembly)
    {
        foreach (var line in assembly.GetHeader())
            ConsoleOutputHandler.WriteLine(line);
    }

    public static IEnumerable<string> GetHeader() =>
        Assembly.GetCallingAssembly().GetHeader();

    public static IEnumerable<string> GetHeader(this Assembly assembly)
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
            title += $" - v{version}";

        lines.Add(title);

        if (!string.IsNullOrEmpty(copyright))
            lines.Add(copyright);

        if (!string.IsNullOrEmpty(description))
        {
            lines.Add("---");
            lines.Add(description);
        }

        // Convert lines to header
        return lines.GenerateHeader();
    }
}