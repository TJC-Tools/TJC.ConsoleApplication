namespace TJC.ConsoleApplication.Tests.Inputs;

[TestClass]
public class IntegerInputTests
{
    [TestMethod]
    public void GetInt_Response1()
    {
        // Arrange
        var input = "1";
        ConsoleReaderMockHelpers.SetReadLineMock(input);

        // Act
        var result = ConsoleInput.GetInt("Enter Input");

        // Assert
        Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetInt_Response5()
    {
        // Arrange
        var input = "5";
        ConsoleReaderMockHelpers.SetReadLineMock(input);

        // Act
        var result = ConsoleInput.GetIntRange("Enter Input", 10, 1);

        // Assert
        Assert.AreEqual(5, result);
    }
}