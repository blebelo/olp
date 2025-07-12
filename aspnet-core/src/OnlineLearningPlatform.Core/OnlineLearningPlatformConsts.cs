using OnlineLearningPlatform.Debugging;

namespace OnlineLearningPlatform
{
    public class OnlineLearningPlatformConsts
    {
        public const string LocalizationSourceName = "OnlineLearningPlatform";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "c2e85e2839144175af626b6ae078eada";
    }
}
