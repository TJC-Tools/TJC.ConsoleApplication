namespace TJC.ConsoleApplication.Tests.Prompts;


public class StringChoicePromptTests : InputTestsBaseClass
{
    [Fact]
    public void GetStringChange_ChangeResponseNo_ReturnsOriginalValue()
    {
        // Arrange
        var current = "My Original Value";
        var input = "My New Value";
        MockUserInput.QueueKey(ConsoleKey.N);
        MockUserInput.QueueLine(input);

        // Act
        var result = ConsolePrompt.GetStringChange("Enter Input", current);

        // Assert
        Assert.Equal(current, result);
    }

    [Fact]
    public void GetStringChange_ChangeResponseYes_ReturnsNewValue()
    {
        // Arrange
        var current = "My Original Value";
        var input = "My New Value";
        MockUserInput.QueueKey(ConsoleKey.Y);
        MockUserInput.QueueLine(input);

        // Act
        var result = ConsolePrompt.GetStringChange("Enter Input", current);

        // Assert
        Assert.Equal(input, result);
    }

    [Fact]
    public void GetStringChangeRef_ChangeResponseNo_ReturnsOriginalValue()
    {
        // Arrange
        var original = "My Original Value";
        var result = original;
        var input = "My New Value";
        MockUserInput.QueueKey(ConsoleKey.N);
        MockUserInput.QueueLine(input);

        // Act
        ConsolePrompt.GetStringChange("Enter Input", ref result);

        // Assert
        Assert.Equal(original, result);
    }

    [Fact]
    public void GetStringChangeRef_ChangeResponseYes_ReturnsNewValue()
    {
        // Arrange
        var original = "My Original Value";
        var result = original;
        var input = "My New Value";
        MockUserInput.QueueKey(ConsoleKey.Y);
        MockUserInput.QueueLine(input);

        // Act
        ConsolePrompt.GetStringChange("Enter Input", ref result);

        // Assert
        Assert.Equal(input, result);
    }
}
