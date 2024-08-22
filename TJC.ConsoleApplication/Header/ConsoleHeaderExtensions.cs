using System.Reflection;
using TJC.AssemblyExtensions.Attributes;
using TJC.StringExtensions.Header;

namespace TJC.ConsoleApplication.Header;

public static class ConsoleHeaderExtensions
{
    public static void WriteHeader()
    {
        foreach (var line in Assembly.GetCallingAssembly().GetHeader())
            Console.WriteLine(line);
    }

    public static IEnumerable<string> GetHeader() =>
        Assembly.GetCallingAssembly().GetHeader();

    public static IEnumerable<string> GetHeader(this Assembly assembly)
    {
        var assemblyName = assembly.GetName();
        var version = $"v{assemblyName.Version}";
        var title = assembly.GetTitle();
        var copyright = assembly.GetCopyright(replaceCopyrightSymbolWithC: true);
        var description = assembly.GetDescription();

        // Create lines for the header
        var lines = new List<string> { $"{title} - {version}" };

        if (!string.IsNullOrEmpty(copyright))
            lines.Add(copyright);

        if (!string.IsNullOrEmpty(description))
        {
            lines.Add("---");
            lines.Add(description);
        }

        return lines.GenerateHeader();
    }
}