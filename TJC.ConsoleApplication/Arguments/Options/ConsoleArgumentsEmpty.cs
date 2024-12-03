using System.Reflection;

namespace TJC.ConsoleApplication.Arguments.Options;

/// <summary>
/// This is useful to provide feedback if arguments were provided even though none are expected.
/// </summary>
public static class ConsoleArgumentsEmpty
{
    /// <summary>
    /// Parse the arguments provided to the executable.
    /// </summary>
    /// <param name="args"></param>
    public static void Parse(string[] args) =>
        _consoleArguments.ParseAndValidate(args, Assembly.GetCallingAssembly().GetName().Name);

    private static readonly ConsoleArguments _consoleArguments = new(
        flagOptional: true,
        logParsedOptions: true
    );
}
