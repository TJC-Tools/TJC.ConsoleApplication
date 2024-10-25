namespace TJC.ConsoleApplication.Arguments.Interfaces;

public interface IConsoleArguments : IEnumerable<ConsoleArgument>
{
    /// <summary>
    /// Parses Options, and Validates that there are no Invalid or Missing Arguments
    /// </summary>
    /// <param name="args">Arguments from console application call</param>
    /// <param name="programName">Name of Program</param>
    /// <param name="exitOnFailureToParse">Exit Program on Failure to Parse</param>
    void ParseAndValidate(string[] args, string? programName = null, bool exitOnFailureToParse = true);
}