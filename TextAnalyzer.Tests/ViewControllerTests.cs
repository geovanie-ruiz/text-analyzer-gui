using NUnit.Framework;
using System.Text;

namespace TextAnalyzer.Tests
{
    public class ViewControllerTests
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
    }
}
