namespace TJC.ConsoleApplication.Arguments.Extensions;

public static class ConsoleArgumentsConversion
{
    /// <summary>
    /// Uses <see cref="OptionSet"/> to attempt to parse the arguments.
    /// <para>If it fails to parse, it will display the exception to the user.</para>
    /// </summary>
    /// <param name="arguments">Options</param>
    /// <param name="args">Arguments</param>
    /// <param name="invalidArguments">Return Invalid Arguments</param>
    /// <exception cref="OptionException">E.g. If an no value was supplied to a non-boolean argument</exception>
    /// <exception cref="Exception">Unknown Exception Types</exception>
    /// <returns></returns>
    internal static void ParseArguments(this ConsoleArguments arguments, IEnumerable<string> args, out List<string> invalidArguments)
    {
        try
        {
            invalidArguments = arguments.ToOptionSet().Parse(args);
        }
        catch (OptionException e)
        {
            EnvironmentEx.ExitCode(ExitCodes.InvalidArguments, e.Message);
            throw;
        }
        catch (Exception e)
        {
            EnvironmentEx.ExitCode(ExitCodes.UnknownException, e.Message);
            throw;
        }
    }

    /// <summary>
    /// Convert <see cref="ConsoleArguments"/> to <see cref="OptionSet"/>.
    /// </summary>
    /// <param name="arguments">Options</param>
    /// <returns></returns>
    private static OptionSet ToOptionSet(this ConsoleArguments arguments)
    {
        var optionSet = new OptionSet();
        arguments.ForEach(x => x.AddTo(optionSet));
        return optionSet;
    }

    /// <summary>
    /// Convert and add a <see cref="ConsoleArgument"/> to <see cref="OptionSet"/>.
    /// </summary>
    /// <param name="option"></param>
    /// <param name="optionSet"></param>
    private static void AddTo(this ConsoleArgument option, OptionSet optionSet) =>
        optionSet.Add(option.Prototype, option.Description, option.SetOptionValue);
}