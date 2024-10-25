namespace TJC.ConsoleApplication.Arguments.Extensions;

internal static class ConsoleArgumentsHelp
{
    /// <summary>
    /// Show the help menu
    /// <para>This includes all options</para>
    /// </summary>
    /// <param name="arguments"></param>
    /// <param name="programName"></param>
    internal static void ShowHelp(this ConsoleArguments arguments, string? programName)
    {
        ConsoleOutputHandler.Silent = false;
        arguments.PrintHelp(programName);
    }

    /// <summary>
    /// Prints Help Menu for Options within Program
    /// </summary>
    /// <param name="arguments"></param>
    /// <param name="programName"></param>
    public static void PrintHelp(this ConsoleArguments arguments, string? programName = null)
    {
        arguments.PrintUsage(programName);
        ConsoleOutputHandler.Empty();
        arguments.PrintOptions();
    }

    /// <summary>
    /// Print Single Line Usage Statement
    /// </summary>
    /// <param name="arguments"></param>
    /// <param name="programName"></param>
    private static void PrintUsage(this ConsoleArguments arguments, string? programName)
    {
        ConsoleOutputHandler.WriteLine("Usage:");
        PrintLinesWithTitle($"  {programName}", $"{arguments.Aggregate(string.Empty, (c, opt) => c + $"[{opt.GetHelpString()}] ").Trim()}");
    }

    /// <summary>
    /// Prints Table of Options with Property, Description, Required/Optional
    /// </summary>
    /// <param name="arguments"></param>
    private static void PrintOptions(this ConsoleArguments arguments)
    {
        ConsoleOutputHandler.WriteLine("Flags:");
        foreach (var argument in arguments)
            PrintLinesWithTitle($"  {argument.GetHelpString(true)}", string.Concat(argument.Flags, argument.Description));
    }

    private static void PrintLinesWithTitle(string title, string line) =>
        PrintLinesWithTitle(title, line.SplitLines());

    private static void PrintLinesWithTitle(string title, List<string> lines)
    {
        var width = title.Length;
        foreach (var line in lines)
        {
            ConsoleOutputHandler.WriteLine($"{title.PadLeft(width)} {line.Trim()}");
            title = string.Empty;
        }
    }
}