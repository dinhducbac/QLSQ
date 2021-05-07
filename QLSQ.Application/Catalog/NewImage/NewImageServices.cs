using Microsoft.AspNetCore.Http;
using QLSQ.Application.Common;
using System;
using System.Collections.Generic;
using QLSQ.Utilities.Exceptions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using QLSQ.ViewModel.Common;
using QLSQ.ViewModel.Catalogs.NewImage;
using QLSQ.Data.EF;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace QLSQ.Application.Catalog.NewImage
{
    public class NewImageServices : INewImageServices
    {
        public readonly INewImageStorageService _newImageStorageService;
        public readonly QL_SiQuanDBContext _context;
        public NewImageServices(INewImageStorageService newImageStorageService, QL_SiQuanDBContext context)
        {
            _newImageStorageService = newImageStorageService;
            _context = context;
        }

        public async Task<APIResult<bool>> DeleteNewImageByNewID(int NewID)
        {
            var query = from newimage in _context.NewImages
                        where newimage.NewID == NewID
                        select newimage;
            foreach (var data in query)
            {
                _context.NewImages.Remove(data);
                await _context.SaveChangesAsync();
            }
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<string>> GetImagePathByNewID(int NewID)
        {
            var imagepath = await (from newimage in _context.NewImages
                        where newimage.NewID == NewID
                        select newimage.ImagePath).FirstOrDefaultAsync();
            return new APISuccessedResult<string>(imagepath);
        }

        public async Task<string> SaveFile(IFormFile file)
        {
            var orignalfilename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('*');
            //var filename = $"{Guid.NewGuid()}{Path.GetExtension(orignalfilename)}";
            var filename = orignalfilename.Substring(0, orignalfilename.Length);
            await _newImageStorageService.SaveFileAsync(file.OpenReadStream(), filename);
            //return filename;
            return filename;
        }
    }
}
