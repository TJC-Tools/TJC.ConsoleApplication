namespace TJC.ConsoleApplication.Handlers;

internal static class ConsoleInputHandler
{
    private static IConsoleReader _consoleReader = new StandardConsoleReader();

    internal static void SetConsoleReader(IConsoleReader consoleReader) =>
        _consoleReader = consoleReader;

    public static char ReadKey(bool intercept = false) =>
        _consoleReader.ReadKey(intercept).KeyChar;

    public static string? ReadLine() =>
        _consoleReader.ReadLine();

    public static int Read() =>
        _consoleReader.Read();
}