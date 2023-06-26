using Application2.IService;
using Azure.Storage.Blobs;
using Domain2.Model.Entity;

namespace Application2.Service;

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