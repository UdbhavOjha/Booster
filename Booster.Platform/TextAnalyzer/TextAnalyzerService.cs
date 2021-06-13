using System;
using System.Collections.Generic;
using System.Linq;
using Booster.Platform.Api.TextAnalyzer;

namespace Booster.Platform.TextAnalyzer
{
    public class TextAnalyzerService : ITextAnalyzerService
    {
        // Add validation where necessary
        public int GetTotalNumberOfCharacters(string inputString)
        {
            return inputString.Length;
        }

        public int GetTotalNumberOfWords(string inputString)
        {
            return inputString.Replace(".", string.Empty).Split(' ').Length;
        }

        public IEnumerable<string> GetTopFiveLargestWords(string inputString)
        {
            return inputString.Replace(".", string.Empty).Split(' ').Distinct(StringComparer.CurrentCultureIgnoreCase).OrderByDescending(x => x.Length).Take(5);
        }

        public IEnumerable<string> GetTopFiveSmallestWords(string inputString)
        {
            return inputString.Replace(".", string.Empty).Split(' ').Where(x => x.Length > 0).Distinct(StringComparer.CurrentCultureIgnoreCase).OrderBy(x => x.Length).Take(5);
        }

        public IEnumerable<string> GetTopTenMostFrequentlyAppearingWords(string inputString)
        {
            var wordsWithFrequency = new Dictionary<string, int>();
            var separatedWordsInInputString = inputString.Replace(".", string.Empty).Split(' ');
            foreach (var word in separatedWordsInInputString)
            {
                if (!wordsWithFrequency.ContainsKey(word))
                {
                    var frequency = separatedWordsInInputString.Count(x => x.ToLower() == word.ToLower());
                    wordsWithFrequency.Add(word, frequency);
                }
            }

            return wordsWithFrequency.OrderByDescending(x => x.Value).Take(10).Select(x => x.Key);
        }

        public Dictionary<char, int> GetCharactersWithFrequencyInDescendingOrder(string inputString)
        {
            var charactersWithFrequency = new Dictionary<char, int>();
            var separatedCharactersInInputString = inputString.ToCharArray().Where(x => x != ' ' && x != '.').ToList();
            foreach (var ch in separatedCharactersInInputString)
            {
                if (!charactersWithFrequency.ContainsKey(ch))
                {
                    charactersWithFrequency.Add(ch, separatedCharactersInInputString.Count(x => x == ch));
                }
            }

            return charactersWithFrequency.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}