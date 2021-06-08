using System.Collections.Generic;
using Booster.Platform.TextAnalyzer;
using Xunit;

namespace Booster.Platform.Tests.TextAnalyzer
{
    public class TextAnalyzerServiceTests
    {
        [Theory]
        [InlineData("abc", 3)]
        [InlineData("abcdefghij", 10)]
        [InlineData("", 0)]
        public void GetTotalNumberOfCharacters_NumberOfCharactersShouldCalculate(string text, int expected)
        {
            //arrange
            var textAnalyzerService = new TextAnalyzerService();

            //act
            int actual = textAnalyzerService.GetTotalNumberOfCharacters(text);

            //assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Unit testing is great! Keep it going.", 7)]
        [InlineData("abcdefghij", 1)]
        public void GetTotalNumberOfWords_NumberOfWordsShouldCalculate(string text, int expected)
        {
            //arrange
            var textAnalyzerService = new TextAnalyzerService();

            //act
            int actual = textAnalyzerService.GetTotalNumberOfWords(text);

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetTopFiveLargestWords_FiveLargestWordsShouldBeReturned()
        {
            //arrange
            var inputText = "a ab abc abcd abcde abcdef abcdefg abcdefgh abcdefghi abcdefghij";
            var expected = new List<string>()
            {
                "abcdefghij",
                "abcdefghi",
                "abcdefgh",
                "abcdefg",
                "abcdef"    
            };
            var textAnalyzerService = new TextAnalyzerService();

            //act
            var actual = textAnalyzerService.GetTopFiveLargestWords(inputText);

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetTopFiveSmallestWords_FiveSmallestWordsShouldBeReturned()
        {
            //arrange
            var inputText = "a ab abc abcd abcde abcdef abcdefg abcdefgh abcdefghi abcdefghij";
            var expected = new List<string>()
            {
                "a",
                "ab",
                "abc",
                "abcd",
                "abcde"
            };
            var textAnalyzerService = new TextAnalyzerService();

            //act
            var actual = textAnalyzerService.GetTopFiveSmallestWords(inputText);

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetTopTenMostFrequentlyAppearingWords_TopTenHighestFrequencyWordsShouldBeReturned()
        {
            //arrange
            var inputText = "a a a ab ab ab ab ab c c c c dd dd eee eee f g h i j k l m n op qrst uvw xyz";
            var expected = new List<string>()
            {
                "ab",
                "c",
                "a",
                "dd",
                "eee",
                "f", 
                "g",
                "h",
                "i",
                "j"
            };
            var textAnalyzerService = new TextAnalyzerService();

            //act
            var actual = textAnalyzerService.GetTopTenMostFrequentlyAppearingWords(inputText);

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetCharactersWithFrequencyInDescendingOrder_HighestToLowestCharacterFrequencyShouldBeReturned()
        {
            //arrange
            var inputText = "a bb ccc dddd eeeee";
            var expected = new Dictionary<char, int>()
            {
                {'e', 5},
                {'d', 4},
                {'c', 3},
                {'b', 2},
                {'a', 1}
            };
            var textAnalyzerService = new TextAnalyzerService();

            //act
            var actual = textAnalyzerService.GetCharactersWithFrequencyInDescendingOrder(inputText);

            //assert
            Assert.Equal(expected, actual);
        }
    }
}