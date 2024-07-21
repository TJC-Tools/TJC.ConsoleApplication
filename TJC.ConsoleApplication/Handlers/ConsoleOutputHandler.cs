namespace TJC.ConsoleApplication.Handlers;

internal static class ConsoleOutputHandler
{
    internal static void Write(string message)
    {
        Console.Write(message);
    }

    internal static void WriteLine(string message)
    {
        Console.WriteLine(message);
    }

    internal static void Empty()
    {
        WriteLine(string.Empty);
    }

    internal static void LineBreak()
    {
        WriteLine(new string('-', 119));
    }
}