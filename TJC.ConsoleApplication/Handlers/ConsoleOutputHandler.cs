namespace TJC.ConsoleApplication.Handlers;

public static class ConsoleOutputHandler
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
}