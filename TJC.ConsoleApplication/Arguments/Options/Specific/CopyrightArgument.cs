using System.Reflection;
using TJC.AssemblyExtensions.Attributes;

namespace TJC.ConsoleApplication.Arguments.Options.Specific;

/// <summary>
/// This argument is intended to print the copyright of the application.
/// </summary>
/// <param name="description"></param>
/// <param name="exitIfUsed"></param>
public class CopyrightArgument(
    string description = "Print the copyright of the application",
    bool exitIfUsed = true)
    : IConsoleArgument
{
    private const string Prototype = "copyright";

    /// <summary>
    /// Default settings for the copyright argument.
    /// </summary>
    public static CopyrightArgument Default => new();

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
        var copyright = assembly?.GetCopyright(replaceCopyrightSymbolWithC: true);
        ConsoleOutputHandler.WriteLine($"{copyright}");
    }
}