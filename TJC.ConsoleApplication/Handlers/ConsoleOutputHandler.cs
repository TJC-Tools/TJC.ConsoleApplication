namespace TJC.ConsoleApplication.Handlers;

internal static class ConsoleOutputHandler
{
    public static bool Silent { get; set; }

    public static void Write(string message)
    {
        if (!Silent)
            Console.Write(message);
    }

    public static void WriteLine(string message)
    {
        if (!Silent)
            Console.WriteLine(message);
    }

    public static void Empty()
    {
        WriteLine(string.Empty);
    }

    public static void LineBreak()
    {
        WriteLine(new string('-', 119));
    }

    public static void ClearCurrentLine()
    {
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, currentLineCursor);
    }
}
