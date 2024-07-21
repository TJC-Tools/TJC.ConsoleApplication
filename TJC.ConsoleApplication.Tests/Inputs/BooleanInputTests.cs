namespace TJC.ConsoleApplication.Tests.Inputs;

[TestClass]
public class BooleanInputTests : InputTestsBaseClass
{
    [TestMethod]
    public void GetYesNo_ResponseY_ReturnsTrue()
    {
        // Arrange
        MockUserInput.QueueKey(ConsoleKey.Y);

        // Act
        var result = ConsolePrompt.GetYesNo("Do you want to continue?");

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void GetYesNo_ResponseN_ReturnsFalse()
    {
        // Arrange
        MockUserInput.QueueKey(ConsoleKey.N);

        // Act
        var result = ConsolePrompt.GetYesNo("Do you want to continue?");

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void GetYesNo_ResponseQWERTYN_ReturnsTrue()
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
        Assert.IsTrue(result, "The result should be true, since the first valid input is 'Y'");
    }
}