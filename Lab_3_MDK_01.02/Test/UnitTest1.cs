using Xunit;
using static Program;

namespace Test
{
    [TestClass]
    public class UnitTest1 : PageTest
    {
        [TestMethod]
        [Theory]
        [InlineData("0", 0)]
        [InlineData("1", 1)]
        [InlineData("10", 2)]
        [InlineData("110", 6)]
        [InlineData("1111", 15)]
        [InlineData("101010", 42)]
        public void BinaryToDecimal_ValidInput_ReturnsCorrectDecimal(string binaryInput, int expectedDecimal)
        {
            // Act
            int result = Converter.BinaryToDecimal(binaryInput);

            // Assert
            Assert.Equal(expectedDecimal, result);
        }

        [Theory]
        [InlineData("2")]
        [InlineData("10a")]
        [InlineData("")]
        [InlineData(null)]
        public void BinaryToDecimal_InvalidInput_ThrowsFormatException(string binaryInput)
        {
            // Act & Assert
            var exception = Assert.Throws<FormatException>(() => Converter.BinaryToDecimal(binaryInput));
            Assert.Contains("Строка содержит недопустимые символы", exception.Message);
        }

        [Fact]
        public void BinaryToDecimal_EmptyString_ThrowsArgumentException()
        {
            // Arrange
            string binaryInput = "";

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => Converter.BinaryToDecimal(binaryInput));
            Assert.Equal("Строка не может быть пустой или null (Parameter 'binaryString')", exception.Message);
        }

        [Fact]
        public void BinaryToDecimal_NullString_ThrowsArgumentException()
        {
            // Arrange
            string binaryInput = null;

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => Converter.BinaryToDecimal(binaryInput));
            Assert.Equal("Строка не может быть пустой или null (Parameter 'binaryString')", exception.Message);
        }

        //public async Task HomepageHasPlaywrightInTitleAndGetStartedLinkLinkingtoTheIntroPage()
        //{
        //    await Page.GotoAsync("https://playwright.dev");

        //    // Expect a title "to contain" a substring.
        //    await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));

        //    // create a locator
        //    var getStarted = Page.Locator("text=Get Started");

        //    // Expect an attribute "to be strictly equal" to the value.
        //    await Expect(getStarted).ToHaveAttributeAsync("href", "/docs/intro");

        //    // Click the get started link.
        //    await getStarted.ClickAsync();

        //    // Expects the URL to contain intro.
        //    await Expect(Page).ToHaveURLAsync(new Regex(".*intro"));
        //}
    }
}
