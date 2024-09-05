using System.Diagnostics;

namespace TJC.ConsoleApplication.Handlers;

internal class ConsoleOutputTraceListener : ConsoleTraceListener
{
    public new static void Write(string message) =>
        ConsoleOutputHandler.Write(message);

    public new static void WriteLine(string message) =>
        ConsoleOutputHandler.WriteLine(message);
}