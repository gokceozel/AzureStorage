using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AzureStorage.Library.Services
{
    public class BlobStorage : IBlobStorage
    {
        private readonly BlobServiceClient _blobServiceClient;
        public BlobStorage()
        {
            _blobServiceClient = new BlobServiceClient(ConnectionStrings.AzureStorageConnectionString);
        }
        public string BlobUrl { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task DeleteAsync(string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> DowloadAsync(string fileName, EContainerName eContainerName)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetLogAsync(string text, string fileName)
        {
            throw new NotImplementedException();
        }

        public List<string> GetNames(EContainerName eContainerName)
        {
            throw new NotImplementedException();
        }

        public Task SetLogAsync(string text, string fileName)
        {
            throw new NotImplementedException();
        }

        public Task UploadAsync(Stream fileStream, string name, EContainerName eContainerName)
        {
            throw new NotImplementedException();
        }
    }
}
