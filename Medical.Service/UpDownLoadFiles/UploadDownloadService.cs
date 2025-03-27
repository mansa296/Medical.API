using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Medical.Common.Constants;
using Medical.Model.Options.Security;

namespace Medical.Service.UpDownLoadFiles
{
    public class UploadDownloadService : IUploadDownloadService
    {
        private readonly IConfiguration _configuration;
        private readonly AzureStorage _azureStorage;
        private readonly ILogger<UploadDownloadService> _logger;
      
        /// <param name="configuration">The configuration</param>
        public UploadDownloadService(IConfiguration configuration, 
            IOptions<AzureStorage> azureStorage,
            ILogger<UploadDownloadService> logger
        )
        {
            _configuration = configuration;
            _azureStorage = azureStorage.Value;
            _logger = logger;
        }
        public async Task<string> UploadAsync(IFormFile files, string fileName, string CatogeryType,string ApplicationId, Guid BusinessUnitId = default(Guid))
        {
            try
            {
                string blobConnectionString = _azureStorage.BlobConnectionString;// _configuration["AzureStorage:BlobConnectionString"];
                string blobContainerName = _azureStorage.BlobContainerName;// _configuration["AzureStorage:BlobContainerName"];
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobConnectionString);
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(blobContainerName);
                cloudBlobContainer.CreateIfNotExistsAsync();

                if (CatogeryType == "Summary" && ApplicationId == "")
                {
                    CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference($"{BusinessUnitId}/{CatogeryType}/{fileName}");
                    using (var data = files.OpenReadStream())
                    {
                        await cloudBlockBlob.UploadFromStreamAsync(data);
                    }

                    return cloudBlockBlob.Uri.ToString();
                }
                else
                {
                    CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference($"{BusinessUnitId}/{CatogeryType}/{ApplicationId}/{fileName}");
                    using (var data = files.OpenReadStream())
                    {
                        await cloudBlockBlob.UploadFromStreamAsync(data);
                    }

                    return cloudBlockBlob.Uri.ToString();
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return "";
        }
        public async Task<string> UploadbytesAsync(byte[] bytes, string fileName, string CatogeryType, string ApplicationId, Guid BusinessUnitId = default(Guid))
        {
            try
            {
                string blobConnectionString = _azureStorage.BlobConnectionString;// _configuration["AzureStorage:BlobConnectionString"];
                string blobContainerName = _azureStorage.BlobContainerName;// _configuration["AzureStorage:BlobContainerName"];

                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobConnectionString);
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(blobContainerName);
                cloudBlobContainer.CreateIfNotExistsAsync();
                //cloudBlobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Container });
                if (CatogeryType == "Summary" && ApplicationId == "")
                {
                    CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference($"{BusinessUnitId}/{CatogeryType}/{fileName}");
                    using (Stream stream = new MemoryStream(bytes))
                    {
                        await cloudBlockBlob.UploadFromStreamAsync(stream);
                    }

                    return cloudBlockBlob.Uri.ToString();
                }
                else
                {
                    CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference($"{BusinessUnitId}/{CatogeryType}/{ApplicationId}/{fileName}");
                    using (Stream stream = new MemoryStream(bytes))
                    {
                        await cloudBlockBlob.UploadFromStreamAsync(stream);
                    }

                    return cloudBlockBlob.Uri.ToString();
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                ex.ToString();
            }
            return "";
        }
        public async Task DeleteAsync(string fileName)
        {
            try
            {
                string blobConnectionString = _azureStorage.BlobConnectionString;// _configuration["AzureStorage:BlobConnectionString"];
                string blobContainerName = _azureStorage.BlobContainerName;// _configuration["AzureStorage:BlobContainerName"];
                
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobConnectionString);
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(blobContainerName);
                var blob = cloudBlobContainer.GetBlobReference($"{fileName}");
                await blob.DeleteIfExistsAsync();

            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        public async Task<string> DownloadAsync(string fileName, string CatogeryType, string ApplicationId, Guid BusinessUnitId = default(Guid))
        {
            try
            {
                string sasUrl = string.Empty;
                CloudBlockBlob blockBlob;
               
                    string blobConnectionString = _azureStorage.BlobConnectionString;// _configuration["AzureStorage:BlobConnectionString"];
                    string blobContainerName = _azureStorage.BlobContainerName;// _configuration["AzureStorage:BlobContainerName"];
                    
                    CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobConnectionString);
                    CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                    CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(blobContainerName);
                    if (CatogeryType == "Summary" && ApplicationId == "")
                    {
                        blockBlob = cloudBlobContainer.GetBlockBlobReference($"{BusinessUnitId}/{CatogeryType}/{fileName}");
                    }
                    else
                    {
                        blockBlob = cloudBlobContainer.GetBlockBlobReference($"{BusinessUnitId}/{CatogeryType}/{ApplicationId}/{fileName}");
                    }
                    
                    SharedAccessBlobPolicy sasPolicy = new SharedAccessBlobPolicy()
                    {
                        SharedAccessStartTime = DateTime.UtcNow.AddMinutes(-5),
                        SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(_azureStorage.SharedAccessExpiryTime),
                        Permissions = SharedAccessBlobPermissions.Read,
                    };
                   string sasToken = blockBlob.GetSharedAccessSignature(sasPolicy);
                   sasUrl = string.Format("{0}{1}", blockBlob.Uri, sasToken);
                   return sasUrl;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                ex.ToString();
            }
            return string.Empty;
        }
        public async Task<byte[]> DownloadAsStreamAsync(string fileName, string CatogeryType, string ApplicationId, Guid BusinessUnitId = default(Guid))
        {
            try
            {
                CloudBlockBlob blockBlob;
                await using (MemoryStream memoryStream = new MemoryStream())
                {
                    string blobConnectionString = _azureStorage.BlobConnectionString;// _configuration["AzureStorage:BlobConnectionString"];
                    string blobContainerName = _azureStorage.BlobContainerName;// _configuration["AzureStorage:BlobContainerName"];

                    CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobConnectionString);
                    CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                    CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(blobContainerName);
                    if(CatogeryType == "Summary" && ApplicationId == "")
                    {
                        blockBlob = cloudBlobContainer.GetBlockBlobReference($"{BusinessUnitId}/{CatogeryType}/{fileName}");
                    }
                    else
                    {
                        blockBlob = cloudBlobContainer.GetBlockBlobReference($"{BusinessUnitId}/{CatogeryType}/{ApplicationId}/{fileName}");
                    }
                    await blockBlob.DownloadToStreamAsync(memoryStream);
                }
                Stream blobStream = blockBlob.OpenReadAsync().Result;
                
                return ReadAllBytes(blobStream);
                //return File(blobStream, blockBlob.Properties.ContentType, blockBlob.Name);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                ex.ToString();
            }
            return Array.Empty<byte>();
        }
        private static byte[] ReadAllBytes(Stream instream)
        {
            if (instream is MemoryStream)
                return ((MemoryStream)instream).ToArray();

            using (var memoryStream = new MemoryStream())
            {
                instream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
      
    }
}
