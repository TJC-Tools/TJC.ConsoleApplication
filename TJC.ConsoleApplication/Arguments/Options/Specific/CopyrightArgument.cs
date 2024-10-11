using System.Reflection;
using TJC.AssemblyExtensions.Attributes;

namespace TJC.ConsoleApplication.Arguments.Options.Specific;

/// <summary>
/// This argument is intended to print the copyright of the application.
/// </summary>
public class CopyrightArgument : IConsoleArgument
{
    private const string Prototype = "copyright";

    public static CopyrightArgument Default => new();

    public CopyrightArgument(string description = "Print the copyright of the application", bool exitIfUsed = true) =>
        Argument = new ConsoleArgument(null, Prototype, v =>
        {
            Selected = true;
            Execute();
        },
        isRequired: false,
        description: description,
        exitIfUsed: exitIfUsed);

    public bool Selected { get; private set; }

    public ConsoleArgument Argument { get; }

    public void Execute()
    {
        if (!Selected)
            return;
        var assembly = Assembly.GetEntryAssembly();
        var copyright = assembly?.GetCopyright(replaceCopyrightSymbolWithC: true);
        ConsoleOutputHandler.WriteLine($"{copyright}");
    }
}