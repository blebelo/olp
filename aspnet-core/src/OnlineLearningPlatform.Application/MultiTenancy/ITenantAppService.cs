using Abp.Application.Services;
using OnlineLearningPlatform.MultiTenancy.Dto;

namespace OnlineLearningPlatform.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

