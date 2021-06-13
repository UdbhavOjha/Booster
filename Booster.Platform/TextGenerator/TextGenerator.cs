using Booster.CodingTest.Library;
using Booster.Platform.Api.TextGenerator;

namespace Booster.Platform.TextGenerator
{
    public class TextGenerator : ITextGenerator
    {
        private static byte[] _characterBytes;

        public string GenerateText(int characterLength)
        {
            var wordStreamGenerator = new WordStream();
            _characterBytes = new byte[characterLength];
            wordStreamGenerator.Read(_characterBytes, 0, characterLength);
            return System.Text.Encoding.UTF8.GetString(_characterBytes);
        }
    }
}