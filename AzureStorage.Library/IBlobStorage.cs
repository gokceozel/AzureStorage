using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AzureStorage.Library
{
    public  interface IBlobStorage
    {
        public string BlobUrl { get; set; }
        Task UploadAsync(Stream fileStream, string name, EContainerName eContainerName);
        Task<Stream> DowloadAsync(string fileName, EContainerName eContainerName);
        Task DeleteAsync(string fileName);
        Task SetLogAsync(string text, string fileName);
        Task<List<string>> GetLogAsync(string text, string fileName);
        List<string> GetNames(EContainerName eContainerName);
    }
    public enum EContainerName
    {
        Picture,
        Pdf,
        Logs
    }
}
