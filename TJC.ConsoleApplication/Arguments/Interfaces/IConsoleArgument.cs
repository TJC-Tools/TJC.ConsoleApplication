namespace TJC.ConsoleApplication.Arguments.Interfaces;

/// <summary>
/// Interface used by pre-defined console arguments to allow it to be added to the list of <seealso cref="ConsoleArguments"/>.
/// </summary>
public interface IConsoleArgument
{
    /// <summary>
    /// Argument to be added to the list of <seealso cref="ConsoleArguments"/>.
    /// </summary>
    ConsoleArgument Argument { get; }
}