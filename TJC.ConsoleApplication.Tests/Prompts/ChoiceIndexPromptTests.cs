namespace TJC.ConsoleApplication.Tests.Prompts;

[TestClass]
public class ChoiceIndexPromptTests : ChoicePromptTestsBase
{
    [TestMethod]
    public void GetChoiceIndex_ResponseOption3_ReturnsIndex2()
    {
        // Arrange
        MockUserInput.QueueLine("3");

        // Act
        var result = ConsolePrompt.GetChoiceIndex("Choose", Choices);

        // Assert
        Assert.AreEqual(
            2,
            result,
            "Since 'Option 3' was selected, the index for that option (2) should be returned"
        );
        Assert.AreEqual("Option 3", Choices[result]);
    }
}
