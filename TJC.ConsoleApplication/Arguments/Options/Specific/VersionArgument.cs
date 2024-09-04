using System.Reflection;

namespace TJC.ConsoleApplication.Arguments.Options.Specific;

/// <summary>
/// This argument is intended to print the version number of the application.
/// </summary>
public class VersionArgument : IConsoleArgument
{
    private const string Prototype = "version|ver";

    public static VersionArgument Default => new();

    public VersionArgument(string description = "Print the version number of the application") =>
        Argument = new ConsoleArgument(null, Prototype, v =>
        {
            Selected = true;
            Execute();
        }, isRequired: false, description);

    public bool Selected { get; private set; }

    public ConsoleArgument Argument { get; }

    public void Execute()
    {
        if (!Selected)
            return;
        var assembly = Assembly.GetEntryAssembly();
        var assemblyName = assembly?.GetName();
        ConsoleOutputHandler.WriteLine($"v{assemblyName?.Version}");
    }
}