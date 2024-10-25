using TJC.ConsoleApplication.Arguments.Extensions;
using TJC.ConsoleApplication.Arguments.Options;
using TJC.ConsoleApplication.Arguments.Options.Specific;

namespace TJC.ConsoleApplication.Tests.Options;

[TestClass]
public class EnumArgumentTests
{
    [TestMethod]
    public void ParseEnumArgument_ReturnsOption2()
    {
        // Arrange
        var argument = new EnumArgument<SampleEnumChoices>();
        var arguments = new ConsoleArguments { argument };

        // Act
        arguments.ParseAndValidate(["--option2"], exitOnFailureToParse: false);

        // Assert
        Assert.AreEqual(SampleEnumChoices.Option2, argument.SelectedEnumValue);
    }

    [TestMethod]
    public void ParseEnumArgument_ReturnsOption3()
    {
        // Arrange
        var argument = new EnumArgument<SampleEnumChoices>();
        var arguments = new ConsoleArguments { argument };

        // Act
        arguments.ParseAndValidate(["--option3"], exitOnFailureToParse: false);

        // Assert
        Assert.AreEqual(SampleEnumChoices.Option3, argument.SelectedEnumValue);
    }
}