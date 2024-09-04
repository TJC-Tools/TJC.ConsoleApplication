namespace TJC.ConsoleApplication.Arguments.Options.Specific;

/// <summary>
/// This argument is intended for applications that require the option to run a test process that doesn't make any changes.
/// <para>But, writes logs based on what it would have done.</para>
/// </summary>
public class DryRunArgument : IConsoleArgument
{
    private const string Prototype = "dry-run|dryrun";

    public static DryRunArgument Default => new();

    public DryRunArgument(string description = "Run through the process, writing logs, but do not execute any changes") =>
        Argument = new ConsoleArgument(null, Prototype, v => Selected = !string.IsNullOrEmpty(v), isRequired: false, description);

    public bool Selected { get; private set; }

    public ConsoleArgument Argument { get; }
}