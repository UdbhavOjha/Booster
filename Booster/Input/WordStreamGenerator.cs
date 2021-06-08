using Booster.CodingTest.Library;
using Booster.Setup;

namespace Booster.Input
{
    internal static class WordStreamGenerator
    {
        private static readonly WordStream _wordStreamGenerator = PlatformInstaller.CreateWordStreamGenerator();
        private static byte[] _characterBytes;

        /// <summary>
        /// Generate text strings with specified number of characters
        /// </summary>
        /// <param name="characterLength">Number of characters in the text</param>
        /// <returns>String</returns>
        internal static string GenerateText(int characterLength)
        {
            _characterBytes = new byte[characterLength];
            _wordStreamGenerator.Read(_characterBytes, 0, characterLength);
            return System.Text.Encoding.UTF8.GetString(_characterBytes);
        }
    }
}