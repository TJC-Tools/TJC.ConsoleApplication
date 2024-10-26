using SampleConsoleApplication.Commands;

namespace SampleConsoleApplication;

internal class Arguments
{
    /// <summary>
    /// Parse the arguments provided to the executable.
    /// </summary>
    /// <param name="args"></param>
    internal static void Parse(string[] args) =>
        ConsoleArguments.ParseAndValidate(args, Assembly.GetCallingAssembly().GetName().Name);

    // Predefined arguments that are used in multiple applications
    internal static DryRunArgument DryRun => DryRunArgument.Default;
    internal static VersionArgument Version => VersionArgument.Default;
    internal static CopyrightArgument Copyright => CopyrightArgument.Default;
    internal static LicenseArgument License => LicenseArgument.Default;
    internal static ChangelogArgument Changelog => ChangelogArgument.Default;

    // Custom argument properties that are specific to this application
    internal static bool Item1 { get; private set; }
    internal static string? Item2 { get; private set; }

    // Create the arguments options for this application
    internal static readonly ConsoleArgumentsWithCommand<CommandTypes> ConsoleArguments =
        new(getCommandHelp: CommandExtensions.GetCommandHelp, flagRequired: true, logParsedOptions: false)
    {
        DryRun, Version, Copyright, License, Changelog,
        { "item1", v => Item1 = !string.IsNullOrEmpty(v), "Example Item 1" },
        { "item2", v => Item2 = v, "Example Item 2" }
    };
}