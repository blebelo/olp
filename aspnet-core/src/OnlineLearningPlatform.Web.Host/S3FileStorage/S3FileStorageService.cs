using Abp.Dependency;
using Amazon.S3;
using Amazon.S3.Model;
using System.IO;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Web.Host.S3FileStorage
{
    public class S3FileStorageService : IFileStorageService, ITransientDependency
    {
        private readonly IAmazonS3 _s3;

        public S3FileStorageService(IAmazonS3 s3)
        {
            _s3 = s3;
        }

        public async Task UploadAsync(string bucketName, string key, Stream stream)
        {
            var request = new PutObjectRequest
            {
                BucketName = bucketName,
                Key = key,
                InputStream = stream
            };

            await _s3.PutObjectAsync(request);
        }

        public async Task<Stream> DownloadAsync(string bucketName, string key)
        {
            var response = await _s3.GetObjectAsync(bucketName, key);
            return response.ResponseStream;
        }

        public async Task DeleteAsync(string bucketName, string key)
        {
            await _s3.DeleteObjectAsync(bucketName, key);
        }
    }
}