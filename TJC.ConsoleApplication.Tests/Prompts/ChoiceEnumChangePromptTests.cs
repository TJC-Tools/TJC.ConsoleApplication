namespace TJC.ConsoleApplication.Tests.Prompts;


public class ChoiceEnumChangePromptTests : ChoicePromptTestsBase
{
    [Fact]
    public void GetChoiceChange_InitialOption3_ResponseYOption5_ReturnsOption5()
    {
        // Arrange
        var result = SampleEnumChoices.Option3;
        MockUserInput.QueueKey(ConsoleKey.Y);
        MockUserInput.QueueLine("5");

        // Act
        result = ConsolePrompt.GetChoiceChange("sample", result);

        // Assert
        Assert.Equal(SampleEnumChoices.Option5, result);
    }

    [Fact]
    public void GetChoiceChange_InitialOption3_ResponseNOption5_ReturnsOption3()
    {
        // Arrange
        var result = SampleEnumChoices.Option3;
        MockUserInput.QueueKey(ConsoleKey.N);
        MockUserInput.QueueLine("5");

        // Act
        result = ConsolePrompt.GetChoiceChange("sample", result);

        // Assert
        Assert.Equal(SampleEnumChoices.Option3, result);
    }

    [Fact]
    public void GetChoiceChangeRef_InitialOption3_ResponseYOption5_ReturnsOption5()
    {
        // Arrange
        var result = SampleEnumChoices.Option3;
        MockUserInput.QueueKey(ConsoleKey.Y);
        MockUserInput.QueueLine("5");

        // Act
        ConsolePrompt.GetChoiceChange("sample", ref result);

        // Assert
        Assert.Equal(SampleEnumChoices.Option5, result);
    }

    [Fact]
    public void GetChoiceChangeRef_InitialOption3_ResponseNOption5_ReturnsOption3()
    {
        // Arrange
        var result = SampleEnumChoices.Option3;
        MockUserInput.QueueKey(ConsoleKey.N);
        MockUserInput.QueueLine("5");

        // Act
        ConsolePrompt.GetChoiceChange("sample", ref result);

        // Assert
        Assert.Equal(SampleEnumChoices.Option3, result);
    }
}
