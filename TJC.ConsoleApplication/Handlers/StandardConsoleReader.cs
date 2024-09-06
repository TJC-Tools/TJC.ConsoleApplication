namespace TJC.ConsoleApplication.Handlers;

internal class StandardConsoleReader : IConsoleReader
{
    public ConsoleKeyInfo ReadKey(bool intercept = false) =>
        Console.ReadKey(intercept);

    public string? ReadLine() =>
        Console.ReadLine();

    public int Read() =>
        Console.Read();
}