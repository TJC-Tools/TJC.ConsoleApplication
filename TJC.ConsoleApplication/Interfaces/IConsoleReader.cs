namespace TJC.ConsoleApplication.Interfaces;

public interface IConsoleReader
{
    ConsoleKeyInfo ReadKey();

    string? ReadLine();

    int Read();
}