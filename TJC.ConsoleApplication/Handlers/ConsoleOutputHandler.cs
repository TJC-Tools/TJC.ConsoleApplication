namespace TJC.ConsoleApplication.Handlers;

internal static class ConsoleOutputHandler
{
    internal static bool Silent { get; private set; }

    internal static void ResetSilent() =>
        Silent = false;

    internal static void Write(string message)
    {
        if (!Silent)
            Console.Write(message);
    }

    internal static void WriteLine(string message)
    {
        if (!Silent)
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