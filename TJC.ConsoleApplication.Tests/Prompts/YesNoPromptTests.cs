namespace TJC.ConsoleApplication.Tests.Prompts;


public class YesNoPromptTests : InputTestsBaseClass
{
    [Fact]
    public void GetYesNo_ResponseY_ReturnsTrue()
    {
        // Arrange
        MockUserInput.QueueKey(ConsoleKey.Y);

        // Act
        var result = ConsolePrompt.GetYesNo("Do you want to continue?");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void GetYesNo_ResponseN_ReturnsFalse()
    {
        // Arrange
        MockUserInput.QueueKey(ConsoleKey.N);

        // Act
        var result = ConsolePrompt.GetYesNo("Do you want to continue?");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void GetYesNo_ResponseCharacters_ReturnsTrue()
    {
        // Arrange
        MockUserInput.QueueKey(ConsoleKey.Q);
        MockUserInput.QueueKey(ConsoleKey.W);
        MockUserInput.QueueKey(ConsoleKey.E);
        MockUserInput.QueueKey(ConsoleKey.R);
        MockUserInput.QueueKey(ConsoleKey.T);
        MockUserInput.QueueKey(ConsoleKey.Y);
        MockUserInput.QueueKey(ConsoleKey.N);

        // Act
        var result = ConsolePrompt.GetYesNo("Do you want to continue?");

        // Assert
        Assert.True(result, "The result should be true, since the first valid input is 'Y'");
    }
}
