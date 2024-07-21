namespace TJC.ConsoleApplication.Tests.Mocks;

internal static class ConsoleReaderMockHelpers
{
    private static Mock<IConsoleReader> _mockConsoleReader = new Mock<IConsoleReader>();

    public static void SetReadKeyMock(ConsoleKey key)
    {
        var consoleKeyInfo = new ConsoleKeyInfo((char)key, key, false, false, false);
        _mockConsoleReader.Setup(cr => cr.ReadKey()).Returns(consoleKeyInfo);
        ConsoleInputHandler.SetConsoleReader(_mockConsoleReader.Object);
    }

    public static void SetReadLineMock(string line)
    {
        _mockConsoleReader.Setup(cr => cr.ReadLine()).Returns(line);
        ConsoleInputHandler.SetConsoleReader(_mockConsoleReader.Object);
    }

    public static void SetReadMock(int num)
    {
        _mockConsoleReader.Setup(cr => cr.Read()).Returns(num);
        ConsoleInputHandler.SetConsoleReader(_mockConsoleReader.Object);
    }
}