namespace TJC.ConsoleApplication.Tests.Inputs;

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