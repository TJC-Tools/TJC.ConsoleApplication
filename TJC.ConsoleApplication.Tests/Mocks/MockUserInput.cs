namespace TJC.ConsoleApplication.Tests.Mocks;

internal static class MockUserInput
{
    #region Fields

    internal static readonly Mock<IConsoleReader> MockConsoleReader = new();

    private static readonly Queue<ConsoleKey> _keys = new();

    private static readonly Queue<string> _lines = new();

    private static readonly Queue<int> _nums = new();

    #endregion

    #region Methods

    #region Setup

    public static void Setup()
    {
        MockConsoleReader.Setup(cr => cr.ReadKey()).Returns(MockUserPressesKey);
        MockConsoleReader.Setup(cr => cr.ReadLine()).Returns(MockUserEntersText);
        MockConsoleReader.Setup(cr => cr.Read()).Returns(MockUserEntersInt);
    }

    #endregion

    #region Cleanup

    public static void Cleanup()
    {
        _keys.Clear();
        _lines.Clear();
        _nums.Clear();
    }

    #endregion

    #region Add Mock User Input

    public static void QueueKey(ConsoleKey key)
    {
        _keys.Enqueue(key);
    }

    public static void QueueLine(string line)
    {
        _lines.Enqueue(line);
    }

    public static void QueueNum(int num)
    {
        _nums.Enqueue(num);
    }

    #endregion

    #region Mock User Input

    private static ConsoleKeyInfo MockUserPressesKey()
    {
        var key = _keys.Dequeue();
        ConsoleOutputHandler.WriteLine($"{key}");
        return new ConsoleKeyInfo((char)key, key, false, false, false);
    }

    private static string MockUserEntersText()
    {
        var line = _lines.Dequeue();
        ConsoleOutputHandler.WriteLine(line);
        return line;
    }

    private static int MockUserEntersInt()
    {
        var num = _nums.Dequeue();
        ConsoleOutputHandler.WriteLine($"{num}");
        return num;
    }

    #endregion

    #endregion
}
