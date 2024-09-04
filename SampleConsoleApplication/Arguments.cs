namespace SampleConsoleApplication;

internal class Arguments
{
    /// <summary>
    /// Parse the arguments provided to the executable.
    /// </summary>
    /// <param name="args"></param>
    internal static void Parse(string[] args) =>
        ConsoleArguments.ParseAndValidate(args, Assembly.GetCallingAssembly().GetName().Name);

    internal static DryRunArgument DryRun => DryRunArgument.Default; // Predefined argument that is used in multiple applications
    internal static VersionArgument Version => VersionArgument.Default; // Predefined argument that is used in multiple applications
    internal static CopyrightArgument Copyright => CopyrightArgument.Default; // Predefined argument that is used in multiple applications
    internal static bool Item1 { get; private set; }
    internal static string? Item2 { get; private set; }

    internal static readonly ConsoleArguments ConsoleArguments = new(flagRequired: true, logParsedOptions: false)
    {
        DryRun, Version, Copyright,
        { "item1", v => Item1 = !string.IsNullOrEmpty(v), "Example Item 1" },
        { "item2", v => Item2 = v, "Example Item 2" }
    };
}