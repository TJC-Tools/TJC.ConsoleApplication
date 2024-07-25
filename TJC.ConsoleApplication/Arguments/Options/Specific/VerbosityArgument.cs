﻿namespace TJC.ConsoleApplication.Arguments.Options.Specific;

/// <summary>
/// This argument is intended for applications that requires the option to set the verbosity of the logs.
/// </summary>
public class VerbosityArgument : IConsoleArgument
{
    private const string _prototype = "v|verbose|verbosity";

    /// <summary>
    /// Allows both the boolean &amp; value argument formats (<c>-v=3</c> &amp; <c>-v</c>).
    /// <para>This allows the the arguments [<c>-v=3</c>] and [<c>-v -v -v</c>] to both result in a <see cref="Verbosity"/> of 3</para>
    /// </summary>
    public static VerbosityArgument Both => new(prototype: $"{_prototype}:", description: "Set/Increase Message Verbosity");

    /// <summary>
    /// Only allows the boolean argument format (<c>-v</c>).
    /// </summary>
    public static VerbosityArgument BoolOnly => new(prototype: _prototype, description: "Increase Message Verbosity");

    /// <summary>
    /// Only allows the value argument format (<c>-v=3</c>).
    /// </summary>
    public static VerbosityArgument ValueOnly => new(prototype: $"{_prototype}=", description: "Set Message Verbosity");

    public VerbosityArgument(string prototype, string description = "Logging Verbosity") =>
        Argument = new ConsoleArgument(null, prototype, SetVerbosity, isRequired: false, description);

    public int Verbosity { get; private set; }

    public ConsoleArgument Argument { get; }

    private void SetVerbosity(string input)
    {
        if (int.TryParse(input, out var result))
            Verbosity += result;
        else
            Verbosity++;
    }
}