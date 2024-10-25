namespace TJC.ConsoleApplication.Arguments.Extensions;

internal static class ConsoleArgumentsParsing
{
    internal static void ParseAndValidate(IConsoleArguments arguments,
                                          string[] args,
                                          string? programName,
                                          bool exitOnFailureToParse)
    {
        if (arguments.LogParsedOptions && args.Length > 0)
            ConsoleOutputHandler.WriteLine("Parse Arguments:");
        arguments.ParseArguments(args, out var invalidArguments);

        if (HelpArgument.Instance.Argument.IsUsed)
            arguments.WriteHelp(programName);

        if (arguments.Any(x => x is { IsUsed: true, ExitIfUsed: true }))
            EnvironmentEx.ExitCode(ExitCodes.Success);

        var exitCodes = new ExitCodes();
        if (invalidArguments.HasInvalid())
            exitCodes |= ExitCodes.InvalidArguments;
        if (arguments.IsMissingRequired())
            exitCodes |= ExitCodes.MissingArguments;
        if (exitCodes > 0 && exitOnFailureToParse)
            EnvironmentEx.ExitCode(exitCodes);
    }

    /// <summary>
    /// Uses <see cref="OptionSet"/> to attempt to parse the arguments.
    /// <para>If it fails to parse, it will display the exception to the user.</para>
    /// </summary>
    /// <param name="arguments">Options</param>
    /// <param name="args">Arguments</param>
    /// <param name="invalidArguments">Return Invalid Arguments</param>
    /// <exception cref="OptionException">E.g. If an no value was supplied to a non-boolean argument</exception>
    /// <exception cref="Exception">Unknown Exception Types</exception>
    /// <returns></returns>
    internal static void ParseArguments(this IEnumerable<Argument> arguments, IEnumerable<string> args, out List<string> invalidArguments)
    {
        try
        {
            invalidArguments = arguments.ToOptionSet().Parse(args);
        }
        catch (OptionException e)
        {
            EnvironmentEx.ExitCode(ExitCodes.InvalidArguments, e.Message);
            throw;
        }
        catch (Exception e)
        {
            EnvironmentEx.ExitCode(ExitCodes.UnknownException, e.Message);
            throw;
        }
    }

    /// <summary>
    /// Checks if any arguments are invalid (i.e. attempting to use an argument that does not actually exist)
    /// </summary>
    /// <param name="invalidArguments"></param>
    /// <returns></returns>
    private static bool HasInvalid(this IReadOnlyCollection<string> invalidArguments)
    {
        if (invalidArguments.Count == 0)
            return false;
        var argStr = string.Join(", ", invalidArguments);
        ConsoleOutputHandler.WriteLine($"Invalid {invalidArguments.Pluralize("argument")}: [{argStr}]");
        return true;
    }

    /// <summary>
    /// Checks if any required arguments were omitted
    /// </summary>
    /// <param name="arguments"></param>
    /// <returns></returns>
    private static bool IsMissingRequired(this IEnumerable<Argument> arguments)
    {
        var missingArguments = arguments.Where(x => (x.IsRequired ?? false) && !x.IsUsed).ToList();
        if (missingArguments.Count == 0)
            return false;
        var argStr = string.Join(", ", missingArguments.Select(x => x.GetPrototypeHelpString()));
        ConsoleOutputHandler.WriteLine($"Missing {missingArguments.Pluralize("argument")}: [{argStr}]");
        return true;
    }
}
