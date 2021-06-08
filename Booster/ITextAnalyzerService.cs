using System.Collections.Generic;

namespace Booster
{
    public interface ITextAnalyzerService
    {
        // define interface methods

        int GetTotalNumberOfCharacters(string inputString);

        int GetTotalNumberOfWords(string inputString);

        IEnumerable<string> GetTopFiveLargestWords(string inputString);

        IEnumerable<string> GetTopFiveSmallestWords(string inputString);

        IEnumerable<string> GetTopTenMostFrequentlyAppearingWords(string inputString);

        Dictionary<char, int> GetCharactersWithFrequencyInDescendingOrder(string inputString);
    }
}