using System;
using System.Linq;
using Booster.Input;
using Booster.Setup;

namespace Booster
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press enter to generate a text with 100 characters or press q to close.");
            var userChoice = Console.ReadLine();
            string inputString = String.Empty;
            while (userChoice != null && userChoice.ToLower() != "q")
            {
                inputString += WordStreamGenerator.GenerateText(100);

                DisplayOutput(inputString);

                Console.WriteLine();
                Console.WriteLine("Press enter to generate next 100 characters text or press q to close.");
                userChoice = Console.ReadLine();
            }
        }

        private static void DisplayOutput(string inputString)
        {
            // Add output logger

            var textAnalyzerService = PlatformInstaller.CreateTextAnalyzer();

            // Print string 
            Console.WriteLine("Text generated");
            Console.WriteLine(inputString);
            Console.WriteLine();
            Console.WriteLine("Press Enter Key to start analyzing the text");
            Console.ReadLine();
            // Text analysis begins 

            Console.WriteLine("----------------------");
            Console.WriteLine("Analysis");
            Console.WriteLine("----------------------");
            Console.WriteLine();
            Console.WriteLine("Total number of characters: " + textAnalyzerService.GetTotalNumberOfCharacters(inputString));
            Console.WriteLine();
            Console.WriteLine("Total number of words: " + textAnalyzerService.GetTotalNumberOfWords(inputString));
            Console.WriteLine();
            Console.WriteLine("Five largest words are: " + string.Join(", ", textAnalyzerService.GetTopFiveLargestWords(inputString).ToArray()));
            Console.WriteLine();
            Console.WriteLine("Five smallest words are: " + string.Join(", ", textAnalyzerService.GetTopFiveSmallestWords(inputString).ToArray()));
            Console.WriteLine();
            Console.WriteLine("Ten most frequently appearing words are: " + string.Join(", ", textAnalyzerService.GetTopTenMostFrequentlyAppearingWords(inputString).ToArray()));
            Console.WriteLine();
            Console.WriteLine("Characters with Frequency");
            var charactersWithFrequency =
                textAnalyzerService.GetCharactersWithFrequencyInDescendingOrder(inputString);

            foreach (var ch in charactersWithFrequency)
            {
                Console.WriteLine(ch.Key + "\t" + ch.Value);
            }
        }
    }
}
