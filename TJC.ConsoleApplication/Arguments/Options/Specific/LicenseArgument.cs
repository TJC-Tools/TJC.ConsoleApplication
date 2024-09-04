using System.Reflection;
using TJC.AssemblyExtensions.Attributes;

namespace TJC.ConsoleApplication.Arguments.Options.Specific;

/// <summary>
/// This argument is intended to print the license of the application.
/// </summary>
public class LicenseArgument : IConsoleArgument
{
    private const string Prototype = "license";

    public static LicenseArgument Default => new();

    public LicenseArgument(string description = "Print the license of the application") =>
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
        var license = assembly?.GetLicense();
        ConsoleOutputHandler.WriteLine($"{license}");
    }
}