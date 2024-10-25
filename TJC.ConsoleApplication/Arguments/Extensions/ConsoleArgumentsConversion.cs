namespace TJC.ConsoleApplication.Arguments.Extensions;

internal static class ConsoleArgumentsConversion
{
    /// <summary>
    /// Convert <see cref="ConsoleArguments"/> to <see cref="OptionSet"/>.
    /// </summary>
    /// <param name="arguments">Options</param>
    /// <returns></returns>
    internal static OptionSet ToOptionSet(this IEnumerable<Argument> arguments)
    {
        var optionSet = new OptionSet();
        arguments.ToList().ForEach(x => x.AddTo(optionSet));
        return optionSet;
    }

    /// <summary>
    /// Convert a single <see cref="Argument"/> to <see cref="OptionSet"/>.
    /// </summary>
    /// <param name="argument">Options</param>
    /// <returns></returns>
    internal static OptionSet ToOptionSet(this Argument argument)
    {
        var optionSet = new OptionSet();
        argument.AddTo(optionSet);
        return optionSet;
    }

    /// <summary>
    /// Add a <see cref="Argument"/> to <see cref="OptionSet"/>.
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="optionSet"></param>
    internal static void AddTo(this Argument argument, OptionSet optionSet) =>
        optionSet.Add(argument.Prototype, argument.Description, argument.SetOptionValue);
}