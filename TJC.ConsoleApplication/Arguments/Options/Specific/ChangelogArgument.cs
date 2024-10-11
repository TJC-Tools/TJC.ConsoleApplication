using System.Reflection;
using TJC.AssemblyExtensions.Attributes;

namespace TJC.ConsoleApplication.Arguments.Options.Specific;

/// <summary>
/// This argument is intended to print the changelog of the application.
/// </summary>
public class ChangelogArgument : IConsoleArgument
{
    private const string Prototype = "changelog";

    private readonly bool _includeHeader;
    private readonly bool _includeUnreleasedSection;
    private readonly bool _includePaths;

    public static ChangelogArgument Default => new();

    public ChangelogArgument(string description = "Print the changelog of the application",
                             bool exitIfUsed = true,
                             bool includeHeader = false,
                             bool includeUnreleasedSection = false,
                             bool includePaths = false)
    {
        Argument = new ConsoleArgument(null, Prototype, v =>
        {
            Selected = true;
            Execute();
        },
        isRequired: false,
        description: description,
        exitIfUsed: exitIfUsed);

        _includeHeader = includeHeader;
        _includeUnreleasedSection = includeUnreleasedSection;
        _includePaths = includePaths;
    }

    public bool Selected { get; private set; }

    public ConsoleArgument Argument { get; }

    public void Execute()
    {
        if (!Selected)
            return;
        var assembly = Assembly.GetEntryAssembly();
        var changelog = assembly?.GetChangelog(
            includeHeader: _includeHeader,
            includeUnreleasedSection: _includeUnreleasedSection,
            includePaths: _includePaths);
        ConsoleOutputHandler.WriteLine($"{changelog}");
    }
}