namespace TJC.ConsoleApplication.Tests.Prompts;

public class ChoiceIndexPromptTests : ChoicePromptTestsBase
{
    [Fact]
    public void GetChoiceIndex_ResponseOption3_ReturnsIndex2()
    {
        // Arrange
        MockUserInput.QueueLine("3");

        // Act
        var result = ConsolePrompt.GetChoiceIndex("Choose", Choices);

        // Assert
        Assert.True(
            2 == result,
            "Since 'Option 3' was selected, the index for that option (2) should be returned"
        );
        Assert.Equal("Option 3", Choices[result]);
    }
}
