namespace TJC.ConsoleApplication.Tests.Prompts;

public class CollectionPromptTests : InputTestsBaseClass
{
    [Fact]
    public void GetCollection_ThreeResponses_ReturnsListOfThree()
    {
        // Arrange
        MockUserInput.QueueLine("Item1");
        MockUserInput.QueueLine("Item2");
        MockUserInput.QueueLine("Item3");
        MockUserInput.QueueLine(string.Empty);

        // Act
        var result = ConsolePrompt.GetCollection("Enter Collection", "item").ToList();

        // Assert
        Assert.Equal(3, result.Count);
        Assert.Equal("Item1", result[0]);
        Assert.Equal("Item2", result[1]);
        Assert.Equal("Item3", result[2]);
    }

    [Fact]
    public void GetCollectionInt_ThreeValidResponses_ReturnsListOfThree()
    {
        // Arrange
        MockUserInput.QueueLine("1");
        MockUserInput.QueueLine("2");
        MockUserInput.QueueLine("Invalid1");
        MockUserInput.QueueLine("3");
        MockUserInput.QueueLine("Invalid2");
        MockUserInput.QueueLine("3.5");
        MockUserInput.QueueLine(string.Empty);

        // Act
        var result = ConsolePrompt.GetCollectionInt("Enter Collection").ToList();

        // Assert
        Assert.Equal(3, result.Count);
        Assert.Equal(1, result[0]);
        Assert.Equal(2, result[1]);
        Assert.Equal(3, result[2]);
    }

    [Fact]
    public void GetCollectionDouble_ThreeValidResponses_ReturnsListOfThree()
    {
        // Arrange
        MockUserInput.QueueLine("1");
        MockUserInput.QueueLine("2");
        MockUserInput.QueueLine("Invalid1");
        MockUserInput.QueueLine("Invalid2");
        MockUserInput.QueueLine("3.5");
        MockUserInput.QueueLine(string.Empty);

        // Act
        var result = ConsolePrompt.GetCollectionDouble("Enter Collection").ToList();

        // Assert
        Assert.Equal(3, result.Count);
        Assert.Equal(1, result[0]);
        Assert.Equal(2, result[1]);
        Assert.Equal(3.5, result[2]);
    }
}
