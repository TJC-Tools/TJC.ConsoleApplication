namespace TJC.ConsoleApplication.Interfaces;

public interface IConsoleReader
{
    ConsoleKeyInfo ReadKey(bool intercept = false);

    string? ReadLine();

    int Read();
}