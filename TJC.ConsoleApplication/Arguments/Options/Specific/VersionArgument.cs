using System.Reflection;

namespace TJC.ConsoleApplication.Arguments.Options.Specific;

/// <summary>
/// This argument is intended to print the version number of the application.
/// </summary>
public class VersionArgument(
    string description = "Print the version number of the application",
    bool exitIfUsed = true)
    : IConsoleArgument
{
    private const string Prototype = "version|ver";

    /// <summary>
    /// Default settings for the version argument.
    /// </summary>
    public static VersionArgument Default => new();

    /// <summary>
    /// Argument to be added to the list of <seealso cref="ConsoleArguments"/>.
    /// </summary>
    public ConsoleArgument Argument { get; } = new ConsoleArgument(null, Prototype, v => Execute(),
        isRequired: false,
        description: description,
        exitIfUsed: exitIfUsed);

    private static void Execute()
    {
        var assembly = Assembly.GetEntryAssembly();
        var assemblyName = assembly?.GetName();
        ConsoleOutputHandler.WriteLine($"v{assemblyName?.Version}");
    }
}