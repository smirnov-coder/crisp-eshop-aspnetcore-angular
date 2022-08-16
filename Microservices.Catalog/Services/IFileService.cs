namespace Microservices.Catalog.Services
{
    public interface IFileService
    {
        Task<string> SaveImageAsync(Stream imageStream, string fileExtension);
    }
}