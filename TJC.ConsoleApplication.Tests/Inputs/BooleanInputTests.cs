namespace TJC.ConsoleApplication.Tests.Inputs
{
    [TestClass]
    public class BooleanInputTests
    {
        [TestMethod]
        public void GetYesNo_ResponseY_ReturnsTrue()
        {
            // Arrange
            ConsoleReaderMockHelpers.SetReadKeyMock(ConsoleKey.Y);

            // Act
            var result = ConsoleInput.GetYesNo("Do you want to continue?");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetYesNo_ResponseN_ReturnsFalse()
        {
            // Arrange
            ConsoleReaderMockHelpers.SetReadKeyMock(ConsoleKey.N);

            // Act
            var result = ConsoleInput.GetYesNo("Do you want to continue?");

            // Assert
            Assert.IsFalse(result);
        }
    }
}