namespace TJC.ConsoleApplication.Tests.Prompts;


public class InputTestsBaseClass : IDisposable
{
    public InputTestsBaseClass()
    {
        ConsoleInputHandler.SetConsoleReader(MockUserInput.MockConsoleReader.Object);
        MockUserInput.Setup();
    }

    public void Dispose()
    {
        MockUserInput.Cleanup();
    }
}
