namespace TJC.ConsoleApplication.Tests.Mocks
{
    internal static class ConsoleReaderMockHelpers
    {
        public static void SetReadKeyMock(ConsoleKey key)
        {
            var mockConsoleReader = new Mock<IConsoleReader>();
            var consoleKeyInfo = new ConsoleKeyInfo((char)key, key, false, false, false);
            mockConsoleReader.Setup(cr => cr.ReadKey()).Returns(consoleKeyInfo);
            ConsoleInputHandler.SetConsoleReader(mockConsoleReader.Object);
        }
    }
}
