namespace TJC.ConsoleApplication.Handlers;

internal class StandardConsoleReader : IConsoleReader
{
    public ConsoleKeyInfo ReadKey(bool intercept) =>
        Console.ReadKey(intercept);

    public ConsoleKeyInfo ReadKey() =>
        Console.ReadKey();

    public string? ReadLine() =>
        Console.ReadLine();

    public int Read() =>
        Console.Read();
}