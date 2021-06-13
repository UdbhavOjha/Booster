using Autofac;
using Booster.Platform.Api.TextAnalyzer;
using Booster.Platform.Api.TextGenerator;
using Booster.Platform.TextAnalyzer;
using Booster.Platform.TextGenerator;

namespace Booster.Setup
{
    public class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<TextAnalyzerService>().As<ITextAnalyzerService>();
            builder.RegisterType<TextGenerator>().As<ITextGenerator>();
            return builder.Build();
        }
    }
}