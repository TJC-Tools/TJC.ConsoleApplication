using TJC.ConsoleApplication.Header;
using TJC.ConsoleApplication.Settings;

namespace TJC.ConsoleApplication.Tests.Header;


public class ConsoleHeaderExtensionsTests
{
    [Fact]
    public void ConsoleHeader()
    {
        // Arrange
        ConsoleSettings.Instance.VersionDigits = 4;

        // Act
        var result = ConsoleHeaderExtensions.CreateHeader().ToList();

        // Assert
        Assert.Equal(6, result.Count);
        Assert.Equal("###############################################", result[0]);
        Assert.Equal("###        Example Title - v1.2.3.4         ###", result[1]);
        Assert.Equal("###       Example Copyright (C) 2024        ###", result[2]);
        Assert.Equal("###                   ---                   ###", result[3]);
        Assert.Equal("###   Console Application Testing Project   ###", result[4]);
        Assert.Equal("###############################################", result[5]);
    }
}
