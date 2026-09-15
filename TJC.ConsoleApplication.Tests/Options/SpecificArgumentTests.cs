using TJC.ConsoleApplication.Arguments.Extensions;
using TJC.ConsoleApplication.Arguments.Options;
using TJC.ConsoleApplication.Arguments.Options.Specific;

namespace TJC.ConsoleApplication.Tests.Options;

[TestClass]
public class SpecificArgumentTests
{
    [TestMethod]
    public void LabelsArgument_ParsesTrimmedLabelsIgnoringCase()
    {
        var argument = new LabelsArgument();
        argument.Argument.ExitIfUsed = false;
        var arguments = new ConsoleArguments { argument };

        arguments.ParseAndValidate(["--labels=first, Second "], exitOnFailureToParse: false);

        CollectionAssert.AreEqual(new List<string> { "first", "Second" }, argument.Labels.ToList());
        Assert.IsTrue(argument.HasLabel("SECOND"));
    }

    [TestMethod]
    public void VerbosityArgument_AccumulatesNumericAndBooleanValues()
    {
        var argument = VerbosityArgument.Both;
        argument.Argument.ExitIfUsed = false;
        var arguments = new ConsoleArguments { argument };

        arguments.ParseAndValidate(["--verbose=2", "--verbose"], exitOnFailureToParse: false);

        Assert.AreEqual(3, argument.Verbosity);
    }

    [TestMethod]
    public void ConsoleArguments_AddsAndParsesCustomArgument()
    {
        var value = string.Empty;
        var arguments = new ConsoleArguments();
        arguments.Add("value=", input => value = input, "Value", "Value");

        arguments.ParseAndValidate(["--value=expected"], exitOnFailureToParse: false);

        Assert.AreEqual("expected", value);
    }
}