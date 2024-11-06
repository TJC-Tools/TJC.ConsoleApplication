namespace TJC.ConsoleApplication.Arguments.Options.Specific;

/// <summary>
/// This argument is intended for applications that require the option to run a test process that doesn't make any changes.
/// <para>But, writes logs based on what it would have done.</para>
/// </summary>
public class DryRunArgument(
    string description = "Run through the process, writing logs, but do not execute any changes"
) : ICustomArgument
{
    private const string Prototype = "dry-run|dryrun";

    /// <summary>
    /// Default settings for the dry-run argument.
    /// </summary>
    public static DryRunArgument Default => new();

    /// <summary>
    /// Argument to be added to the list of <seealso cref="ConsoleArguments"/>.
    /// </summary>
    public Argument Argument { get; } =
        new(null, Prototype, v => { }, isRequired: false, description);
}
