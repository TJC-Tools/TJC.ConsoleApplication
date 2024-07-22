using System.Diagnostics.CodeAnalysis;

namespace TJC.ConsoleApplication.Exit;

public static class EnvironmentEx
{
    /// <summary>
    /// Uses <see cref="ExitCodes"/> to end the process
    /// </summary>
    /// <remarks>Recommended to use this with <see cref="ProcessExitExtensions"/></remarks>
    /// <param name="exitCode"></param>
    /// <param name="message"></param>
    [DoesNotReturn]
    public static void ExitCode(ExitCodes exitCode, string? message = null)
    {
        if (!string.IsNullOrEmpty(message))
            ConsoleOutputHandler.WriteLine(message);
        Environment.Exit((int)exitCode);
    }
}