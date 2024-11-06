namespace TJC.ConsoleApplication.Tests.Prompts;

[TestClass]
public class ChoiceEnumPromptTests : ChoicePromptTestsBase
{
    [TestMethod]
    public void GetChoiceEnum_ResponseOption3_ReturnsOption3()
    {
        // Arrange
        MockUserInput.QueueLine("3");

        // Act
        var result = ConsolePrompt.GetChoice<SampleEnumChoices>("Choose");

        // Assert
        Assert.AreEqual(SampleEnumChoices.Option3, result);
    }

    [TestMethod]
    public void GetChoiceEnum_MultipleInvalidResponsesThenResponseOption3_ReturnsOption3()
    {
        // Arrange
        MockUserInput.QueueLine("-3");
        MockUserInput.QueueLine("300");
        MockUserInput.QueueLine("test");
        MockUserInput.QueueLine("Option 1");
        MockUserInput.QueueLine("0");
        MockUserInput.QueueLine("3");

        // Act
        var result = ConsolePrompt.GetChoice<SampleEnumChoices>("Choose");

        // Assert
        Assert.AreEqual(SampleEnumChoices.Option3, result);
    }

    [TestMethod]
    public void GetChoiceDoneEnum_ResponseOption3_ReturnsOption3()
    {
        // Arrange
        MockUserInput.QueueLine("3");

        // Act
        var result = ConsolePrompt.GetChoice<SampleEnumChoices>("Choose");

        // Assert
        Assert.AreEqual(SampleEnumChoices.Option3, result);
    }

    [TestMethod]
    public void GetChoiceDoneEnum_ResponseDone_ReturnsNull()
    {
        // Arrange
        MockUserInput.QueueLine("0");

        // Act
        var result = ConsolePrompt.GetChoiceDone<SampleEnumChoices>("Choose");

        // Assert
        Assert.IsNull(result);
    }

    [TestMethod]
    public void GetChoiceDoneEnum_MultipleInvalidResponsesThenResponseOption3_ReturnsOption3()
    {
        // Arrange
        MockUserInput.QueueLine("-3");
        MockUserInput.QueueLine("300");
        MockUserInput.QueueLine("test");
        MockUserInput.QueueLine("Option 1");
        MockUserInput.QueueLine("3");

        // Act
        var result = ConsolePrompt.GetChoiceDone<SampleEnumChoices>("Choose");

        // Assert
        Assert.AreEqual(SampleEnumChoices.Option3, result);
    }
}
