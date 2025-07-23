using Abp.Application.Services;
using Abp.UI;
using Amazon.S3;
using OnlineLearningPlatform.Buckets;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class BucketAppService : ApplicationService, IBucketAppService
{
    private readonly IAmazonS3 _s3Client;

    public BucketAppService(IAmazonS3 s3Client)
    {
        _s3Client = s3Client;
    }

    public async Task CreateBucketAsync(string bucketName)
    {
        if (await Amazon.S3.Util.AmazonS3Util.DoesS3BucketExistV2Async(_s3Client, bucketName))
        {
            throw new UserFriendlyException($"Bucket '{bucketName}' already exists.");
        }

        await _s3Client.PutBucketAsync(bucketName);
    }

    public async Task<List<string>> GetAllBucketsAsync()
    {
        var buckets = await _s3Client.ListBucketsAsync();
        return buckets.Buckets.Select(b => b.BucketName).ToList();
    }

    public async Task DeleteBucketAsync(string bucketName)
    {
        if (!await Amazon.S3.Util.AmazonS3Util.DoesS3BucketExistV2Async(_s3Client, bucketName))
        {
            throw new UserFriendlyException($"Bucket '{bucketName}' does not exist.");
        }

        await _s3Client.DeleteBucketAsync(bucketName);
    }
}
