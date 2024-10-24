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
            Assert.AreEqual(4, result, $"4 Arguments are expected, because 3 were added, and {nameof(HelpArgument)} is always present.");
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

        [TestMethod]
        public void ConstructConsoleArguments_Changelog_HasParent()
        {
            // Arrange
            var argument = ChangelogArgument.Default;
            _ = new ConsoleArguments { argument };

            // Assert
            Assert.IsTrue(argument.Argument.HasParent);
        }

        [TestMethod]
        public void ConstructConsoleArguments_Copyright_HasParent()
        {
            // Arrange
            var argument = CopyrightArgument.Default;
            _ = new ConsoleArguments { argument };

            // Assert
            Assert.IsTrue(argument.Argument.HasParent);
        }

        [TestMethod]
        public void ConstructConsoleArguments_DryRun_HasParent()
        {
            // Arrange
            var argument = DryRunArgument.Default;
            _ = new ConsoleArguments { argument };

            // Assert
            Assert.IsTrue(argument.Argument.HasParent);
        }

        [TestMethod]
        public void ConstructConsoleArguments_Help_HasParent()
        {
            // Arrange
            var argument = HelpArgument.Default;
            _ = new ConsoleArguments { argument };

            // Assert
            Assert.IsTrue(argument.Argument.HasParent);
        }

        [TestMethod]
        public void ConstructConsoleArguments_Labels_HasParent()
        {
            // Arrange
            var argument = LabelsArgument.Default;
            _ = new ConsoleArguments { argument };

            // Assert
            Assert.IsTrue(argument.Argument.HasParent);
        }

        [TestMethod]
        public void ConstructConsoleArguments_License_HasParent()
        {
            // Arrange
            var argument = LicenseArgument.Default;
            _ = new ConsoleArguments { argument };

            // Assert
            Assert.IsTrue(argument.Argument.HasParent);
        }

        [TestMethod]
        public void ConstructConsoleArguments_Verbosity_HasParent()
        {
            // Arrange
            var argument = VerbosityArgument.Both;
            _ = new ConsoleArguments { argument };

            // Assert
            Assert.IsTrue(argument.Argument.HasParent);
        }

        [TestMethod]
        public void ConstructConsoleArguments_Version_HasParent()
        {
            // Arrange
            var argument = VersionArgument.Default;
            _ = new ConsoleArguments { argument };

            // Assert
            Assert.IsTrue(argument.Argument.HasParent);
        }
    }
}
