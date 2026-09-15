namespace TJC.ConsoleApplication.Tests.Prompts;


public class CollectionEnumPromptTests : ChoicePromptTestsBase
{
    [Fact]
    public void GetCollectionEnum_Response241_ReturnsCollectionOfSize3()
    {
        // Arrange
        MockUserInput.QueueLine("2");
        MockUserInput.QueueLine("4");
        MockUserInput.QueueLine("1");
        MockUserInput.QueueLine("0");

        // Act
        var result = ConsolePrompt.GetCollectionEnum<SampleEnumChoices>("Choose").ToList();

        // Assert
        Assert.Equal(3, result.Count);
        Assert.Equal(SampleEnumChoices.Option2, result[0]);
        Assert.Equal(SampleEnumChoices.Option4, result[1]);
        Assert.Equal(SampleEnumChoices.Option1, result[2]);
    }

    [Fact]
    public void GetCollectionEnum_InvalidResponsesAndResponse241_ReturnsCollectionOfSize3()
    {
        // Arrange
        MockUserInput.QueueLine("2");
        MockUserInput.QueueLine("Invalid1");
        MockUserInput.QueueLine("4");
        MockUserInput.QueueLine("2Invalid");
        MockUserInput.QueueLine("1");
        MockUserInput.QueueLine("0");

        // Act
        var result = ConsolePrompt.GetCollectionEnum<SampleEnumChoices>("Choose").ToList();

        // Assert
        Assert.Equal(3, result.Count);
        Assert.Equal(SampleEnumChoices.Option2, result[0]);
        Assert.Equal(SampleEnumChoices.Option4, result[1]);
        Assert.Equal(SampleEnumChoices.Option1, result[2]);
    }

    [Fact]
    public void GetCollectionEnum_WithIndividualPrompt_ReturnsSelectedItems()
    {
        MockUserInput.QueueLine("1");
        MockUserInput.QueueLine("0");

        var result = ConsolePrompt
            .GetCollectionEnum<SampleEnumChoices>("Choose", "Item")
            .ToList();

        Assert.Equal(new List<SampleEnumChoices> { SampleEnumChoices.Option1 }, result);
    }
}
