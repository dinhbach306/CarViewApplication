using Application.IService;
using Azure.Storage.Blobs;
using Domain.Model.Entity;

namespace Application.Service;

public class CarBranchService : ICarBranchService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly BlobServiceClient _blobServiceClient;
    public CarBranchService(IUnitOfWork unitOfWork, BlobServiceClient blobServiceClient)
    {
        _unitOfWork = unitOfWork;
        _blobServiceClient = blobServiceClient;
    }

    public async Task AddCarBranch(CarBranch model)
    {
        //upload image to azure blob storage
        var containerInstance = _blobServiceClient.GetBlobContainerClient("carpicture");
        // get file name from request and upload to azure blob storage
        var blobName = model.ImageLogo?.FileName;
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
        await _unitOfWork.CarBranchRepository.Add(model);
        await _unitOfWork.SaveChangesAsync();
    }
}