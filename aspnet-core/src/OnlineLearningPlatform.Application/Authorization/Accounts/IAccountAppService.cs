using System.Threading.Tasks;
using Abp.Application.Services;
using OnlineLearningPlatform.Authorization.Accounts.Dto;

namespace OnlineLearningPlatform.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
