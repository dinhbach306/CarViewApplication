using Application.IService;
using Azure.Storage.Blobs;
using Domain.Model.Entity;

namespace Application.Service;

public class FileService : IFileService
{
    private readonly BlobServiceClient _blobServiceClient;
    
    public FileService(BlobServiceClient blobServiceClient)
    {
        _blobServiceClient = blobServiceClient;
    }
    
    public async Task<Stream> Get(string name)
    {
        var containerInstance = _blobServiceClient.GetBlobContainerClient("carpicture");
        
        var blobInstance = containerInstance.GetBlobClient(name);

        var downloadContent = await blobInstance.DownloadAsync();
        return downloadContent.Value.Content;
    }
}