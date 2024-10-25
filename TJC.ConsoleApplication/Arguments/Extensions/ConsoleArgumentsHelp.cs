namespace TJC.ConsoleApplication.Arguments.Extensions;

internal static class ConsoleArgumentsHelp
{
    /// <summary>
    /// Writes a help menu for the options.
    /// </summary>
    /// <param name="arguments"></param>
    /// <param name="programName"></param>
    internal static void WriteHelp(this IConsoleArguments arguments, string? programName = null)
    {
        ConsoleOutputHandler.Silent = false;
        arguments.WriteUsage(programName);
        ConsoleOutputHandler.Empty();
        arguments.WriteFlags();
    }

    #region Usage

    private static void WriteUsage(this IEnumerable<Argument> arguments, string? programName)
    {
        ConsoleOutputHandler.WriteLine("Usage:");
        var options = $"{arguments.Aggregate(string.Empty, (c, opt) => c + $"[{opt.GetHelpString()}] ").Trim()}";
        WriteLinesWithTitle($"  {programName}", options);
    }

    #endregion

    #region Flags

    private static void WriteFlags(this IConsoleArguments arguments)
    {
        var maxPrototypeWidth = arguments.Max(x => x.GetPrototypeHelpString().Length);
        var maxPropertyWidth = arguments.Max(x => x.PropertyName?.Length ?? 0);
        ConsoleOutputHandler.WriteLine("Flags:");
        foreach (var argument in arguments)
            WriteLinesWithTitle(
                $"  {argument.GetHelpString(true, maxPrototypeWidth, maxPropertyWidth)}",
                argument.GetHelpDescription(arguments));
    }

    #endregion

    #region Argument Help

    internal static string GetHelpString(
        this Argument argument,
        bool formatted = false,
        int prototypeWidth = 0,
        int propertyWidth = 0)
    {
        var prototype = argument.GetPrototypeHelpString();
        var property = argument.PropertyName ?? string.Empty;
        if (formatted)
        {
            prototype = prototype.PadRight(prototypeWidth);
            property = property.PadRight(propertyWidth);
        }
        return string.Concat(prototype, " ", property);
    }

    internal static string GetPrototypeHelpString(this Argument argument) =>
        $"--{argument.Prototype.TrimEnd('=').TrimEnd(':')}";

    internal static string GetPrototypeHelpStringFormatted(this Argument argument)
    {
        var prototype = string.Empty;
        var flags = argument.Prototype.TrimEnd('=').TrimEnd(':').Split('|');

        // Single character flag is at the start with single dash (-) and a comma (,) separator 
        var singleCharFlag = flags.FirstOrDefault(x => x.Length == 1);
        var part1 = singleCharFlag == null ? new string(' ', 3) : $"-{singleCharFlag},";

        // Other flags are at the end with double dash (--) and a pipe (|) separator 
        var otherFlags = flags.Where(x => x != singleCharFlag).ToList();
        var part2 = string.Join('|', otherFlags);

        // Return formatted prototype
        return $"--{part1} {part2}";
    }

    internal static string GetHelpDescription(this Argument argument, IConsoleArguments parent)
    {
        var flags = argument.IsRequired switch
        {
            null when parent.FlagRequired || parent.FlagOptional => "(Sometimes Required) ",
            true when parent.FlagRequired => "(Required) ",
            false when parent.FlagOptional => "(Optional) ",
            _ => string.Empty
        };
        return string.Concat(flags, argument.Description);
    }

    #endregion

    #region Formatters

    private static void WriteLinesWithTitle(string title, string line) =>
        WriteLinesWithTitle(title, line.SplitLines());

    private static void WriteLinesWithTitle(string title, List<string> lines)
    {
        var width = title.Length;
        foreach (var line in lines)
        {
            ConsoleOutputHandler.WriteLine($"{title.PadLeft(width)} {line.Trim()}");
            title = string.Empty;
        }
    }

    #endregion
}