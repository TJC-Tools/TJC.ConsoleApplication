using System.Diagnostics;
using System.Reflection;
using TJC.ConsoleApplication.Helpers;
using TJC.ConsoleApplication.Settings;

namespace TJC.ConsoleApplication.Tests.Helpers;

public class VersionHelperTests
{
    private static readonly Assembly TestAssembly = typeof(VersionHelperTests).Assembly;

    [Fact]
    public void DefaultVersionTypeIsVersion()
    {
        Assert.Equal(VersionType.Version, ConsoleSettings.Default.VersionType);
    }

    [Theory]
    [InlineData(VersionType.Version, "1.2.3.4")]
    [InlineData(VersionType.InformationalVersion, "5.6.7-test")]
    [InlineData(VersionType.FileVersion, "4.3.2.1")]
    [InlineData(VersionType.ProductVersion, "5.6.7-test")]
    public void GetVersionUsesConfiguredVersionType(VersionType versionType, string expected)
    {
        try
        {
            ConsoleSettings.Instance.VersionType = versionType;

            Assert.Equal(expected, TestAssembly.GetVersion());
        }
        finally
        {
            ConsoleSettings.Instance.VersionType = VersionType.Version;
        }
    }
}
