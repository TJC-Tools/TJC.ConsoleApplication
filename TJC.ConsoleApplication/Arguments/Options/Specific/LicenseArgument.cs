using System.Reflection;
using TJC.AssemblyExtensions.Attributes;

namespace TJC.ConsoleApplication.Arguments.Options.Specific;

/// <summary>
/// This argument is intended to print the license of the application.
/// </summary>
/// <param name="description"></param>
/// <param name="exitIfUsed"></param>
public class LicenseArgument(string description = "Print the license of the application", bool exitIfUsed = true)
    : ICustomArgument
{
    private const string Prototype = "license";

    /// <summary>
    /// Default settings for the license argument.
    /// </summary>
    public static LicenseArgument Default => new();

    /// <summary>
    /// Argument to be added to the list of <seealso cref="ConsoleArguments"/>.
    /// </summary>
    public Argument Argument { get; } = new Argument(null, Prototype, v => Execute(),
        isRequired: false,
        description: description,
        exitIfUsed: exitIfUsed);

    private static void Execute()
    {
        var assembly = Assembly.GetEntryAssembly();
        var license = assembly?.GetLicense();
        ConsoleOutputHandler.WriteLine($"{license}");
    }
}