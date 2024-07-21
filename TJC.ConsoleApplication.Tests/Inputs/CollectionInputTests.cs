namespace TJC.ConsoleApplication.Tests.Inputs;

[TestClass]
public class CollectionInputTests : InputTestsBaseClass
{
    [TestMethod]
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
        Assert.AreEqual(3, result.Count);
        Assert.AreEqual("Item1", result[0]);
        Assert.AreEqual("Item2", result[1]);
        Assert.AreEqual("Item3", result[2]);
    }

    [TestMethod]
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
        Assert.AreEqual(3, result.Count);
        Assert.AreEqual(1, result[0]);
        Assert.AreEqual(2, result[1]);
        Assert.AreEqual(3, result[2]);
    }

    [TestMethod]
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
        Assert.AreEqual(3, result.Count);
        Assert.AreEqual(1, result[0]);
        Assert.AreEqual(2, result[1]);
        Assert.AreEqual(3.5, result[2]);
    }
}