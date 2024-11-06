namespace TJC.ConsoleApplication.Handlers;

internal static class ConsoleInputHandler
{
    private static IConsoleReader _consoleReader = new StandardConsoleReader();

    internal static void SetConsoleReader(IConsoleReader consoleReader) =>
        _consoleReader = consoleReader;

    public static char ReadKey(bool intercept) => _consoleReader.ReadKey(intercept).KeyChar;

    public static char ReadKey() => _consoleReader.ReadKey().KeyChar;

    public static string? ReadLine() => _consoleReader.ReadLine();

    public static int Read() => _consoleReader.Read();
}
