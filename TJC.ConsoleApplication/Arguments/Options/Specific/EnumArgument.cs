namespace TJC.ConsoleApplication.Arguments.Options.Specific;

/// <summary>
/// Enum argument to be used in the <seealso cref="ConsoleArguments"/>.
/// </summary>
/// <typeparam name="TEnum"></typeparam>
public class EnumArgument<TEnum>
    : ICustomArgument
    where TEnum : struct, Enum
{
    private readonly Dictionary<string, TEnum> _commandConversion = [];

    /// <summary>
    /// Constructor for the enum argument.
    /// </summary>
    /// <param name="description"></param>
    /// <param name="isRequired"></param>
    /// <param name="exitIfUsed"></param>
    public EnumArgument(string description = "Select enum value", bool isRequired = false, bool exitIfUsed = false)
    {
        foreach (var value in Enum.GetValues<TEnum>())
            _commandConversion.Add(value.ToString().ToKebabCase(), value);
        Argument = new(null, Prototype, SetSelectedValue, isRequired: isRequired, description: description, exitIfUsed: exitIfUsed);
    }

    private string Prototype =>
        string.Join('|', _commandConversion.Select(x => x.Key));

    /// <summary>
    /// Argument to be added to the list of <seealso cref="ConsoleArguments"/>.
    /// </summary>
    public Argument Argument { get; }

    /// <summary>
    /// Selected enum value.
    /// </summary>
    public TEnum? Selection { get; private set; }

    private void SetSelectedValue(string argument)
    {
        if (!_commandConversion.TryGetValue(argument, out TEnum command))
            throw new Exception($"Failed to find [{typeof(TEnum).Name}] of type [{argument}]");
        Selection = command;
    }
}