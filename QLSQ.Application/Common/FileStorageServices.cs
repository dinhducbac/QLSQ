using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.Application.Common
{
    public class FileStorageServices : IStorageServices 
    {
        private readonly string _userContentFolder;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public FileStorageServices(IWebHostEnvironment webHostEnviroment )
        {
            _userContentFolder = Path.Combine(webHostEnviroment.WebRootPath,USER_CONTENT_FOLDER_NAME);
        }

        public async Task DeleteFileAsync(string fileName)
        {
            var filePath = Path.Combine(_userContentFolder, fileName);
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }

        public string GetFileUrl(string fileName)
        {
            return $"/{USER_CONTENT_FOLDER_NAME}/{fileName}";
        }
        // 37 42 84
        public async Task SaveFileAsync(Stream mediaBinaryStream, string fileName)
        {
            var filePath = Path.Combine(_userContentFolder, fileName);
            var test = filePath;
            //using (var output = new FileStream(filePath, FileMode.Create))
            //{
            //    await mediaBinaryStream.CopyToAsync(output);
            //}
            using (FileStream fs = System.IO.File.Create(filePath))
            {
                await mediaBinaryStream.CopyToAsync(fs);
                fs.Flush();
            }
        }
    }
}
