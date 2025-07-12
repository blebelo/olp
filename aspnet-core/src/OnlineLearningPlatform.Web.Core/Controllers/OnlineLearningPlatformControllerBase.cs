using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace OnlineLearningPlatform.Controllers
{
    public abstract class OnlineLearningPlatformControllerBase: AbpController
    {
        protected OnlineLearningPlatformControllerBase()
        {
            LocalizationSourceName = OnlineLearningPlatformConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
