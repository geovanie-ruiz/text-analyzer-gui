using NUnit.Framework;
using System.Text;

namespace TextAnalyzer.Tests
{
    public class StringExtensionsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void StringExtension_StripPunctuation_RemoveExclamation()
        {
            // Arrange
            string punctuationString = "test!";

            // Act
            string strippedString = punctuationString.StripPunctuation();

            // Assert
            Assert.AreEqual(strippedString, "test");
        }

        [Test]
        public void StringExtension_StripPunctuation_DashToDelimiter()
        {
            string dashString = "test-test-test";
            string delimitedString = dashString.StripPunctuation();
            Assert.AreEqual(delimitedString, "test|test|test");
        }

        [Test]
        public void StringExtension_StripPunctuation_StringMustNotChange()
        {
            string spacesString = "test test test";
            string strippedString = spacesString.StripPunctuation();
            Assert.AreEqual(strippedString, spacesString);
        }
    }
}
