using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace OnlineLearningPlatform.Localization
{
    public static class OnlineLearningPlatformLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(OnlineLearningPlatformConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(OnlineLearningPlatformLocalizationConfigurer).GetAssembly(),
                        "OnlineLearningPlatform.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
