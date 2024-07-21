﻿namespace TJC.ConsoleApplication.Tests.Inputs;

[TestClass]
public class StringInputTests
{
    [TestMethod]
    public void GetString_ResponseMatchesInput()
    {
        // Arrange
        var input = "My Test Input";
        ConsoleReaderMockHelpers.SetReadLineMock(input);

        // Act
        var result = ConsoleInput.GetString("Enter Input");

        // Assert
        Assert.AreEqual(input, result);
    }

    [TestMethod]
    public void GetStringChange_ChangeResponseNo_ReturnsOriginalValue()
    {
        // Arrange
        var current = "My Original Value";
        var input = "My New Value";
        ConsoleReaderMockHelpers.SetReadKeyMock(ConsoleKey.N);
        ConsoleReaderMockHelpers.SetReadLineMock(input);

        // Act
        var result = ConsoleInput.GetStringChange("Enter Input", current);

        // Assert
        Assert.AreEqual(current, result);
    }

    [TestMethod]
    public void GetStringChange_ChangeResponseYes_ReturnsNewValue()
    {
        // Arrange
        var current = "My Original Value";
        var input = "My New Value";
        ConsoleReaderMockHelpers.SetReadKeyMock(ConsoleKey.Y);
        ConsoleReaderMockHelpers.SetReadLineMock(input);

        // Act
        var result = ConsoleInput.GetStringChange("Enter Input", current);

        // Assert
        Assert.AreEqual(input, result);
    }

    [TestMethod]
    public void GetStringChangeRef_ChangeResponseNo_ReturnsOriginalValue()
    {
        // Arrange
        var original = "My Original Value";
        var result = original;
        var input = "My New Value";
        ConsoleReaderMockHelpers.SetReadKeyMock(ConsoleKey.N);
        ConsoleReaderMockHelpers.SetReadLineMock(input);

        // Act
        ConsoleInput.GetStringChange("Enter Input", ref result);

        // Assert
        Assert.AreEqual(original, result);
    }

    [TestMethod]
    public void GetStringChangeRef_ChangeResponseYes_ReturnsNewValue()
    {
        // Arrange
        var original = "My Original Value";
        var result = original;
        var input = "My New Value";
        ConsoleReaderMockHelpers.SetReadKeyMock(ConsoleKey.Y);
        ConsoleReaderMockHelpers.SetReadLineMock(input);

        // Act
        ConsoleInput.GetStringChange("Enter Input", ref result);

        // Assert
        Assert.AreEqual(input, result);
    }
}