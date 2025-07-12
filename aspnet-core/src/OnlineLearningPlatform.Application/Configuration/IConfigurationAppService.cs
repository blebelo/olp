using System.Threading.Tasks;
using OnlineLearningPlatform.Configuration.Dto;

namespace OnlineLearningPlatform.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
