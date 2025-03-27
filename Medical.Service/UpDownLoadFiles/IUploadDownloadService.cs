using Microsoft.AspNetCore.Http;

namespace Medical.Service.UpDownLoadFiles
{
    public interface IUploadDownloadService
    {
        Task<string> UploadAsync(IFormFile fileStream, string fileName, string CatogeryType, string ApplicationId, Guid BusinessUnitId = default(Guid));
        Task DeleteAsync(string fileName);
        Task<string> DownloadAsync(string fileName, string CatogeryType, string ApplicationId, Guid BusinessUnitId = default(Guid));
        Task<byte[]> DownloadAsStreamAsync(string fileName, string CatogeryType, string ApplicationId, Guid BusinessUnitId = default(Guid));
        Task<string> UploadbytesAsync(byte[] bytes, string fileName, string CatogeryType, string ApplicationId, Guid BusinessUnitId = default(Guid));
      
    }
}
