namespace Booster.Platform.Api.TextGenerator
{
    public interface ITextGenerator
    {
        /// <summary>
        /// Generate text strings with specified number of characters
        /// </summary>
        /// <param name="characterLength">Number of characters in the text</param>
        /// <returns>String</returns>
        string GenerateText(int characterLength);
    }
}