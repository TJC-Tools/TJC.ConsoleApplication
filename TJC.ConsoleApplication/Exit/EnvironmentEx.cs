using System.Diagnostics.CodeAnalysis;

namespace TJC.ConsoleApplication.Exit;

/// <summary>
/// Extra environment methods.
/// </summary>
public static class EnvironmentEx
{
    /// <summary>
    /// Uses <see cref="ExitCodes"/> to end the process.
    /// <para></para>
    /// It also disables <seealso cref="ConsoleOutputHandler.Silent"/>, so that any errors will be displayed.
    /// </summary>
    /// <remarks>Recommended to use this with <see cref="ProcessExitExtensions"/></remarks>
    /// <param name="exitCode"></param>
    /// <param name="message"></param>
    [DoesNotReturn]
    public static void ExitCode(ExitCodes exitCode, string? message = null)
    {
        ConsoleOutputHandler.Silent = false;
        if (!string.IsNullOrEmpty(message))
            ConsoleOutputHandler.WriteLine(message);
        Environment.Exit((int)exitCode);
    }
}
