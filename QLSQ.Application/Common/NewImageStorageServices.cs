using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.Application.Common
{
    public class NewImageStorageServices : INewImageStorageService
    {
        private readonly string _newimageFolder;
        private const string NEW_IMAGE_FOLDER_NAME = "new-image";

        public NewImageStorageServices(IWebHostEnvironment webHostEnviroment)
        {
            _newimageFolder = Path.Combine(webHostEnviroment.WebRootPath, NEW_IMAGE_FOLDER_NAME);
        }

        public async Task DeleteFileAsync(string fileName)
        {
            var filePath = Path.Combine(_newimageFolder, fileName);
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }

        public string GetFileUrl(string fileName)
        {
            return $"/{NEW_IMAGE_FOLDER_NAME}/{fileName}";
        }
        // 37 42 84
        public async Task SaveFileAsync(Stream mediaBinaryStream, string fileName)
        {
            var filePath = Path.Combine(_newimageFolder, fileName);
            var test = filePath;
            //using (var output = new FileStream(filePath, FileMode.Create))
            //{
            //    await mediaBinaryStream.CopyToAsync(output);
            //}
            using (FileStream fs = File.Create(filePath))
            {
                await mediaBinaryStream.CopyToAsync(fs);
                fs.Flush();
            }
        }
    }
}
