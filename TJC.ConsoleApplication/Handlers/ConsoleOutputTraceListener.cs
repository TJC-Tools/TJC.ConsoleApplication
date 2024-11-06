using System.Diagnostics;

namespace TJC.ConsoleApplication.Handlers;

internal class ConsoleOutputTraceListener : ConsoleTraceListener
{
    public static new void Write(string message) => ConsoleOutputHandler.Write(message);

    public static new void WriteLine(string message) => ConsoleOutputHandler.WriteLine(message);
}
