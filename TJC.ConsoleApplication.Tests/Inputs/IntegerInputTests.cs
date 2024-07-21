namespace TJC.ConsoleApplication.Tests.Inputs;

[TestClass]
public class IntegerInputTests : InputTestsBaseClass
{
    #region GetInt

    [TestMethod]
    public void GetInt_Response1_Returns1()
    {
        // Arrange
        MockUserInput.QueueLine("1");

        // Act
        var result = ConsolePrompt.GetInt("Enter Input");

        // Assert
        Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetInt_ResponseSeveralInvalidThenValid5_Returns5()
    {
        // Arrange
        MockUserInput.QueueLine("A");
        MockUserInput.QueueLine("B2");
        MockUserInput.QueueLine("3C");
        MockUserInput.QueueLine("1.3");
        MockUserInput.QueueLine("5");
        MockUserInput.QueueLine("7");

        // Act
        var result = ConsolePrompt.GetInt("Enter Input");

        // Assert
        Assert.AreEqual(5, result, "The result should be 5, since it is the first valid input");
    }

    #endregion

    #region GetIntRange

    [TestMethod]
    public void GetIntRange_ResponseOutOfRangeThenResponse5_Returns5()
    {
        // Arrange
        MockUserInput.QueueLine("0");
        MockUserInput.QueueLine("11");
        MockUserInput.QueueLine("5");

        // Act
        var result = ConsolePrompt.GetIntRange("Enter Input", 10, 1);

        // Assert
        Assert.AreEqual(5, result);
    }

    [TestMethod]
    public void GetIntRangeInclusive_ResponseSeveralInvalidThenValid5_Returns5()
    {
        // Arrange
        MockUserInput.QueueLine("33");
        MockUserInput.QueueLine("-3");
        MockUserInput.QueueLine("2.3");
        MockUserInput.QueueLine("5");
        MockUserInput.QueueLine("7");

        // Act
        var result = ConsolePrompt.GetIntRange("Enter Input", 10, 1);

        // Assert
        Assert.AreEqual(5, result, "The result should be 5, since it is the first valid input");
    }

    #endregion

    #region GetIntRange (Inclusive)

    [TestMethod]
    public void GetIntRangeInclusive_Response1Then5_Returns1()
    {
        // Arrange
        MockUserInput.QueueLine("1");
        MockUserInput.QueueLine("5");

        // Act
        var result = ConsolePrompt.GetIntRange("Enter Input", 10, 1, inclusive: true);

        // Assert
        Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetIntRangeInclusive_Response10Then5_Returns10()
    {
        // Arrange
        MockUserInput.QueueLine("10");
        MockUserInput.QueueLine("5");

        // Act
        var result = ConsolePrompt.GetIntRange("Enter Input", 10, 1, inclusive: true);

        // Assert
        Assert.AreEqual(10, result);
    }

    #endregion

    #region GetIntRange (Exclusive)

    [TestMethod]
    public void GetIntRangeExclusive_Response1Then5_Returns5()
    {
        // Arrange
        MockUserInput.QueueLine("1");
        MockUserInput.QueueLine("5");

        // Act
        var result = ConsolePrompt.GetIntRange("Enter Input", 10, 1, inclusive: false);

        // Assert
        Assert.AreEqual(5, result);
    }

    [TestMethod]
    public void GetIntRangeExclusive_Response10Then5_Returns5()
    {
        // Arrange
        MockUserInput.QueueLine("10");
        MockUserInput.QueueLine("5");

        // Act
        var result = ConsolePrompt.GetIntRange("Enter Input", 10, 1, inclusive: false);

        // Assert
        Assert.AreEqual(5, result);
    }

    #endregion
}