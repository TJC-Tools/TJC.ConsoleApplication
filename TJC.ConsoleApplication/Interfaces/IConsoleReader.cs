namespace TJC.ConsoleApplication.Interfaces;

/// <summary>
/// Interface for reading input from the console.
/// </summary>
public interface IConsoleReader
{
    /// <summary>
    /// Read a key from the console.
    /// </summary>
    /// <param name="intercept"></param>
    /// <returns></returns>
    ConsoleKeyInfo ReadKey(bool intercept);

    /// <summary>
    /// Read a key from the console.
    /// </summary>
    /// <returns></returns>
    ConsoleKeyInfo ReadKey();

    /// <summary>
    /// Read a line from the console.
    /// </summary>
    /// <returns></returns>
    string? ReadLine();

    /// <summary>
    /// Read from the console.
    /// </summary>
    /// <returns></returns>
    int Read();
}
