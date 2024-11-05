namespace TJC.ConsoleApplication.Tests.Prompts;

[TestClass]
public class ChoiceStringPromptTests : ChoicePromptTestsBase
{
    [TestMethod]
    public void GetChoice_ResponseOption2_ReturnsOption2()
    {
        // Arrange
        MockUserInput.QueueLine("3");

        // Act
        var result = ConsolePrompt.GetChoice("Choose", Choices);

        // Assert
        Assert.AreEqual("Option 3", result);
    }
}
