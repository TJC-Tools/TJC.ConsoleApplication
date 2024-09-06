namespace TJC.ConsoleApplication.Interfaces;

public interface IConsoleReader
{
    ConsoleKeyInfo ReadKey(bool intercept);

    ConsoleKeyInfo ReadKey();

    string? ReadLine();

    int Read();
}