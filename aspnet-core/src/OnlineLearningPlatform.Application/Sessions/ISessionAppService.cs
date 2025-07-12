using System.Threading.Tasks;
using Abp.Application.Services;
using OnlineLearningPlatform.Sessions.Dto;

namespace OnlineLearningPlatform.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
