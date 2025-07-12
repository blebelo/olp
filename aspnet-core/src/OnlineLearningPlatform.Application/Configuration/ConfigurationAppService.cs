using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using OnlineLearningPlatform.Configuration.Dto;

namespace OnlineLearningPlatform.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : OnlineLearningPlatformAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
