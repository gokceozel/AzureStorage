using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AzureStorage.Library
{
    public  interface IBlobStorage
    {
        public string BlobUrl { get; }
        Task UploadAsync(Stream fileStream, string fileName, EContainerName eContainerName);
        Task<Stream> DowloadAsync(string fileName, EContainerName eContainerName);
        Task DeleteAsync(string blobName, EContainerName eContainerName);
        Task SetLogAsync(string text, string blobName);
        Task<List<string>> GetLogAsync(string fileName);
        List<string> GetNames(EContainerName eContainerName);
    }
    public enum EContainerName
    {
        pictures,
        pdf,
        logs
    }
}
