
using Microsoft.AspNetCore.Http;

namespace Common.Infrastructure.Services.FileStorage
{
    public class FileUploader : IFileUploader
    {
        public async Task<bool> DeleteFile(string ImgName, string folderName)
        {
            string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles" + folderName + "/" + ImgName));
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
                return true;
            }
            else
                return false;
        }


        public async Task<string> UploadFile(IFormFile file, string folderName)
        {
            string path = "";
            try
            {
                if (file.Length > 0)
                {
                    path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles" + folderName));
                    var filename = Guid.NewGuid();
                    var extension = Path.GetExtension(file.FileName);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (var fileStream = new FileStream(Path.Combine(path, filename + extension), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    return filename + extension;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("File Copy Failed", ex);
            }
        }

    }
}
