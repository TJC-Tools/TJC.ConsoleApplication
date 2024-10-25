namespace TJC.ConsoleApplication.Arguments.Interfaces;

/// <summary>
/// Interface for Console Arguments.
/// </summary>
public interface IConsoleArguments : IEnumerable<Argument>
{
    /// <summary>
    /// Flag required options in help menu.
    /// </summary>
    bool FlagRequired { get; set; }

    /// <summary>
    /// Flag optional options in help menu.
    /// </summary>
    bool FlagOptional { get; set; }

    /// <summary>
    /// Write parsed options to the console.
    /// </summary>
    bool LogParsedOptions { get; set; }

    /// <summary>
    /// Parses Options, and Validates that there are no Invalid or Missing Arguments
    /// </summary>
    /// <param name="args">Arguments from console application call</param>
    /// <param name="programName">Name of Program</param>
    /// <param name="exitOnFailureToParse">Exit Program on Failure to Parse</param>
    void ParseAndValidate(string[] args, string? programName = null, bool exitOnFailureToParse = true);

    /// <summary>
    /// Writes a help menu for the options.
    /// </summary>
    /// <param name="programName"></param>
    void WriteHelp(string? programName = null);
}