using System.Reflection;
using TJC.AssemblyExtensions.Attributes;

namespace TJC.ConsoleApplication.Arguments.Options.Specific;

/// <summary>
/// This argument is intended to print the changelog of the application.
/// </summary>
public class ChangelogArgument
    : ICustomArgument
{
    private const string Prototype = "changelog";

    private readonly bool _includeHeader;
    private readonly bool _includeUnreleasedSection;
    private readonly bool _includePaths;

    /// <summary>
    /// Default settings for the changelog argument.
    /// </summary>
    public static ChangelogArgument Default => new();

    /// <summary>
    /// Constructor for the changelog argument.
    /// </summary>
    /// <param name="description"></param>
    /// <param name="exitIfUsed"></param>
    /// <param name="includeHeader"></param>
    /// <param name="includeUnreleasedSection"></param>
    /// <param name="includePaths"></param>
    public ChangelogArgument(string description = "Print the changelog of the application",
                             bool exitIfUsed = true,
                             bool includeHeader = false,
                             bool includeUnreleasedSection = false,
                             bool includePaths = false)
    {
        Argument = new Argument(null, Prototype, v => Execute(),
        isRequired: false,
        description: description,
        exitIfUsed: exitIfUsed);

        _includeHeader = includeHeader;
        _includeUnreleasedSection = includeUnreleasedSection;
        _includePaths = includePaths;
    }

    /// <summary>
    /// Argument to be added to the list of <seealso cref="ConsoleArguments"/>.
    /// </summary>
    public Argument Argument { get; }

    private void Execute()
    {
        var assembly = Assembly.GetEntryAssembly();
        var changelog = assembly?.GetChangelog(
            includeHeader: _includeHeader,
            includeUnreleasedSection: _includeUnreleasedSection,
            includePaths: _includePaths);
        ConsoleOutputHandler.WriteLine($"{changelog}");
    }
}