using TJC.StringExtensions.Cases;

namespace TJC.ConsoleApplication.Arguments.Options.Specific;

/// <summary>
/// Enum argument to be used in the <seealso cref="ConsoleArguments"/>.
/// </summary>
/// <typeparam name="TEnum"></typeparam>
public class EnumArgument<TEnum> : IConsoleArgument
    where TEnum : struct, Enum
{
    private readonly Dictionary<string, TEnum> _commandConversion = [];

    /// <summary>
    /// Constructor for the enum argument.
    /// </summary>
    /// <param name="description"></param>
    /// <param name="exitIfUsed"></param>
    public EnumArgument(string description = "Select enum value", bool exitIfUsed = false)
    {
        foreach (var value in Enum.GetValues<TEnum>())
        {
            // Convert the enum value to a kebab-case string for use within arguments.
            var kebab = value.ToString().SplitCamelCase().ToLower().Replace('_', '-');
            _commandConversion.Add(kebab, value);
        }
        Argument = new(null, Prototype, SetSelectedValue, isRequired: true, description, exitIfUsed: exitIfUsed);
    }

    private string Prototype =>
        string.Join('|', _commandConversion.Select(x => x.Key));

    /// <summary>
    /// Argument to be added to the list of <seealso cref="ConsoleArguments"/>.
    /// </summary>
    public ConsoleArgument Argument { get; }

    /// <summary>
    /// Selected enum value.
    /// </summary>
    public TEnum SelectedEnumValue { get; private set; }

    private void SetSelectedValue(string argument)
    {
        if (!_commandConversion.TryGetValue(argument, out TEnum command))
            throw new Exception($"Failed to find [{typeof(TEnum).Name}] of type [{argument}]");
        SelectedEnumValue = command;
    }
}