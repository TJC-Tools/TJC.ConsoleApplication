namespace TJC.ConsoleApplication.Tests.Prompts;

[TestClass]
public class ChoicePromptTests : InputTestsBaseClass
{
    private readonly List<string> _choices = ["Option 1", "Option 2", "Option 3", "Option 4", "Option 5"];

    [TestMethod]
    public void GetChoiceIndex_ResponseOption3_ReturnsIndex2()
    {
        // Arrange
        MockUserInput.QueueLine("3");

        // Act
        var result = ConsolePrompt.GetChoiceIndex("Choose", _choices);

        // Assert
        Assert.AreEqual(2, result, "Since 'Option 3' was selected, the index for that option (2) should be returned");
        Assert.AreEqual("Option 3", _choices[result]);
    }

    [TestMethod]
    public void GetChoice_ResponseOption2_ReturnsOption2()
    {
        // Arrange
        MockUserInput.QueueLine("3");

        // Act
        var result = ConsolePrompt.GetChoice("Choose", _choices);

        // Assert
        Assert.AreEqual("Option 3", result);
    }
}