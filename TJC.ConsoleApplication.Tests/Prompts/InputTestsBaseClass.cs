namespace TJC.ConsoleApplication.Tests.Prompts;

[TestClass]
public class InputTestsBaseClass
{
    [TestInitialize]
    public void Initialize()
    {
        ConsoleInputHandler.SetConsoleReader(MockUserInput.MockConsoleReader.Object);
        MockUserInput.Setup();
    }

    [TestCleanup]
    public void TestCleanup()
    {
        MockUserInput.Cleanup();
    }
}
