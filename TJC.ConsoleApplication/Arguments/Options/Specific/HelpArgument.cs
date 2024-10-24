﻿namespace TJC.ConsoleApplication.Arguments.Options.Specific;

/// <summary>
/// This argument is used to show the help menu.
/// </summary>
public class HelpArgument(string description = "Show Help Menu")
    : IConsoleArgument
{
    private const string Prototype = "h|?|help";

    /// <summary>
    /// Default settings for the help argument.
    /// </summary>
    public static HelpArgument Default => new();

    /// <summary>
    /// Argument to be added to the list of <seealso cref="ConsoleArguments"/>.
    /// </summary>
    public ConsoleArgument Argument { get; } = new(null, Prototype, v => { }, isRequired: false, description, exitIfUsed: true);
}