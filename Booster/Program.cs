using System;
using System.Linq;
using Autofac;
using Booster.Platform.Api.TextAnalyzer;
using Booster.Platform.Api.TextGenerator;
using Booster.Platform.TextGenerator;
using Booster.Setup;

namespace Booster
{
    public class Program
    {
        private const int TextLength = 100;
        private static ITextAnalyzerService _textAnalyzerService;
        private static ITextGenerator _textGenerator;
        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                _textAnalyzerService = scope.Resolve<ITextAnalyzerService>();
                _textGenerator = scope.Resolve<ITextGenerator>();

                Console.WriteLine("Press enter to generate a text with 100 characters or press q to close.");
                var userChoice = Console.ReadLine();
                string inputString = String.Empty;
                while (userChoice != null && userChoice.ToLower() != "q")
                {
                    inputString += _textGenerator.GenerateText(TextLength);

                    DisplayOutput(inputString);

                    Console.WriteLine();
                    Console.WriteLine("Press enter to generate next 100 characters text or press q to close.");
                    userChoice = Console.ReadLine();
                }
            }
        }

        private static void DisplayOutput(string inputString)
        {
            // Add output logger

            //var textAnalyzerService = PlatformInstaller.CreateTextAnalyzer();

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
            Console.WriteLine("Total number of characters: " + _textAnalyzerService.GetTotalNumberOfCharacters(inputString));
            Console.WriteLine();
            Console.WriteLine("Total number of words: " + _textAnalyzerService.GetTotalNumberOfWords(inputString));
            Console.WriteLine();
            Console.WriteLine("Five largest words are: " + string.Join(", ", _textAnalyzerService.GetTopFiveLargestWords(inputString).ToArray()));
            Console.WriteLine();
            Console.WriteLine("Five smallest words are: " + string.Join(", ", _textAnalyzerService.GetTopFiveSmallestWords(inputString).ToArray()));
            Console.WriteLine();
            Console.WriteLine("Ten most frequently appearing words are: " + string.Join(", ", _textAnalyzerService.GetTopTenMostFrequentlyAppearingWords(inputString).ToArray()));
            Console.WriteLine();
            Console.WriteLine("Characters with Frequency");
            var charactersWithFrequency =
                _textAnalyzerService.GetCharactersWithFrequencyInDescendingOrder(inputString);

            foreach (var ch in charactersWithFrequency)
            {
                Console.WriteLine(ch.Key + "\t" + ch.Value);
            }
        }
    }
}
