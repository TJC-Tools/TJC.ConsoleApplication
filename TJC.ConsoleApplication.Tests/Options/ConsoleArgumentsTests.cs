using TJC.ConsoleApplication.Arguments.Options;
using TJC.ConsoleApplication.Arguments.Options.Specific;

namespace TJC.ConsoleApplication.Tests.Options
{
    [TestClass]
    public class ConsoleArgumentsTests
    {
        [TestMethod]
        public void ConstructConsoleArguments_ArgumentCountIs3()
        {
            // Arrange
            var arguments = new ConsoleArguments()
            {
                DryRunArgument.Default,
                ChangelogArgument.Default,
                LicenseArgument.Default
            };

            // Act
            var result = arguments.Count;

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void ConstructConsoleArguments_AllHaveParent()
        {
            // Arrange
            var arguments = new ConsoleArguments()
            {
                DryRunArgument.Default,
                ChangelogArgument.Default,
                LicenseArgument.Default
            };

            // Act
            var result = arguments.All(x => x.HasParent);

            // Assert
            Assert.IsTrue(result);
        }
    }
}