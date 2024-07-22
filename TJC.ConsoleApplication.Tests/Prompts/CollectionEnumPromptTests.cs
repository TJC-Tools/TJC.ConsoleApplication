namespace TJC.ConsoleApplication.Tests.Prompts;

[TestClass]
public class CollectionEnumPromptTests : ChoicePromptTestsBase
{
    [TestMethod]
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
        Assert.AreEqual(3, result.Count);
        Assert.AreEqual(SampleEnumChoices.Option2, result[0]);
        Assert.AreEqual(SampleEnumChoices.Option4, result[1]);
        Assert.AreEqual(SampleEnumChoices.Option1, result[2]);
    }

    [TestMethod]
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
        Assert.AreEqual(3, result.Count);
        Assert.AreEqual(SampleEnumChoices.Option2, result[0]);
        Assert.AreEqual(SampleEnumChoices.Option4, result[1]);
        Assert.AreEqual(SampleEnumChoices.Option1, result[2]);
    }
}