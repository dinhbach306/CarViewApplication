using Application2.IService;
using Azure.Storage.Blobs;
using Domain2.Model.Entity;

namespace Application2.Service;

public class CarBrandService : ICarBrandService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly BlobServiceClient _blobServiceClient;
    public CarBrandService(IUnitOfWork unitOfWork, BlobServiceClient blobServiceClient)
    {
        _unitOfWork = unitOfWork;
        _blobServiceClient = blobServiceClient;
    }

    public async Task AddCarBrand(CarBrand model)
    {
        //get container instance
        var containerInstance = _blobServiceClient.GetBlobContainerClient("carpicture");
        // get file name from request and upload to azure blob storage
        var blobName =  $"{Guid.NewGuid()}{model.ImageLogo?.FileName}";
        // local file path
        var blobInstance = containerInstance.GetBlobClient(blobName);
        
        // upload file to azure blob storage
        await blobInstance.UploadAsync(model.ImageLogo?.OpenReadStream());
        
        // storageAccountUrl
        var storageAccountUrl = "https://carunistorage.blob.core.windows.net/carpicture";
        // get blob url
        var blobUrl = $"{storageAccountUrl}/{blobName}";
        
       
        //return url of image except https://
        model.ImageLogoUrl = blobUrl;
        model.Name = model.Name;
        await _unitOfWork.CarBrandRepository.Add(model);
        await _unitOfWork.SaveChangesAsync();
    }
}