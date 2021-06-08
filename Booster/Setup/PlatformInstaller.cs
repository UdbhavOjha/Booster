using Booster.CodingTest.Library;
using Booster.Platform.Api.TextAnalyzer;
using Booster.Platform.TextAnalyzer;

namespace Booster.Setup
{
    /// <summary>
    /// This set up should ideally be injected using a DI framework - Castle Windsor or Autofac.
    /// Also remove the direct access of the UI side i.e. Console in this case to Booster.Platform project.
    /// Booster.Platform should only be accessible by Booster.Platform.Api - in this way we can decouple
    /// the UI from the back-end.
    /// </summary>
    public static class PlatformInstaller
    {
        public static ITextAnalyzerService CreateTextAnalyzer()
        {
            return new TextAnalyzerService();
        }

        public static WordStream CreateWordStreamGenerator()
        {
            return new WordStream();
        }
    }
}