using Abp.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Buckets
{
    public interface IBucketAppService : IApplicationService
    {
        Task CreateBucketAsync(string bucketName);
        Task<List<string>> GetAllBucketsAsync();
        Task DeleteBucketAsync(string bucketName);
    }
}
