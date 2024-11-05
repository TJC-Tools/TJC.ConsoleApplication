namespace TJC.ConsoleApplication.Arguments.Options.Specific;

/// <summary>
/// This argument is intended for applications that requires the option to set the verbosity of the logs.
/// </summary>
public class VerbosityArgument : ICustomArgument
{
    private const string _prototype = "v|verbose|verbosity";

    /// <summary>
    /// Allows both the boolean &amp; value argument formats (<c>-v=3</c> &amp; <c>-v</c>).
    /// <para>This allows the the arguments [<c>-v=3</c>] and [<c>-v -v -v</c>] to both result in a <see cref="Verbosity"/> of 3</para>
    /// </summary>
    public static VerbosityArgument Both =>
        new(prototype: $"{_prototype}:", description: "Set/Increase Message Verbosity");

    /// <summary>
    /// Only allows the boolean argument format (<c>-v</c>).
    /// </summary>
    public static VerbosityArgument BoolOnly =>
        new(prototype: _prototype, description: "Increase Message Verbosity");

    /// <summary>
    /// Only allows the value argument format (<c>-v=3</c>).
    /// </summary>
    public static VerbosityArgument ValueOnly =>
        new(prototype: $"{_prototype}=", description: "Set Message Verbosity");

    /// <summary>
    /// Constructor for the verbosity argument.
    /// </summary>
    /// <param name="prototype"></param>
    /// <param name="description"></param>
    public VerbosityArgument(string prototype, string description = "Logging Verbosity") =>
        Argument = new Argument(null, prototype, SetVerbosity, isRequired: false, description);

    /// <summary>
    /// Verbosity level set by the argument.
    /// </summary>
    public int Verbosity { get; private set; }

    /// <summary>
    /// Argument to be added to the list of <seealso cref="ConsoleArguments"/>.
    /// </summary>
    public Argument Argument { get; }

    private void SetVerbosity(string input)
    {
        if (int.TryParse(input, out var result))
            Verbosity += result;
        else
            Verbosity++;
    }
}
