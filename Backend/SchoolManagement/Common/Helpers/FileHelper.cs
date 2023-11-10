using Common.Constants;
using Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace Common.Helpers
{
    public class FileHelper
    {
        private readonly IHostEnvironment _env;

        public FileHelper(IHostEnvironment env) { _env = env; }

        public async Task<KeyValuePair<string, string>> UploadFileToDestination(IFormFile file)
        {
            try
            {
                string TargetDirectoryPath = _env.ContentRootPath + SystemConstants.WWWROOT_PATH + SystemConstants.IMAGES_PATH;
                if (!Directory.Exists(TargetDirectoryPath))
                {
                    Directory.CreateDirectory(TargetDirectoryPath);
                }
                string UniqueFileName = $"{Guid.NewGuid()}_{file.FileName}";
                string TargetFilePath = Path.Combine(TargetDirectoryPath, UniqueFileName);

                using (var fileStream = new FileStream(TargetFilePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                string RelativeFilePath = $"{SystemConstants.IMAGES_PATH}/{UniqueFileName}";
                return new KeyValuePair<string, string>(RelativeFilePath, file.ContentType);
            }
            catch
            {
                throw new FileNullException(MessageConstants.ERROR_WHILE_UPLOADING_FILE);
            }
        }
            
        public bool DeleteFileFromDestination(string FilePath)
        {
            if (FilePath.Equals(SystemConstants.DEFAULT_AVATAR)) return true;
            try
            {
                string TargetFilePath = $"{_env.ContentRootPath}{FilePath}";
                if (File.Exists(TargetFilePath))
                {
                    File.Delete(TargetFilePath);
                }
                return true;
            }
            catch (Exception)
            {
                throw new FileNotFoundException($"{FilePath} not found");
            }
        }
    }
}
