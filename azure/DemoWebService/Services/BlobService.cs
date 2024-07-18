using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace DemoWebService.Services;

public class BlobService
{
    private readonly BlobServiceClient _blobServiceClient;

    public BlobService(BlobServiceClient blobServiceClient)
    {
        _blobServiceClient = blobServiceClient;
    }

    public async Task<string> GetBlobAsBase64StringAsync(string containerName, string blobName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        var blobClient = containerClient.GetBlobClient(blobName);

        if (await blobClient.ExistsAsync())
        {
            BlobDownloadInfo download = await blobClient.DownloadAsync();
            using (var memoryStream = new MemoryStream())
            {
                await download.Content.CopyToAsync(memoryStream);
                byte[] bytes = memoryStream.ToArray();
                return Convert.ToBase64String(bytes);
            }
        }
        return null;
    }
}