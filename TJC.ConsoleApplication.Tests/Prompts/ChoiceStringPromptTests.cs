namespace TJC.ConsoleApplication.Tests.Prompts;


public class ChoiceStringPromptTests : ChoicePromptTestsBase
{
    [Fact]
    public void GetChoice_ResponseOption2_ReturnsOption2()
    {
        // Arrange
        MockUserInput.QueueLine("3");

        // Act
        var result = ConsolePrompt.GetChoice("Choose", Choices);

        // Assert
        Assert.Equal("Option 3", result);
    }
}
