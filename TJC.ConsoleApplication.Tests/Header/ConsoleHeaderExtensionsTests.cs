using TJC.ConsoleApplication.Header;
using TJC.ConsoleApplication.Settings;

namespace TJC.ConsoleApplication.Tests.Header;

[TestClass]
public class ConsoleHeaderExtensionsTests
{
    [TestMethod]
    public void ConsoleHeader()
    {
        // Arrange
        ConsoleSettings.Instance.VersionDigits = 4;

        // Act
        var result = ConsoleHeaderExtensions.CreateHeader().ToList();

        // Assert
        Assert.AreEqual(6, result.Count);
        Assert.AreEqual("###############################################", result[0]);
        Assert.AreEqual("###        Example Title - v1.2.3.4         ###", result[1]);
        Assert.AreEqual("###       Example Copyright (C) 2024        ###", result[2]);
        Assert.AreEqual("###                   ---                   ###", result[3]);
        Assert.AreEqual("###   Console Application Testing Project   ###", result[4]);
        Assert.AreEqual("###############################################", result[5]);
    }
}
