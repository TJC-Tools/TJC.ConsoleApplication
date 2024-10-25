namespace TJC.ConsoleApplication.Arguments.Extensions;

internal static class ConsoleArgumentsHelp
{
    /// <summary>
    /// Writes a help menu for the options.
    /// </summary>
    /// <param name="arguments"></param>
    /// <param name="programName"></param>
    internal static void WriteHelp(this IEnumerable<Argument> arguments, string? programName = null)
    {
        ConsoleOutputHandler.Silent = false;
        arguments.WriteUsage(programName);
        ConsoleOutputHandler.Empty();
        arguments.WriteFlags();
    }

    /// <summary>
    /// Print Single Line Usage Statement
    /// </summary>
    /// <param name="arguments"></param>
    /// <param name="programName"></param>
    private static void WriteUsage(this IEnumerable<Argument> arguments, string? programName)
    {
        ConsoleOutputHandler.WriteLine("Usage:");
        PrintLinesWithTitle(
            $"  {programName}",
            $"{arguments.Aggregate(string.Empty, (c, opt) => c + $"[{opt.GetHelpString()}] ").Trim()}");
    }

    /// <summary>
    /// Prints Table of Options with Property, Description, Required/Optional
    /// </summary>
    /// <param name="arguments"></param>
    private static void WriteFlags(this IEnumerable<Argument> arguments)
    {
        var maxPrototypeWidth = arguments.Max(x => x.GetPrototypeFormat().Length);
        var maxPropertyWidth = arguments.Max(x => x.PropertyName?.Length ?? 0);
        ConsoleOutputHandler.WriteLine("Flags:");
        foreach (var argument in arguments)
            PrintLinesWithTitle(
                $"  {argument.GetHelpString(true, maxPrototypeWidth, maxPropertyWidth)}",
                argument.GetHelpDescription());
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