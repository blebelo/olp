using System.IO;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Web.Host.S3FileStorage
{
    public interface IFileStorageService
    {
        Task UploadAsync(string bucketName, string key, Stream stream);
        Task<Stream> DownloadAsync(string bucketName, string key);
        Task DeleteAsync(string bucketName, string key);
    }
}