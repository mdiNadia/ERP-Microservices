

using Microsoft.AspNetCore.Http;

namespace Common.Infrastructure.Services.FileStorage
{
    public interface IFileUploader
    {
        Task<string> UploadFile(IFormFile file, string folderName);
     
        Task<bool> DeleteFile(string ImgName, string folderName);
    }
}
