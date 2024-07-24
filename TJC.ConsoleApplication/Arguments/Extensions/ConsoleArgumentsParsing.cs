namespace TJC.ConsoleApplication.Arguments.Extensions;

public static class ConsoleArgumentsParsing
{
    /// <summary>
    /// Parses Options, and Validates that there are no Invalid or Missing Arguments
    /// </summary>
    /// <param name="arguments">Valid Argument Options</param>
    /// <param name="args">Arguments from console application call</param>
    /// <param name="programName">Name of Program</param>
    public static void ParseAndValidate(this ConsoleArguments arguments,
                                        string[] args,
                                        string? programName = null)
    {
        var showHelp = false;
        arguments.Add("h|?|help", v => showHelp = !string.IsNullOrEmpty(v), "Show Help Menu");

        if (arguments.LogParsedOptions && args.Length > 0)
            ConsoleOutputHandler.WriteLine("Parse Arguments:");
        arguments.ParseArguments(args, out var invalidArguments);

        if (showHelp)
            arguments.ShowHelpAndExit(programName);

        var exitCodes = new ExitCodes();
        if (invalidArguments.HasInvalid())
            exitCodes |= ExitCodes.InvalidArguments;
        if (arguments.IsMissingRequired())
            exitCodes |= ExitCodes.MissingArguments;
        if (exitCodes > 0)
            EnvironmentEx.ExitCode(exitCodes);
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
    private static bool IsMissingRequired(this ConsoleArguments arguments)
    {
        var missingArguments = arguments.Where(x => (x.IsRequired ?? false) && !x.IsUsed).ToList();
        if (missingArguments.Count == 0)
            return false;
        var argStr = string.Join(", ", missingArguments.Select(x => x.GetPrototypeFormat()));
        ConsoleOutputHandler.WriteLine($"Missing {missingArguments.Pluralize("argument")}: [{argStr}]");
        return true;
    }
}