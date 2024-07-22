namespace TJC.ConsoleApplication.Tests.Prompts;

[TestClass]
public class ChoiceEnumChangePromptTests : ChoicePromptTestsBase
{
    [TestMethod]
    public void GetChoiceChange_InitialOption3_ResponseYOption5_ReturnsOption5()
    {
        // Arrange
        var result = SampleEnumChoices.Option3;
        MockUserInput.QueueKey(ConsoleKey.Y);
        MockUserInput.QueueLine("5");

        // Act
        result = ConsolePrompt.GetChoiceChange("sample", result);

        // Assert
        Assert.AreEqual(SampleEnumChoices.Option5, result);
    }

    [TestMethod]
    public void GetChoiceChange_InitialOption3_ResponseNOption5_ReturnsOption3()
    {
        // Arrange
        var result = SampleEnumChoices.Option3;
        MockUserInput.QueueKey(ConsoleKey.N);
        MockUserInput.QueueLine("5");

        // Act
        result = ConsolePrompt.GetChoiceChange("sample", result);

        // Assert
        Assert.AreEqual(SampleEnumChoices.Option3, result);
    }

    [TestMethod]
    public void GetChoiceChangeRef_InitialOption3_ResponseYOption5_ReturnsOption5()
    {
        // Arrange
        var result = SampleEnumChoices.Option3;
        MockUserInput.QueueKey(ConsoleKey.Y);
        MockUserInput.QueueLine("5");

        // Act
        ConsolePrompt.GetChoiceChange("sample", ref result);

        // Assert
        Assert.AreEqual(SampleEnumChoices.Option5, result);
    }

    [TestMethod]
    public void GetChoiceChangeRef_InitialOption3_ResponseNOption5_ReturnsOption3()
    {
        // Arrange
        var result = SampleEnumChoices.Option3;
        MockUserInput.QueueKey(ConsoleKey.N);
        MockUserInput.QueueLine("5");

        // Act
        ConsolePrompt.GetChoiceChange("sample", ref result);

        // Assert
        Assert.AreEqual(SampleEnumChoices.Option3, result);
    }
}