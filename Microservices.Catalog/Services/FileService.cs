using Azure.Storage.Blobs;
using Microservices.Catalog.General;

namespace Microservices.Catalog.Services
{
    public class FileService : IFileService
    {
        private readonly IConfiguration _configuration;

        public FileService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> SaveImageAsync(Stream imageStream, string fileExtension)
        {
            var connectionString = _configuration.GetConnectionString(Constants.CloudStorageConfigurationKey);
            var client = new BlobContainerClient(connectionString, Constants.BlobContainerName);
            var blobName = $"images/{Guid.NewGuid()}{fileExtension}";
            await client.UploadBlobAsync(blobName, imageStream);
            
            return $"{_configuration[$"Endpoints:{Constants.CloudStorageConfigurationKey}"]}/{Constants.BlobContainerName}/{blobName}";
        }
    }
}
